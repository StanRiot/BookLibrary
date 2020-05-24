using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.DataContext
{
    static class ModelBuilderSeedExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Genre>().HasData(
                new Genre[]
                {
                    new Genre()
                    {
                        Id = 1,
                        Name = "Fantasy"
                    },
                    new Genre()
                    {
                        Id = 2,
                        Name = "Adventure"
                    },
                    new Genre()
                    {
                        Id = 3,
                        Name = "Romance"
                    }
                }
            );
            builder.Entity<Author>().HasData(
                new Author[]
                {
                    new Author()
                    {
                        Id = 1,
                        Name = "George R.R. Martin"
                    },
                    new Author()
                    {
                        Id = 2,
                        Name = "J.K. Rowling"
                    },
                    new Author()
                    {
                        Id = 3,
                        Name = "John Ronald Reuel Tolkien"
                    }
                }
            );

            builder.Entity<Book>().HasData(
                new Book[]
                {
                    //SOIAF series
                    new Book()
                    {
                        Id = 1,
                        Name = "A Game of Thrones",
                        Year = 1996
                    },
                    new Book()
                    {
                        Id = 2,
                        Name = "A Clash of Kings",
                        Year = 1998
                    },
                    new Book()
                    {
                        Id = 3,
                        Name = "A Storm of Swords",
                        Year = 2000
                    },
                    new Book()
                    {
                        Id = 4,
                        Name = "A Feast for Crows",
                        Year = 2005
                    },
                    new Book()
                    {
                        Id = 5,
                        Name = "A Dance with Dragons",
                        Year = 2011
                    },

                    //Harry potter Series
                    new Book()
                    {
                        Id = 6,
                        Name = "The Philosopher's Stone",
                        Year = 1997
                    },
                    new Book()
                    {
                        Id = 7,
                        Name = "The Chamber of Secrets",
                        Year = 1998
                    },
                    new Book()
                    {
                        Id = 8,
                        Name = "The Prisoner of Azkaban",
                        Year = 1999
                    },
                    new Book()
                    {
                        Id = 9,
                        Name = "The Goblet of Fire",
                        Year = 2000
                    },
                    new Book()
                    {
                        Id = 10,
                        Name = "The Order of the Phoenix",
                        Year = 2003
                    },
                    new Book()
                    {
                        Id = 11,
                        Name = "The Half-Blood Prince",
                        Year = 2005
                    },
                    new Book()
                    {
                        Id = 12,
                        Name = "The Deathly Hallows",
                        Year = 2007
                    },
                    //The middle earth stories
                    new Book()
                    {
                        Id = 13,
                        Name = "The Hobbit or There and Back Again",
                        Year = 1937
                    },
                    new Book()
                    {
                        Id = 14,
                        Name = "The Lord of the Rings. The Fellowship of the Ring",
                        Year = 1954
                    },
                    new Book()
                    {
                        Id = 15,
                        Name = "The Lord of the Rings. The Two Towers",
                        Year = 1954
                    },
                    new Book()
                    {
                        Id = 16,
                        Name = "The Lord of the Rings. The Return of the King",
                        Year = 1955
                    }
                }
            );

            builder.Entity<BooksAuthors>().HasData(
                new BooksAuthors[]
                {
                    new BooksAuthors() {AuthorId = 1, BookId = 1},
                    new BooksAuthors() {AuthorId = 1, BookId = 2},
                    new BooksAuthors() {AuthorId = 1, BookId = 3},
                    new BooksAuthors() {AuthorId = 1, BookId = 4},
                    new BooksAuthors() {AuthorId = 1, BookId = 5},
                    new BooksAuthors() {AuthorId = 2, BookId = 1},
                    new BooksAuthors() {AuthorId = 2, BookId = 2},
                    new BooksAuthors() {AuthorId = 2, BookId = 3},
                    new BooksAuthors() {AuthorId = 2, BookId = 4},
                    new BooksAuthors() {AuthorId = 2, BookId = 5},
                    new BooksAuthors() {AuthorId = 3, BookId = 1},
                    new BooksAuthors() {AuthorId = 3, BookId = 2},
                    new BooksAuthors() {AuthorId = 3, BookId = 3},
                    new BooksAuthors() {AuthorId = 3, BookId = 4},
                    new BooksAuthors() {AuthorId = 3, BookId = 5}
                }
            );

            builder.Entity<BooksGenres>().HasData(
                new BooksGenres[]
                {
                    new BooksGenres() {BookId = 1, GenreId = 3},
                    new BooksGenres() {BookId = 2, GenreId = 2},
                    new BooksGenres() {BookId = 3, GenreId = 2},
                    new BooksGenres() {BookId = 4, GenreId = 1},
                    new BooksGenres() {BookId = 5, GenreId = 1},
                    new BooksGenres() {BookId = 6, GenreId = 1},
                    new BooksGenres() {BookId = 7, GenreId = 2},
                    new BooksGenres() {BookId = 8, GenreId = 1},
                    new BooksGenres() {BookId = 9, GenreId = 3},
                    new BooksGenres() {BookId = 10, GenreId = 3},
                    new BooksGenres() {BookId = 11, GenreId = 1},
                    new BooksGenres() {BookId = 12, GenreId = 3},
                    new BooksGenres() {BookId = 13, GenreId = 2},
                    new BooksGenres() {BookId = 14, GenreId = 3},
                    new BooksGenres() {BookId = 15, GenreId = 3}

                }
            );
        }
    }
}
