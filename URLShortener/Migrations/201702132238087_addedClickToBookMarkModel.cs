namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClickToBookMarkModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookMarks", "Clicks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookMarks", "Clicks");
        }
    }
}
