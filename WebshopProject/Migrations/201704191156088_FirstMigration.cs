namespace WebshopProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        MovietId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieName = c.String(maxLength: 100),
                        MovieDescription = c.String(),
                        MovieImage = c.String(),
                        Cost = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Custumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BillingAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoiveId = c.Int(nullable: false),
                        CustumertId = c.Int(nullable: false),
                        TotalCost = c.Int(nullable: false),
                        OrderPlaced = c.DateTime(nullable: false),
                        Custumers_Id = c.Int(),
                        Movies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Custumers", t => t.Custumers_Id)
                .ForeignKey("dbo.Movies", t => t.Movies_Id)
                .Index(t => t.Custumers_Id)
                .Index(t => t.Movies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Orders", "Custumers_Id", "dbo.Custumers");
            DropForeignKey("dbo.Carts", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Movies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "Movies_Id" });
            DropIndex("dbo.Orders", new[] { "Custumers_Id" });
            DropIndex("dbo.Movies", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "Movie_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Custumers");
            DropTable("dbo.Categories");
            DropTable("dbo.Movies");
            DropTable("dbo.Carts");
        }
    }
}
