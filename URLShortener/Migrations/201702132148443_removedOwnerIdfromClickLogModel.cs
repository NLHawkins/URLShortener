namespace URLShortener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedOwnerIdfromClickLogModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClickLogs", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.ClickLogs", new[] { "OwnerId" });
            DropColumn("dbo.ClickLogs", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClickLogs", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ClickLogs", "OwnerId");
            AddForeignKey("dbo.ClickLogs", "OwnerId", "dbo.AspNetUsers", "Id");
        }
    }
}
