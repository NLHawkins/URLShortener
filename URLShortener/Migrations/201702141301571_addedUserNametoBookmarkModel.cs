namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserNametoBookmarkModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookMarks", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookMarks", "UserName");
        }
    }
}
