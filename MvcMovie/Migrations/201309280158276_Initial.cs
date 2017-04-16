namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 60),
                    ReleaseDate = c.DateTime(nullable: false),
                    Genre = c.String(nullable: false, maxLength: 30),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Rating = c.String(maxLength: 5),
                    movieimage = c.String(maxLength: 500),

                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    UserName = c.String(),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);

            CreateTable(
               "dbo.Customers",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   FirstName = c.String(maxLength: 25),
                   LastName = c.String(nullable: false, maxLength: 25),
                   BirthDate = c.DateTime(nullable: false),
                   StreetAddress = c.String(nullable: false, maxLength: 100),
                   City = c.String(nullable: false, maxLength: 50),
                   State = c.String(nullable: false, maxLength: 30),
                   ZipCode = c.String(nullable: false, maxLength: 10),

               })
               .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Carts",
                c => new
                {
                    CartLineId = c.Int(nullable: false, identity: true),
                    CartId = c.Int(nullable: false, identity: false),
                    MovieId = c.Int(nullable: false, identity: false),
                    Count = c.Int(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CartLineId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");

        }
    }
}
