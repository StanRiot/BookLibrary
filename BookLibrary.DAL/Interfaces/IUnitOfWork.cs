using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuthorRepository Authors { get; set; }
        public IGenreRepository Genres { get; set; }
        public IBookRepository Books { get; set; }

        public void SaveChanges();
    }
}
