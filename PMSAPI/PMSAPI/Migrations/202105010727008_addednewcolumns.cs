namespace PMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUsers", "Country", c => c.String());
            AddColumn("dbo.tblUsers", "State", c => c.String());
            AddColumn("dbo.tblUsers", "City", c => c.String());
            AddColumn("dbo.tblUsers", "Pincode", c => c.String());
            AddColumn("dbo.tblUsers", "StreetAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUsers", "StreetAddress");
            DropColumn("dbo.tblUsers", "Pincode");
            DropColumn("dbo.tblUsers", "City");
            DropColumn("dbo.tblUsers", "State");
            DropColumn("dbo.tblUsers", "Country");
        }
    }
}
