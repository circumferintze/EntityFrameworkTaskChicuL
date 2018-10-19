namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookAutors", name: "Book_IdBook", newName: "BookId");
            RenameColumn(table: "dbo.BookAutors", name: "Autor_idAutor", newName: "AutorId");
            RenameIndex(table: "dbo.BookAutors", name: "IX_Book_IdBook", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookAutors", name: "IX_Autor_idAutor", newName: "IX_AutorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BookAutors", name: "IX_AutorId", newName: "IX_Autor_idAutor");
            RenameIndex(table: "dbo.BookAutors", name: "IX_BookId", newName: "IX_Book_IdBook");
            RenameColumn(table: "dbo.BookAutors", name: "AutorId", newName: "Autor_idAutor");
            RenameColumn(table: "dbo.BookAutors", name: "BookId", newName: "Book_IdBook");
        }
    }
}
