using Grocery.API.Application.Category.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Category.Handler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IGenericRepository<Grocery.Domain.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            category.Description = request.Description;

            _categoryRepository.Update(category);
            return await _categoryRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
