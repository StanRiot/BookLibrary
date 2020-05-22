using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BookLibrary.CORE.Interfaces;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.DataContext.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity: class, IModel 
    {
        private BookLibraryContext _context { get; set; }
        public Repository(BookLibraryContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }
        
        public TEntity Read(int id)
        {
            return _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return Read(entity.Id);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public int Count()
        {
            return _context.Set<TEntity>().AsQueryable().Count();
        }
    }
}
