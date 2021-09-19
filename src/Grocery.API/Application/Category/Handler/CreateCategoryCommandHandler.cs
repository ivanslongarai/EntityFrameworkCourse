using Grocery.API.Application.Category.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Category.Handler
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public CreateCategoryCommandHandler(IGenericRepository<Domain.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var categoria = new Domain.Category
            {
                Description = request.Description
            };

            await _categoryRepository.AddAsync(categoria, cancellationToken)
                .ConfigureAwait(false);

            return await _categoryRepository.CommitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
