using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.DAL.DataContext.Repositories;
using BookLibrary.DAL.Interfaces;
using BookLibrary.DAL.Interfaces.Repositories;

namespace BookLibrary.DAL.DataContext
{
    public class UnitOfWork: IUnitOfWork
    {
        protected BookLibraryContext _context { get; set; }
        public UnitOfWork(BookLibraryContext context)
        {
            _context = context;
        }
        //Lazy creating repositories only when they are addressed
        protected AuthorRepository _authorRepository;
        public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);

        protected GenreRepository _genreRepository;
        public IGenreRepository Genres => _genreRepository ??= new GenreRepository(_context);

        protected BookRepository _bookRepository;
        public IBookRepository Books => _bookRepository ??= new BookRepository(_context);


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
