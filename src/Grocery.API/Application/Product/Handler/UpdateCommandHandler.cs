using Grocery.Application.API.Application.Product.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.API.Application.Product.Handlers
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IGenericRepository<Domain.Product> _genericRepository;
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public UpdateCommandHandler(IGenericRepository<Domain.Product> genericRepository, 
            IGenericRepository<Domain.Category> categoryRepository)
        {
            _genericRepository = genericRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {

            var products = await _genericRepository.GetAllAsync(
                filter: x => x.Id == request.Id,
                includeProperties: "Categories"
                ).ConfigureAwait(false);

            var product = products.FirstOrDefault() ??
                throw new ArgumentNullException($"Product {request.Id} not found.");
                   
            product.Description = request.Description;
            if (request.IdCategories.Any())
            {
                var categories = _categoryRepository.GetAll()
                    .Where(x => request.IdCategories.Contains(x.Id)).ToList();
                product.Categories = categories;
            }
                
            _genericRepository.Update(product);

            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
