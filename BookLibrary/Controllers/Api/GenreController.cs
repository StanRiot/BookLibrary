using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookLibrary.BLL.Services.Interfaces;
using BookLibrary.CORE.Models;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers.Api
{
    public class GenreController : Controller
    {
        private IGenreService _genreService { get; set; }
        private IMapper _mapper { get; set; }
        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet("/api/genre/list")]
        public IActionResult GeGenreList()
        {
            var genres = _genreService.GetAll();
            var viewGenres = new List<GenreModel>(genres.Count());
            foreach (var coreGenre in genres)
            {
                viewGenres.Add(_mapper.Map<GenreModel>(coreGenre));
            }
            return new JsonResult(viewGenres);
        }

        [HttpGet("/api/genre/{id}")]
        public IActionResult GetGenre(int id)
        {
            try
            {
                var genre = _genreService.Get(id);
                var genreModel = _mapper.Map<GenreModel>(genre);

                return new JsonResult(genreModel);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("/api/genre/{id}")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                _genreService.Delete(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpPatch("/api/genre/{id}")]
        public IActionResult PatchGenre(int id, [FromBody]GenreModel genreModel)
        {
            try
            {
                var genre = _mapper.Map<Genre>(genreModel);
                _genreService.Update(genre);

                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpPost("/api/genre/")]
        public IActionResult CreateGenre([FromBody] GenreModel genreModel)
        {
            var genre = _mapper.Map<Genre>(genreModel);
            _genreService.Create(genre);
            return StatusCode(200);
        }
    }
}