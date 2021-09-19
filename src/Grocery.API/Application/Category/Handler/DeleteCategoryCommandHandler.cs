using Grocery.API.Application.Category.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Category.Handler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public DeleteCategoryCommandHandler(IGenericRepository<Domain.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            _categoryRepository.Delete(category);

            return await _categoryRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
