namespace Blip.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Iso3 = c.String(nullable: false, maxLength: 3),
                        CountryNameEnglish = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Iso3);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 128),
                        CountryIso3 = c.String(nullable: false, maxLength: 3),
                        RegionCode = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Countries", t => t.CountryIso3, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionCode)
                .Index(t => t.CountryIso3)
                .Index(t => t.RegionCode);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionCode = c.String(nullable: false, maxLength: 3),
                        Iso3 = c.String(nullable: false, maxLength: 3),
                        RegionNameEnglish = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionCode)
                .ForeignKey("dbo.Countries", t => t.Iso3, cascadeDelete: true)
                .Index(t => t.Iso3);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RegionCode", "dbo.Regions");
            DropForeignKey("dbo.Regions", "Iso3", "dbo.Countries");
            DropForeignKey("dbo.Customers", "CountryIso3", "dbo.Countries");
            DropIndex("dbo.Regions", new[] { "Iso3" });
            DropIndex("dbo.Customers", new[] { "RegionCode" });
            DropIndex("dbo.Customers", new[] { "CountryIso3" });
            DropTable("dbo.Regions");
            DropTable("dbo.Customers");
            DropTable("dbo.Countries");
        }
    }
}
