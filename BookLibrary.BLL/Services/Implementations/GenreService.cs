using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.BLL.Exceptions;
using BookLibrary.BLL.Services.Interfaces;
using BookLibrary.CORE.Models;
using BookLibrary.DAL.Interfaces;

namespace BookLibrary.BLL.Services.Implementations
{
    public class GenreService:IGenreService
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Genre entity)
        {
            if (entity == null)
            {
                throw new NullArgumentServiceException();
            }
            _unitOfWork.Genres.Add(entity);
        }

        public Genre Get(int id)
        {
            return _unitOfWork.Genres.Read(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _unitOfWork.Genres.GetAll();
        }

        public Genre Update(Genre entity)
        {
            return _unitOfWork.Genres.Update(entity);
        }

        public void Delete(Genre entity)
        {
            _unitOfWork.Genres.Delete(entity);
        }
    }
}
