using AutoMapper;
using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Adstractions.Repositories;
using InventoryManagement.Adstractions.UseCasesPorts;
using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Adstractions.UseCasesSegregation.Catalogs;
using InventoryManagement.Dtos.Abstractions;
using InventoryManagement.Dtos.Catalogs;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Entities.Catalogs;
using InventoryManagement.Shared.Utilities.Constants;
using InventoryManagement.Shared.Utilities.ErrorDtos;
using InventoryManagement.UseCases.Catalogs.Validators;

namespace InventoryManagement.UseCases.Catalogs
{
    public class CurrencyCatalogCrudInteractor : ICatalogUseCaseInputPort
    {
        private readonly ICurrencyTypeCatalogRepository _currencyTypeCatalogRepository;
        private readonly IShowCatalogUseCase<CurrencyTypeCatalog> _showCatalogsByGenericRepository;
        private readonly ICatalogsOperationsUseCase<CurrencyTypeCatalog> _catalogsOperationsByGenericRepository;
        private readonly IResponseOutputPort<IResponseResult> _responseOutputPort;
        private readonly IResponseResultHelpers _responseResultHelpers;
        private readonly CatalogRequestDtoValidator _catalogRequestDtoValidator;
        private readonly IMapper _mapper;

        public CurrencyCatalogCrudInteractor(ICurrencyTypeCatalogRepository currencyTypeCatalogRepository,
            IShowCatalogUseCase<CurrencyTypeCatalog> showCatalogsByGenericRepository,
            ICatalogsOperationsUseCase<CurrencyTypeCatalog> catalogsOperationsByGenericRepository,
            IResponseOutputPort<IResponseResult> responseOutputPort, IResponseResultHelpers responseResultHelpers,
            CatalogRequestDtoValidator catalogRequestDtoValidator, IMapper mapper)
        {
            _currencyTypeCatalogRepository = currencyTypeCatalogRepository;
            _showCatalogsByGenericRepository = showCatalogsByGenericRepository;
            _catalogsOperationsByGenericRepository = catalogsOperationsByGenericRepository;
            _responseOutputPort = responseOutputPort;
            _responseResultHelpers = responseResultHelpers;
            _currencyTypeCatalogRepository = currencyTypeCatalogRepository;
            _catalogRequestDtoValidator = catalogRequestDtoValidator;
            _mapper = mapper;
        }

        public async Task<Task> ShowAllRecordsAsync()
        {
            //InputPort(Interactor) Logic
            ResponseResult<IEnumerable<CurrencyTypeCatalog>> response = new();
            var dataResult = await _showCatalogsByGenericRepository.AllRecordsOrderedByIdDescAsync();
            _responseResultHelpers.ByPassingValuesAsync(ref response, true, dataResult,
                dataResult is not null ? ReplyMessages.MESSAGE_QUERY_SUCCESSFULL : ReplyMessages.MESSAGE_QUERY_EMPTY);

            //OutputPort response
            await _responseOutputPort.Handle(_mapper.Map<ResponseResult<IEnumerable<ResponseCatalogDto>>>(response));
            return Task.CompletedTask;
        }

        public async Task<Task> ShowRecordAsync(int id, RequestCatalogDto request)
        {
            //Request validation
            var validationResult = await _catalogRequestDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //id elemento validation
            if (id != request.Id)
                throw new CustomBadRequestException(ReplyMessages.MESSAGE_DISCREPANCY);

            //InputPort(Interactor) Logic
            ResponseResult<CurrencyTypeCatalog> response = new();
            var recordResult = await _showCatalogsByGenericRepository.ItemAsync(id) ?? throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            _responseResultHelpers.ByPassingValuesAsync(ref response, true, recordResult, ReplyMessages.MESSAGE_QUERY_SUCCESSFULL);

            //OutputPort response
            await _responseOutputPort.Handle(_mapper.Map<ResponseResult<ResponseCatalogDto>>(response));
            return Task.CompletedTask;
        }

        public async Task<Task> CreateRecordAsync(RequestCatalogDto request)
        {
            //Request validation
            var validationResult = await _catalogRequestDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var existItem = await _currencyTypeCatalogRepository.ExistsAsync(request.Name);
            if (existItem)
            {
                throw new  CustomBadRequestException(ReplyMessages.MESSAGE_EXIST);
            }
            else
            {
                var entityMapping = _mapper.Map<CurrencyTypeCatalog>(request);
                var operationResult = await _catalogsOperationsByGenericRepository.CreateAsync(entityMapping, request.UserAlias);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_SAVE : ReplyMessages.MESSAGE_NOTSAVE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }

        public async Task<Task> EditRecordAsync(RequestCatalogDto request)
        {
            //Request validation
            var validationResult = await _catalogRequestDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var existItem = await _currencyTypeCatalogRepository.ExistsAsync(request.Id, request.Code);
            if (!existItem)
            {
                throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            }
            else
            {
                var entityMapping = _mapper.Map<CurrencyTypeCatalog>(request);
                var operationResult = await _catalogsOperationsByGenericRepository.EditAsync(entityMapping, request.UserAlias);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_UPDATE : ReplyMessages.MESSAGE_NOTUPDATE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }

        public async Task<Task> DeleteRecordAsync(int id, RequestCatalogDto request)
        {
            //Request validation
            var validationResult = await _catalogRequestDtoValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            //id elemento validation
            if (id != request.Id)
                throw new CustomBadRequestException(ReplyMessages.MESSAGE_DISCREPANCY);

            //InputPort(Interactor) Logic
            ResponseResult<int> response = new();
            var getItem = await _currencyTypeCatalogRepository.GetItemAsync(id, (Guid)request.Code!, request.Name);
            if (getItem is null)
            {
                throw new KeyNotFoundException(ReplyMessages.MESSAGE_NOTFOUND);
            }
            else
            {
                var operationResult = await _catalogsOperationsByGenericRepository.DeleteAsync(getItem);
                var message = operationResult > 0 ? ReplyMessages.MESSAGE_DELETE : ReplyMessages.MESSAGE_NOTDELETE;
                _responseResultHelpers.CatalogCommandOperationAsync(ref response, operationResult, message);
            }

            //OutputPort response
            await _responseOutputPort.Handle(response);
            return Task.CompletedTask;
        }
    }
}
