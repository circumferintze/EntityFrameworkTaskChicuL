using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public virtual IEnumerable<Autor> Autors {get; set;}
        public virtual IEnumerable<Genre> Genres { get; set; }
        public virtual Publisher PublisherName { get; set; }
        public virtual DateTimeOffset PublisherDate { get; set; }
        public virtual Country Country { get; set; }
    }
}