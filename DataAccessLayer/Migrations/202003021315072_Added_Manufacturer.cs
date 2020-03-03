namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Manufacturer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetailTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "Name", c => c.String());
            AddColumn("dbo.Cars", "ManufacturerId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Details", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "DetailTypeId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Details", "ManufacturerId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Cars", "ManufacturerId");
            CreateIndex("dbo.Details", "DetailTypeId");
            CreateIndex("dbo.Details", "ManufacturerId");

            Sql("INSERT INTO DetailTypes (Name) VAlUES ('Not Selected')");
            Sql("INSERT INTO Manufacturers (Name) VAlUES ('Not Selected')");

            AddForeignKey("dbo.Details", "DetailTypeId", "dbo.DetailTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Manufacturer");
            DropColumn("dbo.Cars", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Model", c => c.String());
            AddColumn("dbo.Cars", "Manufacturer", c => c.String());
            DropForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Details", "DetailTypeId", "dbo.DetailTypes");
            DropIndex("dbo.Details", new[] { "ManufacturerId" });
            DropIndex("dbo.Details", new[] { "DetailTypeId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropColumn("dbo.Details", "ManufacturerId");
            DropColumn("dbo.Details", "DetailTypeId");
            DropColumn("dbo.Details", "Price");
            DropColumn("dbo.Cars", "ManufacturerId");
            DropColumn("dbo.Cars", "Name");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.DetailTypes");
        }
    }
}
