namespace _4TL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProduct_Table99 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CateId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CateId" });
            AlterColumn("dbo.Product", "CateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CateId");
            AddForeignKey("dbo.Product", "CateId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CateId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CateId" });
            AlterColumn("dbo.Product", "CateId", c => c.Int());
            CreateIndex("dbo.Product", "CateId");
            AddForeignKey("dbo.Product", "CateId", "dbo.Category", "Id");
        }
    }
}
