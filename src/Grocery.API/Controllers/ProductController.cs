using Grocery.API.Application.Product.Command;
using Grocery.API.Application.Product.Query;
using Grocery.Application.API.Application.Product.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new ListProductsQuery(), cancellationToken)
                .ConfigureAwait(false);
            return products.Any() ?  Ok(products) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCommand createCommand, 
            CancellationToken cancellationToken)
        {
            
            if (!createCommand.Validation.IsValid)
                return BadRequest(createCommand.Validation.Errors);

            var sucess = await _mediator.Send(createCommand, cancellationToken)
                .ConfigureAwait(false);
            
            return Ok(sucess);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCommand updateCommand, CancellationToken cancellationToken)
        {
            var sucess = await _mediator.Send(updateCommand, cancellationToken).ConfigureAwait(false);
            return sucess ? Ok(true) : BadRequest();
        }
    }
}
