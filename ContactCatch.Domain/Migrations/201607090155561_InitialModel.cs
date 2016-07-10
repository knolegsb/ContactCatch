namespace ContactCatch.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Interests = c.String(),
                        HomeAddress_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Addresses", t => t.HomeAddress_AddressId)
                .Index(t => t.HomeAddress_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "HomeAddress_AddressId", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "HomeAddress_AddressId" });
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
