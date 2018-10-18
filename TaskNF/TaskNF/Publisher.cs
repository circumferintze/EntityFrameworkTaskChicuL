﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int PublishedId { get; set; }
        public string PublisherName { get; set; }
    }
}