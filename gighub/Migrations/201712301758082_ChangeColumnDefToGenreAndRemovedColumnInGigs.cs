namespace gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnDefToGenreAndRemovedColumnInGigs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Gigs", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "test", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 240));
        }
    }
}
