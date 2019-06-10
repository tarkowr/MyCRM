namespace MyCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(nullable: false, maxLength: 100),
                        Organization = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Membership",
                c => new
                    {
                        MembershipID = c.Int(nullable: false, identity: true),
                        MembershipLevel = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(),
                        ExpirationDate = c.DateTime(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Membership", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Customer", "AccountID", "dbo.Account");
            DropIndex("dbo.Membership", new[] { "CustomerID" });
            DropIndex("dbo.Customer", new[] { "AccountID" });
            DropTable("dbo.Membership");
            DropTable("dbo.Customer");
            DropTable("dbo.Account");
        }
    }
}
