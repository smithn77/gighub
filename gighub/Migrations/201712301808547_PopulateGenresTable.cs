namespace gighub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (id,name) VALUES(1,'Jazz')");
            Sql("INSERT INTO Genres (id,name) VALUES(2,'Blue')");
            Sql("INSERT INTO Genres (id,name) VALUES(3,'Country')");
        }
        
        public override void Down()
        {
            Sql("Delete FROM Genres WHERE id in (1,2,3)");
        }
    }
}
