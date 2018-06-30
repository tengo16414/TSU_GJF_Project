namespace GJF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SportsmanModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sportsmen", "PersonalNumber", c => c.String());
            AddColumn("dbo.Sportsmen", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sportsmen", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sportsmen", "Weight");
            DropColumn("dbo.Sportsmen", "BirthDate");
            DropColumn("dbo.Sportsmen", "PersonalNumber");
        }
    }
}
