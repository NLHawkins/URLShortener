namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookmarkIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorites", "BookMarkId", "dbo.AspNetUsers");
            DropIndex("dbo.Favorites", new[] { "BookMarkId" });
            AlterColumn("dbo.Favorites", "BookMarkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Favorites", "BookMarkId");
            AddForeignKey("dbo.Favorites", "BookMarkId", "dbo.BookMarks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "BookMarkId", "dbo.BookMarks");
            DropIndex("dbo.Favorites", new[] { "BookMarkId" });
            AlterColumn("dbo.Favorites", "BookMarkId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Favorites", "BookMarkId");
            AddForeignKey("dbo.Favorites", "BookMarkId", "dbo.AspNetUsers", "Id");
        }
    }
}
