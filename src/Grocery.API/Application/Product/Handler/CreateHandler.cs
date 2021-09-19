using Grocery.API.Application.Product.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Product.Handler
{
    public class CreateHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IGenericRepository<Domain.Product> _productRepository;
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public CreateHandler(IGenericRepository<Domain.Product> productRepository, 
            IGenericRepository<Domain.Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
         
            var categories = _categoryRepository.GetAll()
                .Where(x => request.IdCategories.Contains(x.Id)).ToList();


            var product = new Domain.Product
            {
                Description = request.Description,
                Categories = categories
            };
            await _productRepository.AddAsync(product, cancellationToken).ConfigureAwait(false);
            return await _productRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
