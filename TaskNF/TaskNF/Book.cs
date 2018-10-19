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
        public virtual ICollection<Autor> Autors {get; set;}
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual Publisher PublisherName { get; set; }
        public int PublisherID { get; set; }
        public virtual DateTimeOffset PublisherDate { get; set; }
    }
}