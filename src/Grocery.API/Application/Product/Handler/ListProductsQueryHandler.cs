using Grocery.API.Application.Product.Query;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Product.Handler
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, IEnumerable<Domain.Product>>
    {
        private readonly IGenericRepository<Domain.Product> _productRepository;

        public ListProductsQueryHandler(IGenericRepository<Domain.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync(
                    noTracking: false,
                    includeProperties: "Categories,Stock",
                    cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
