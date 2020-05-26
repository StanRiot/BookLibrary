using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLibrary.BLL.Exceptions;
using BookLibrary.BLL.Services.Interfaces;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces;

namespace BookLibrary.BLL.Services.Implementations
{
    public class BookService: IBookService
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Book entity)
        {
            if (entity == null)
            {
                throw new NullArgumentServiceException();
            }

            foreach (var bookGenre in entity.Genres)
            {
                var coreGenre = _unitOfWork.Genres.Find(G => G.Name == bookGenre.Genre.Name).FirstOrDefault();
                if (coreGenre != null)
                {
                    bookGenre.GenreId = coreGenre.Id;
                    bookGenre.Genre = null;
                }
            }

            foreach (var bookAuthor in entity.Authors)
            {
                var coreAuthor = _unitOfWork.Authors.Find(A => A.Name == bookAuthor.Author.Name).FirstOrDefault();
                if (coreAuthor != null)
                {
                    bookAuthor.AuthorId = coreAuthor.Id;
                    bookAuthor.Author = null;
                }
            }


            _unitOfWork.Books.Add(entity);
        }

        public Book Get(int id)
        {
            var book = _unitOfWork.Books.Read(id);
            if (book == null)
            {
                throw new EntityNotFoundException();
            }

            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _unitOfWork.Books.GetAll();
        }

        public Book Update(Book entity)
        {
            if (entity == null)
            {
                throw new NullArgumentServiceException();
            }

            //Called single because we are sure that we have this one in the db
            //It's an update method after all
            var coreBook = _unitOfWork.Books.Find(B => B.Id == entity.Id).Single();
            coreBook.Name = entity.Name;
            coreBook.Year = entity.Year;


            //Filtering the old Authors. The unchecked ones should not be kept
            coreBook.Authors =
                coreBook.Authors.Where(coreAuthor =>
                    entity.Authors.Any(newAuthor => newAuthor.Author.Name == coreAuthor.Author.Name)).ToList();
            
            //Filtering the old Genres. The unchecked ones should not be kept
            coreBook.Genres =
                coreBook.Genres.Where(coreGenre =>
                    entity.Genres.Any(newGenre => newGenre.Genre.Name == coreGenre.Genre.Name)).ToList();

            //Filtered entities we need to get a new relation
            entity.Genres = entity.Genres.Where(entityGenres => 
                coreBook.Genres.All(coreGenre => coreGenre.Genre.Name != entityGenres.Genre.Name)).ToList();
            entity.Authors = entity.Authors.Where(entityAuthors => 
                coreBook.Authors.All(coreAuthor => coreAuthor.Author.Name != entityAuthors.Author.Name)).ToList();



            //Creating new Relations
            foreach (var bookGenre in entity.Genres)
            {
                var genreToAdd = _unitOfWork.Genres.Find(genre => genre.Name == bookGenre.Genre.Name).Single();
                coreBook.Genres.Add(
                        new BooksGenres()
                        {
                            Book = coreBook,
                            BookId = coreBook.Id,
                            Genre = genreToAdd,
                            GenreId = genreToAdd.Id
                        }
                    );
            }
            foreach (var bookAuthor in entity.Authors)
            {
                var authorToAdd = _unitOfWork.Authors.Find(author => author.Name == bookAuthor.Author.Name).Single();
                coreBook.Authors.Add(
                    new BooksAuthors()
                    {
                        Book = coreBook,
                        BookId = coreBook.Id,
                        Author = authorToAdd,
                        AuthorId = authorToAdd.Id
                    }
                );
            }

            return _unitOfWork.Books.Update(coreBook);
        }

        public void Delete(Book entity)
        {
            _unitOfWork.Books.Delete(entity);
        }

        public void Delete(int id)
        {
            var book = Get(id);
            Delete(book);
        }
    }
}
