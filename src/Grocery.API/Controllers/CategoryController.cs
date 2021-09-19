using Grocery.API.Application.Category.Command;
using Grocery.API.Application.Category.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken)
                    .ConfigureAwait(false);

            return categories.Any() ? Ok(categories) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand,
           CancellationToken cancellationToken)
        {
            if (!createCategoryCommand.Validation.IsValid)
                return BadRequest(createCategoryCommand.Validation.Errors);

            var sucess = await _mediator.Send(createCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucess);
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategoryCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}
