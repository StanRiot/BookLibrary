using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.DataContext.Repositories
{
    public class GenreRepository: Repository<Genre>, IGenreRepository
    {
        public GenreRepository(BookLibraryContext context) : base(context)
        {
        }
    }
}
