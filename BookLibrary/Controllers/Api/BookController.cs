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
    public class BookController : Controller
    {
        private IBookService _bookService { get; set; }
        private IMapper _mapper { get; set; }

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("/api/book/list")]
        public IActionResult GetBookList()
        {
            var books = _bookService.GetAll();
            var bookViewList = new List<BookModel>(books.Count());
            foreach (var coreBook in books)
            {
                bookViewList.Add(_mapper.Map<BookModel>(coreBook));
            }

            return new JsonResult(bookViewList);
        }

        [HttpGet("/api/book/{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var book = _bookService.Get(id);
                var viewBook = _mapper.Map<BookModel>(book);

                return new JsonResult(viewBook);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpPost("/api/book")]
        public IActionResult CreateBook([FromBody] BookModel bookModel)
        {
            try
            {
                var book = new Book()
                {
                    Name = bookModel.Name,
                    Year = int.Parse(bookModel.Year),
                    Authors = new List<BooksAuthors>(
                        bookModel.Authors.Select(author =>
                            new BooksAuthors()
                            {
                                Author = new Author()
                                {
                                    Name = author
                                },
                                Book = new Book()
                                {
                                    Name = bookModel.Name
                                }
                            })
                    ),
                    Genres = new List<BooksGenres>(
                        bookModel.Genres.Select(genre =>
                            new BooksGenres()
                            {
                                Book = new Book()
                                {
                                    Name = bookModel.Name
                                },
                                Genre = new Genre()
                                {
                                    Name = genre
                                }
                            })
                        )
                };



                _bookService.Create(book);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("/api/book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookService.Delete(id);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [HttpPatch("/api/book/{id}")]
        public IActionResult EditBook(int id, [FromBody]BookModel bookModel)
        {
            try
            {
                var book = new Book()
                {
                    Id = id,
                    Name = bookModel.Name,
                    Year = int.Parse(bookModel.Year),
                    Authors = new List<BooksAuthors>(
                        bookModel.Authors.Select(author =>
                            new BooksAuthors()
                            {
                                Author = new Author()
                                {
                                    Name = author
                                },
                                Book = new Book()
                                {
                                    Name = bookModel.Name
                                }
                            })
                    ),
                    Genres = new List<BooksGenres>(
                        bookModel.Genres.Select(genre =>
                            new BooksGenres()
                            {
                                Book = new Book()
                                {
                                    Name = bookModel.Name
                                },
                                Genre = new Genre()
                                {
                                    Name = genre
                                }
                            })
                    )
                };



                _bookService.Update(book);
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }


    }
}