﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("Autors")]
    public class Autor
    {
        [Key]
        public int idAutor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses {get; set;} 
        public virtual ICollection<Book> Books { get; set; }
    }
}