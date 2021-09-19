using MediatR;
using System.Collections.Generic;


namespace Grocery.API.Application.Product.Query
{
    public class ListProductsQuery : IRequest<IEnumerable<Domain.Product>>
    {

    }
}
