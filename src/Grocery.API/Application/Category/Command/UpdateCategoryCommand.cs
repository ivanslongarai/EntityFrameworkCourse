using MediatR;

namespace Grocery.API.Application.Category.Command
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}