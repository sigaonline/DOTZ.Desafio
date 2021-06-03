using DOTZ.Desafio.Model.Dto;
using FluentValidation;

namespace DOTZ.Desafio.Model.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.PointsValue)
                .GreaterThan(0).WithMessage("Quantidade de Pontos não pode ser igual a zero!");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Descrição do produto não pode ser vazio!")
                .NotNull().WithMessage("Descrição do produto não pode ser nulta!")
                .MaximumLength(50).WithMessage("Descrião do produto ultrapassa o tamanho permitido!");
        }
    }
}
