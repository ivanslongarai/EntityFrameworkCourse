using Grocery.Domain;
using MediatR;

namespace Grocery.Application.API.Application.Stock.Command
{
    public class StockCommand : IRequest<bool>
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public UnitEnum Unit { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
