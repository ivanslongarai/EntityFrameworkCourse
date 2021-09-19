using FluentValidation.Results;
using Grocery.API.Application.Product.Validation;
using MediatR;
using System.Text.Json.Serialization;


namespace Grocery.API.Application.Product.Command
{
    public class CreateCommand : IRequest<bool>
    {
        private ValidationResult validation;
        public CreateCommand(string description, int[] idCategories)
        {
            Description = description;
            IdCategories = idCategories;

            var validator = new CreateCommandValidator();
            validation = validator.Validate(this);
        }
        public string Description { get; set; }
        public int[] IdCategories { get; set; }
        [JsonIgnore]
        public ValidationResult Validation => validation;
    }      
}
