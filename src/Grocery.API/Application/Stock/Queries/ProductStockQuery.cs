using MediatR;

namespace Grocery.Application.API.Application.Stock.Queries
{
    public class ProductStockQuery : IRequest<Domain.Stock>
    {
        public int IdProduct { get; set; }
    }
}
