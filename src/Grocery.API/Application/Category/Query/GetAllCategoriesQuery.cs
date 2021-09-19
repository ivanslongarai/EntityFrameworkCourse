using MediatR;
using System.Collections.Generic;

namespace Grocery.API.Application.Category.Query
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Domain.Category>>
    {
    }
}
