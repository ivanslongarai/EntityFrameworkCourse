using Grocery.Application.API.Application.Stock.Command;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.API.Application.Stock.Handler
{
    public class StockCommandHandler : IRequestHandler<StockCommand, bool>
    {
        private readonly IGenericRepository<Domain.Stock> _genericRepository;
        private readonly IGenericRepository<Domain.Product> _productRepository;

        public StockCommandHandler(
            IGenericRepository<Domain.Stock> genericRepository, 
            IGenericRepository<Domain.Product> productRepository)
        {
            _genericRepository = genericRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(StockCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByKeysAsync(cancellationToken, request.IdProduct) 
                ?? throw new ArgumentException("Product Id is not valid");

            var stock = new Domain.Stock
            { 
                ProductId = product.Id,
                PurchaseInformation = new Domain.Qualitative
                { 
                    UnitPrice = request.UnitPrice,
                    Quantity = request.Quantity,
                    UnitEnum = request.Unit
                }
            };

            await _genericRepository.AddAsync(stock, cancellationToken).ConfigureAwait(false);
            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
