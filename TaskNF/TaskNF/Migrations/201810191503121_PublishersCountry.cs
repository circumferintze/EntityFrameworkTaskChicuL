namespace TaskNF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishersCountry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publisher", "Country_IdCountry", "dbo.Countries");
            DropIndex("dbo.Publisher", new[] { "Country_IdCountry" });
            DropColumn("dbo.Publisher", "CountryId");
            RenameColumn(table: "dbo.Publisher", name: "Country_IdCountry", newName: "CountryId");
            AlterColumn("dbo.Publisher", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Publisher", "CountryId");
            AddForeignKey("dbo.Publisher", "CountryId", "dbo.Countries", "IdCountry", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publisher", "CountryId", "dbo.Countries");
            DropIndex("dbo.Publisher", new[] { "CountryId" });
            AlterColumn("dbo.Publisher", "CountryId", c => c.Int());
            RenameColumn(table: "dbo.Publisher", name: "CountryId", newName: "Country_IdCountry");
            AddColumn("dbo.Publisher", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Publisher", "Country_IdCountry");
            AddForeignKey("dbo.Publisher", "Country_IdCountry", "dbo.Countries", "IdCountry");
        }
    }
}
