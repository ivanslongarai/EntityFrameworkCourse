using Grocery.Application.API.Application.Stock.Command;
using Grocery.Application.API.Application.Stock.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{idProduct:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductStock([FromRoute] int idProduct, CancellationToken cancellationToken = default)
        {
            var stock = await _mediator.Send(new ProductStockQuery 
            { 
                IdProduct = idProduct
            }, cancellationToken).ConfigureAwait(false);
            return stock == null ? NoContent() : Ok(stock);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(StockCommand stockCommand, CancellationToken cancellationToken = default)
        {
            var sucess = await _mediator.Send(stockCommand, cancellationToken).ConfigureAwait(false);
            return sucess ? Ok(true) : BadRequest();
        }
    }
}
