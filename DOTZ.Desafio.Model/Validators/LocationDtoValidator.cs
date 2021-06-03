using DOTZ.Desafio.Model.Dto;
using DOTZ.Desafio.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.Model.Validators
{
    public class LocationDtoValidator : AbstractValidator<LocationDto>
    {
        public LocationDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Usuário do endereço inválido!");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("CEP Invalido!")
                .MaximumLength(50).WithMessage("CEP ultrapassa o tamanho permitido!");

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Rua Invalida!")
                .MaximumLength(50).WithMessage("Rua ultrapassa o tamanho permitido!");

            RuleFor(x => x.Complement)
                .NotEmpty().WithMessage("Complemento Invalido!")
                .MaximumLength(50).WithMessage("Complemento ultrapassa o tamanho permitido!");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("Bairro Invalido!")
                .MaximumLength(50).WithMessage("Bairro ultrapassa o tamanho permitido!");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("Estado Invalido!")
                .MaximumLength(2).WithMessage("Estado ultrapassa o tamanho permitido!");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Cidade Invalido!")
                .MaximumLength(50).WithMessage("Cidade ultrapassa o tamanho permitido!");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone Invalido!")
                .MaximumLength(15).WithMessage("Telefone ultrapassa o tamanho permitido!");
        }
    }
}
