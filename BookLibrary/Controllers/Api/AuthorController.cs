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
    public class AuthorController : Controller
    {
        private IAuthorService _authorService { get; set; }
        private IMapper _mapper { get; set; }
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet("/api/author/list")]
        public IActionResult GetAuthorList()
        {
            var authors = _authorService.GetAll();
            var viewAuthors = new List<AuthorModel>(authors.Count());
            foreach (var coreAuthor in authors)
            {
                viewAuthors.Add(_mapper.Map<AuthorModel>(coreAuthor));
            }
            return new JsonResult(viewAuthors);
        }

        [HttpGet("/api/author/{id}")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                var author = _authorService.Get(id);
                var authorModel = _mapper.Map<AuthorModel>(author);
                
                return new JsonResult(authorModel);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("/api/author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorService.Delete(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpPatch("/api/author/{id}")]
        public IActionResult PatchAuthor(int id, [FromBody]AuthorModel authorModel)
        {
            try
            {
                var author = _mapper.Map<Author>(authorModel);
                _authorService.Update(author);

                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpPost("/api/author/")]
        public IActionResult CreateAuthor([FromBody] AuthorModel authorModel)
        {
            var author = _mapper.Map<Author>(authorModel);
            _authorService.Create(author);
            return StatusCode(200);
        }
    }
}