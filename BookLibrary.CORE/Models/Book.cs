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
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }

    }
}
