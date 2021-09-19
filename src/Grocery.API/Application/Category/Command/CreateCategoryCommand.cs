using FluentValidation.Results;
using Grocery.API.Application.Category.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Grocery.API.Application.Category.Command
{
    public class CreateCategoryCommand : IRequest<bool>
    {
            public string Description { get; set; }

            [JsonIgnore]
            public ValidationResult Validation { get; }
            public CreateCategoryCommand(string description)
            {
                Description = description;
                var validator = new CreateCategoryCommandValidator();
                Validation = validator.Validate(this);
            }
        }
    }

