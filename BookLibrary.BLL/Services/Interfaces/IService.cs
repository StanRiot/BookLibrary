using BookLibrary.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.BLL.Services.Interfaces
{
    public interface IService<T> where T:IModel
    {
        public void Create(T entity);
        public T Get(int id);
        public IEnumerable<T> GetAll();
        public T Update(T entity);
        public void Delete(T entity);
        public void Delete(int id);

    }
}
