namespace gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class causeRunTimeError : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "MyUserInfo_Id", "dbo.MyUserInfoes");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "MyUserInfo_Id" });
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Gigs", "ArtistId");
            DropColumn("dbo.Gigs", "GenreId");
            DropColumn("dbo.AspNetUsers", "MyUserInfo_Id");
            DropTable("dbo.MyUserInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "MyUserInfo_Id", c => c.Int());
            AddColumn("dbo.Gigs", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Gigs", "ArtistId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "MyUserInfo_Id");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "MyUserInfo_Id", "dbo.MyUserInfoes", "Id");
        }
    }
}
