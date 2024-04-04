using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Shared.Utilities.Constants;

namespace InventoryManagement.UseCases.Helpers
{
    public class ResponseResultHelpers : IResponseResultHelpers
    {
        public void ByPassingValuesAsync<T>(ref ResponseResult<T> response, bool success, T result, string? message = null)
        {
            response.Success = success;
            response.Message = message;
            response.Result = result;
        }

        public void CatalogCommandOperationAsync(ref ResponseResult<int> response, int operationState, string message)
        {
            if (operationState == 0)
            {
                response.Success = false;
                response.Message = message;
                response.Result = operationState;
            }
            else
            {
                response.Success = true;
                response.Message = message;
                response.Result = operationState;
            }
        }
    }
}
