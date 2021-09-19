using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Application.API.Application.Product.Command
{
    public class UpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int[] IdCategories { get; set; }
    }
}
