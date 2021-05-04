namespace PMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delcategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblProducts", new[] { "CategoryId" });
            DropColumn("dbo.tblProducts", "CategoryId");
            DropTable("dbo.tblCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.tblProducts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblProducts", "CategoryId");
            AddForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories", "CategoryId", cascadeDelete: true);
        }
    }
}
