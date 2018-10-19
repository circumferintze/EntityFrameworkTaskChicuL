using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNF
{
    [Table("EmailAddresses")]
    public class EmailAddress
    {
        [Key]
        public int IdAdress { get; set; }
        public string Email { get; set; }
        public int IdAutor { get; set; }
        public virtual Autor Autor { get; set; }
        public int idPublisher { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}