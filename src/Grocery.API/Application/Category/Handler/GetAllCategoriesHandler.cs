using Grocery.API.Application.Category.Query;
using Grocery.InfraInstructure.Data.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.API.Application.Category.Handler
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Category>>
    {
        private readonly IGenericRepository<Domain.Category> _categoryRepository;

        public GetAllCategoriesHandler(IGenericRepository<Domain.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Domain.Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAllAsync(
                    noTracking : true,
                    cancellationToken : cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
