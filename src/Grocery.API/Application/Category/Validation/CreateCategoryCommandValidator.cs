using FluentValidation;
using Grocery.API.Application.Category.Command;

namespace Grocery.API.Application.Category.Validation
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }

}