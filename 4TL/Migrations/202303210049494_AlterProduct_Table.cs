namespace _4TL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterProduct_Table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "CateId");
            RenameColumn(table: "dbo.Product", name: "Category_Id", newName: "CateId");
            RenameIndex(table: "dbo.Product", name: "IX_Category_Id", newName: "IX_CateId");
            AddColumn("dbo.Product", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "Des", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Des", c => c.String(maxLength: 50));
            DropColumn("dbo.Product", "Year");
            RenameIndex(table: "dbo.Product", name: "IX_CateId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Product", name: "CateId", newName: "Category_Id");
            AddColumn("dbo.Product", "CateId", c => c.Int());
        }
    }
}
