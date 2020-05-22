using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.DataContext.Repositories
{
    public class BookRepository:Repository<Book>, IBookRepository
    {
        public BookRepository(BookLibraryContext context) : base(context)
        {
        }

    }
}
