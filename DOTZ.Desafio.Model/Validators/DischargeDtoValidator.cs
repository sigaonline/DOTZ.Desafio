using DOTZ.Desafio.Model.Dto;
using FluentValidation;

namespace DOTZ.Desafio.Model.Validators
{
    public class DischargeDtoValidator : AbstractValidator<DischargeDto>
    {
        public DischargeDtoValidator()
        {
            RuleFor(x => x.PointsValue)
                .GreaterThan(0).WithMessage("Quantidade de Pontos não pode ser igual a zero!");
            RuleFor(x => x.UserId)
                            .GreaterThan(0).WithMessage("Id do usuário não pode ser igual a zero!");
            RuleFor(x => x.ProductId)
                            .GreaterThan(0).WithMessage("Id do produto não pode ser igual a zero!");
        }
    }
}
