namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icollectionsAddedforClicksandFaves : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BookMarks", "Clicks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookMarks", "Clicks", c => c.Int(nullable: false));
        }
    }
}
