using BookLibrary.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BookLibrary.DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : IModel
    {
        TEntity Add(TEntity entity);

        TEntity Read(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
        int Count();
    }
}
