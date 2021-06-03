using DOTZ.Desafio.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.Model.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Nome do úsuario não pode ser nulo!")
                .NotEmpty().WithMessage("Nome do úsuario não pode ser Vazio!")
                .MaximumLength(50).WithMessage("Nome do úsuario ultrapassa o tamanho permitido!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha do úsuario não pode ser nulo!")
                .NotEmpty().WithMessage("Senha do úsuario não pode ser Vazio!")
                .MaximumLength(50).WithMessage("Senha do úsuario ultrapassa o tamanho permitido!");
            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Role do úsuario não pode ser nulo!");
        }
    }
}
