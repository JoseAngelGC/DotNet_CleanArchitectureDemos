﻿using FluentValidation;
using InventoryManagement.Dtos.Catalogs;

namespace InventoryManagement.UseCases.Catalogs.Validators
{
    public class CatalogRequestDtoValidator : AbstractValidator<RequestCatalogDto>
    {
        public CatalogRequestDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El parámetro {PropertyName} no puede ser nulo.")
                .GreaterThanOrEqualTo(0).WithMessage("El parámetro {PropertyName} debe ser mayor a 0");
            RuleFor(x => x.Code.ToString())
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú -]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .MaximumLength(40);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .MaximumLength(30);
            RuleFor(x => x.UserAlias)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .MaximumLength(30);
        }
    }
}
