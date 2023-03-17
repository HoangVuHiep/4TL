namespace _4TL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTablePRODUCTCATEGORY : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(precision: 18, scale: 2),
                        FeatureImage = c.String(maxLength: 200),
                        CateId = c.Int(),
                        Des = c.String(maxLength: 50),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Category_Id", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
