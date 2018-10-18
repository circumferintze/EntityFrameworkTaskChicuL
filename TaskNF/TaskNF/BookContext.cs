using System.Data.Entity;

namespace TaskNF
{
    class BookContext : DbContext
    {
        public BookContext() : base("server=localhost; database=BookDB; truested_connection=true;")
        {

        }
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses {get; set;}
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }


    }
}