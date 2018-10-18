using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; } 
    }
}