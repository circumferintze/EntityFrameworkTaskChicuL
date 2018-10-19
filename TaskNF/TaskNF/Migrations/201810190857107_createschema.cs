namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createschema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        idAutor = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.idAutor);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        IdBook = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Language = c.String(),
                        PublisherDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PublisherName_PublishedId = c.Int(),
                    })
                .PrimaryKey(t => t.IdBook)
                .ForeignKey("dbo.Publisher", t => t.PublisherName_PublishedId)
                .Index(t => t.PublisherName_PublishedId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        IdGenre = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                    })
                .PrimaryKey(t => t.IdGenre);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublishedId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                        CountryId = c.Int(nullable: false),
                        Country_IdCountry = c.Int(),
                    })
                .PrimaryKey(t => t.PublishedId)
                .ForeignKey("dbo.Countries", t => t.Country_IdCountry)
                .Index(t => t.Country_IdCountry);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        IdCountry = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.IdCountry);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        IdAdress = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        IdAutor = c.Int(nullable: false),
                        idPublisher = c.Int(nullable: false),
                        Publisher_PublishedId = c.Int(),
                    })
                .PrimaryKey(t => t.IdAdress)
                .ForeignKey("dbo.Autors", t => t.IdAutor, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.Publisher_PublishedId)
                .Index(t => t.IdAutor)
                .Index(t => t.Publisher_PublishedId);
            
            CreateTable(
                "dbo.BookAutors",
                c => new
                    {
                        Book_IdBook = c.Int(nullable: false),
                        Autor_idAutor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_IdBook, t.Autor_idAutor })
                .ForeignKey("dbo.Books", t => t.Book_IdBook, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.Autor_idAutor, cascadeDelete: true)
                .Index(t => t.Book_IdBook)
                .Index(t => t.Autor_idAutor);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_IdGenre = c.Int(nullable: false),
                        Book_IdBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_IdGenre, t.Book_IdBook })
                .ForeignKey("dbo.Genres", t => t.Genre_IdGenre, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_IdBook, cascadeDelete: true)
                .Index(t => t.Genre_IdGenre)
                .Index(t => t.Book_IdBook);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddresses", "Publisher_PublishedId", "dbo.Publisher");
            DropForeignKey("dbo.EmailAddresses", "IdAutor", "dbo.Autors");
            DropForeignKey("dbo.Publisher", "Country_IdCountry", "dbo.Countries");
            DropForeignKey("dbo.Books", "PublisherName_PublishedId", "dbo.Publisher");
            DropForeignKey("dbo.GenreBooks", "Book_IdBook", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_IdGenre", "dbo.Genres");
            DropForeignKey("dbo.BookAutors", "Autor_idAutor", "dbo.Autors");
            DropForeignKey("dbo.BookAutors", "Book_IdBook", "dbo.Books");
            DropIndex("dbo.GenreBooks", new[] { "Book_IdBook" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_IdGenre" });
            DropIndex("dbo.BookAutors", new[] { "Autor_idAutor" });
            DropIndex("dbo.BookAutors", new[] { "Book_IdBook" });
            DropIndex("dbo.EmailAddresses", new[] { "Publisher_PublishedId" });
            DropIndex("dbo.EmailAddresses", new[] { "IdAutor" });
            DropIndex("dbo.Publisher", new[] { "Country_IdCountry" });
            DropIndex("dbo.Books", new[] { "PublisherName_PublishedId" });
            DropTable("dbo.GenreBooks");
            DropTable("dbo.BookAutors");
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.Countries");
            DropTable("dbo.Publisher");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Autors");
        }
    }
}
