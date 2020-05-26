using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class BookModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string[] Authors { get; set; }
        public string[] Genres { get; set; }
    }
}
