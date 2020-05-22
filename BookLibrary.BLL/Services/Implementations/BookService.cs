using System;
using System.Collections.Generic;
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

            return _unitOfWork.Books.Update(entity);
        }

        public void Delete(Book entity)
        {
            _unitOfWork.Books.Delete(entity);
        }
    }
}
