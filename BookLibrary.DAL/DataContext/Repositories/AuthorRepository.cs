using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.DataContext.Repositories
{
    public class AuthorRepository:Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
