using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Interfaces;

namespace BookLibrary.CORE.Models
{
    public class Genre : IModel
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
    }
}
