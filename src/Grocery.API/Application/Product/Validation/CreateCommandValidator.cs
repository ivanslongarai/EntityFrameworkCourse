using FluentValidation;
using Grocery.API.Application.Product.Command;

namespace Grocery.API.Application.Product.Validation
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(300);


            RuleFor(x => x.IdCategories)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Must(x => x.Length > 0);
        }
    }
}
