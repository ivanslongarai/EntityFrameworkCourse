using Grocery.API.Application.Category.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Categoria.Handler
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
            var categoria = await _categoryRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            categoria.Description = request.Description;

            _categoryRepository.Update(categoria);
            return await _categoryRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
