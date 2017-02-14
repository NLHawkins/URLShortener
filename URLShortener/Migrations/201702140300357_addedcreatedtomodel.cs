namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcreatedtomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookMarks", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookMarks", "Created");
        }
    }
}
