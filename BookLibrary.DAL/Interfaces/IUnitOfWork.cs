using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuthorRepository Authors { get; }
        public IGenreRepository Genres { get; }
        public IBookRepository Books { get;}

        public void SaveChanges();
    }
}
