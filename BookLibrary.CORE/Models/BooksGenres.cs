using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Interfaces;

namespace BookLibrary.CORE.Models
{
    public class BooksGenres:IModel
    {
        public int Id { get; set; }


        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
