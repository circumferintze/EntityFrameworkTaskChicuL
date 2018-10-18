using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNF
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Book
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public IEnumerable<Autor> Autors {get; set;}
        public IEnumerable<Genre> Genres { get; set; }
        public Publisher PublisherName { get; set; }
        public DateTimeOffset PublisherDate { get; set; }
        public Country Country { get; set; }
    }
    public class Autor
    {
        public int idAutor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<EmailAddress> EmailAddresses {get; set;} 
    }
    public class Publisher
    {
        public int PublishedId { get; set; }
        public string PublisherName { get; set; }
    }
    public class Genre
    {
        public int IdGenre { get; set; }
        public string GenreName { get; set; }
    }
    public class EmailAddress
    {
        public int IdAdress { get; set; }
        public string Email { get; set; }
    }
    public class Country
    {
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
    }
}