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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasRequired(p => p.PublisherName)
                .WithMany(b => b.Books)
                .HasForeignKey(m => m.IdBook);

            modelBuilder.Entity<Book>()
                .HasMany(a => a.Autors)
                .WithMany(b => b.Books)
                .Map(ca =>
               {
                   ca.MapLeftKey("BookId");
                   ca.MapRightKey("AutorId");
                   ca.ToTable("BookAutors");
               });
            modelBuilder.Entity<Book>()
               .HasMany(g=> g.Genres)
               .WithMany(b => b.Books)
               .Map(ca =>
               {
                   ca.MapLeftKey("BookId");
                   ca.MapRightKey("GenresId");
                   ca.ToTable("BookGenres");
               });




        }


    }
}