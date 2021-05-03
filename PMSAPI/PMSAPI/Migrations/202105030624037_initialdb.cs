namespace PMSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductImage = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        Discount = c.String(),
                        Quantity = c.Int(nullable: false),
                        StockStatus = c.String(),
                        ImageByteCode = c.Binary(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblProductOrders",
                c => new
                    {
                        ProductOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductOrderId)
                .ForeignKey("dbo.tblOrders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblTrackings",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        EstimatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.tblOrders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsAdmin = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Pincode = c.String(),
                        StreetAddress = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.tblProductOrderPayments",
                c => new
                {
                    ProductOrderPaymentId = c.Int(nullable: false, identity: true),
                    ProductOrderId = c.Int(nullable: false),
                    PaymentId = c.Int(nullable: false),
                    CardNumber = c.String(),
                    BankName = c.String(),
                    NameOnCard = c.String(),
                    ExpiryDate = c.DateTime(nullable: false),
                    UserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.ProductOrderPaymentId)
                .ForeignKey("dbo.tblPayments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.tblProductOrders", t => t.ProductOrderId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProductOrderId)
                .Index(t => t.PaymentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblPayments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tblProductOrderPayments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.tblProductOrderPayments", "ProductOrderId", "dbo.tblProductOrders");
            DropForeignKey("dbo.tblProductOrderPayments", "PaymentId", "dbo.tblPayments");
            DropForeignKey("dbo.tblProductOrders", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblOrders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.tblTrackings", "OrderId", "dbo.tblOrders");
            DropForeignKey("dbo.tblProductOrders", "OrderId", "dbo.tblOrders");
            DropForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tblProductOrderPayments", new[] { "UserId" });
            DropIndex("dbo.tblProductOrderPayments", new[] { "PaymentId" });
            DropIndex("dbo.tblProductOrderPayments", new[] { "ProductOrderId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.tblTrackings", new[] { "OrderId" });
            DropIndex("dbo.tblOrders", new[] { "UserId" });
            DropIndex("dbo.tblProductOrders", new[] { "ProductId" });
            DropIndex("dbo.tblProductOrders", new[] { "OrderId" });
            DropIndex("dbo.tblProducts", new[] { "CategoryId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tblPayments");
            DropTable("dbo.tblProductOrderPayments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tblTrackings");
            DropTable("dbo.tblOrders");
            DropTable("dbo.tblProductOrders");
            DropTable("dbo.tblProducts");
            DropTable("dbo.tblCategories");
        }
    }
}
