using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Interfaces;

namespace BookLibrary.CORE.Models
{
    public class Book : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual ICollection<BooksGenres> Genres { get; set; }
        public virtual ICollection<BooksAuthors> Authors { get; set; }

    }
}
