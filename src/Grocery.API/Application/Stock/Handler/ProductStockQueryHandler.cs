using Grocery.Application.API.Application.Stock.Queries;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.API.Application.Stock.Handler
{
    public class ProductStockQueryHandler : IRequestHandler<ProductStockQuery, Domain.Stock>
    {
        private readonly IGenericRepository<Domain.Stock> _genericRepository;

        public ProductStockQueryHandler(IGenericRepository<Domain.Stock> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Domain.Stock> Handle(ProductStockQuery request, CancellationToken cancellationToken)
        {
            var stock = await _genericRepository.GetAllAsync(
                    noTracking: true,
                    filter: x => x.ProductId == request.IdProduct, 
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return stock.FirstOrDefault();
                
        }
    }
}
