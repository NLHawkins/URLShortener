namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favoriteModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FaverId = c.String(maxLength: 128),
                        BookMarkId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.BookMarkId)
                .ForeignKey("dbo.AspNetUsers", t => t.FaverId)
                .Index(t => t.FaverId)
                .Index(t => t.BookMarkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "FaverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "BookMarkId", "dbo.AspNetUsers");
            DropIndex("dbo.Favorites", new[] { "BookMarkId" });
            DropIndex("dbo.Favorites", new[] { "FaverId" });
            DropTable("dbo.Favorites");
        }
    }
}
