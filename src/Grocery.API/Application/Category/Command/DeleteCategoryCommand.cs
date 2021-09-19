using MediatR;

namespace Grocery.API.Application.Category.Command
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
