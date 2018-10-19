namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishersAdressese : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailAddresses", "Publisher_PublishedId", "dbo.Publisher");
            DropIndex("dbo.EmailAddresses", new[] { "Publisher_PublishedId" });
            DropColumn("dbo.EmailAddresses", "idPublisher");
            RenameColumn(table: "dbo.EmailAddresses", name: "Publisher_PublishedId", newName: "idPublisher");
            AlterColumn("dbo.EmailAddresses", "idPublisher", c => c.Int(nullable: false));
            CreateIndex("dbo.EmailAddresses", "idPublisher");
            AddForeignKey("dbo.EmailAddresses", "idPublisher", "dbo.Publisher", "PublishedId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailAddresses", "idPublisher", "dbo.Publisher");
            DropIndex("dbo.EmailAddresses", new[] { "idPublisher" });
            AlterColumn("dbo.EmailAddresses", "idPublisher", c => c.Int());
            RenameColumn(table: "dbo.EmailAddresses", name: "idPublisher", newName: "Publisher_PublishedId");
            AddColumn("dbo.EmailAddresses", "idPublisher", c => c.Int(nullable: false));
            CreateIndex("dbo.EmailAddresses", "Publisher_PublishedId");
            AddForeignKey("dbo.EmailAddresses", "Publisher_PublishedId", "dbo.Publisher", "PublishedId");
        }
    }
}
