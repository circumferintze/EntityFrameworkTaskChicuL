namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookGenres : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GenreBooks", newName: "BookGenres");
            RenameColumn(table: "dbo.BookGenres", name: "Genre_IdGenre", newName: "GenresId");
            RenameColumn(table: "dbo.BookGenres", name: "Book_IdBook", newName: "BookId");
            RenameIndex(table: "dbo.BookGenres", name: "IX_Book_IdBook", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookGenres", name: "IX_Genre_IdGenre", newName: "IX_GenresId");
            DropPrimaryKey("dbo.BookGenres");
            AddPrimaryKey("dbo.BookGenres", new[] { "BookId", "GenresId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookGenres");
            AddPrimaryKey("dbo.BookGenres", new[] { "Genre_IdGenre", "Book_IdBook" });
            RenameIndex(table: "dbo.BookGenres", name: "IX_GenresId", newName: "IX_Genre_IdGenre");
            RenameIndex(table: "dbo.BookGenres", name: "IX_BookId", newName: "IX_Book_IdBook");
            RenameColumn(table: "dbo.BookGenres", name: "BookId", newName: "Book_IdBook");
            RenameColumn(table: "dbo.BookGenres", name: "GenresId", newName: "Genre_IdGenre");
            RenameTable(name: "dbo.BookGenres", newName: "GenreBooks");
        }
    }
}
