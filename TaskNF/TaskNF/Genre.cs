using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int IdGenre { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<Book> Books {get; set;}
    }
}