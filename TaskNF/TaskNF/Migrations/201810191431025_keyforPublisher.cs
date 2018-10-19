namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyforPublisher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "PublisherName_PublishedId", "dbo.Publisher");
            DropIndex("dbo.Books", new[] { "PublisherName_PublishedId" });
            RenameColumn(table: "dbo.Books", name: "PublisherName_PublishedId", newName: "PublisherID");
            AlterColumn("dbo.Books", "PublisherID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "PublisherID");
            AddForeignKey("dbo.Books", "PublisherID", "dbo.Publisher", "PublishedId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherID", "dbo.Publisher");
            DropIndex("dbo.Books", new[] { "PublisherID" });
            AlterColumn("dbo.Books", "PublisherID", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "PublisherID", newName: "PublisherName_PublishedId");
            CreateIndex("dbo.Books", "PublisherName_PublishedId");
            AddForeignKey("dbo.Books", "PublisherName_PublishedId", "dbo.Publisher", "PublishedId");
        }
    }
}
