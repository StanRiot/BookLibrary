using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.BLL.Exceptions;
using BookLibrary.BLL.Services.Interfaces;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces;

namespace BookLibrary.BLL.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Author entity)
        {
            if (entity == null)
            {
                throw new NullArgumentServiceException();
            }
            _unitOfWork.Authors.Add(entity);
        }

        public void Delete(Author entity)
        {
            _unitOfWork.Authors.Delete(entity);
        }

        public Author Get(int id)
        {
            var author = _unitOfWork.Authors.Read(id);
            if (author == null)
            {
                throw new EntityNotFoundException();
            }

            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return _unitOfWork.Authors.GetAll();
        }

        public Author Update(Author entity)
        {
            return _unitOfWork.Authors.Update(entity);
        }

        public void Delete(int id)
        {
            var author = Get(id);
            Delete(author);
        }
    }
}
