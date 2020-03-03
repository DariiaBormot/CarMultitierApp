namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
