﻿using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Interfaces;

namespace BookLibrary.CORE.Models
{
    public class BooksAuthors: IModel
    {
        public int Id { get; set; }


        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author  { get; set; }
    }
}
