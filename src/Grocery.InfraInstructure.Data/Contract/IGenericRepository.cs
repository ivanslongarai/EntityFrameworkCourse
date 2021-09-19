using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;


/* 

 The Repository Pattern

  A repository is nothing but a class defined for an entity, with all the operations possible on that specific entity. 
  For example, a repository for an entity Customer, will have basic CRUD operations and any other possible operations related to it. 
  A Repository Pattern can be implemented in Following ways:
    One repository per entity (non-generic) : 
      This type of implementation involves the use of one repository class for each entity. For example, 
        if you have two entities Order and Customer, each entity will have its own repository.
    Generic repository: 
      A generic repository is the one that can be used for all the entities, 
        in other words it can be either used for Order or Customer or any other entity.

*/


namespace Grocery.InfraInstructure.Data.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        ValueTask<TEntity> GetByKeysAsync(CancellationToken cancellationToken = default, params object[] keys);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            bool noTracking = false, int? take = null, int? skip = null,
            CancellationToken cancellationToken = default);

        /*
          Unit of Work in the Repository Pattern
          
          Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds. 
          To say it in simple words, it means that for a specific user action (say registration on a website), 
            all the transactions like insert/update/delete and so on are done in one single transaction, 
            rather then doing multiple database transactions. This means, one unit of work here involves insert/update/delete operations, 
            all in one single transaction.         
        */
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}
