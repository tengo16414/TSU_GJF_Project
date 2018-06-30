namespace GJF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SportsmanSexAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sportsmen", "SexId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sportsmen", "SexId");
            AddForeignKey("dbo.Sportsmen", "SexId", "dbo.Sexes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sportsmen", "SexId", "dbo.Sexes");
            DropIndex("dbo.Sportsmen", new[] { "SexId" });
            DropColumn("dbo.Sportsmen", "SexId");
        }
    }
}
