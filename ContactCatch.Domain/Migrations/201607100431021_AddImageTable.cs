namespace ContactCatch.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FileName = c.String(),
                        Description = c.String(),
                        ImageType = c.String(),
                        ImageData = c.Binary(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            AddColumn("dbo.People", "ProfileImage_ImageID", c => c.Int());
            CreateIndex("dbo.People", "ProfileImage_ImageID");
            AddForeignKey("dbo.People", "ProfileImage_ImageID", "dbo.Images", "ImageID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "ProfileImage_ImageID", "dbo.Images");
            DropIndex("dbo.People", new[] { "ProfileImage_ImageID" });
            DropColumn("dbo.People", "ProfileImage_ImageID");
            DropTable("dbo.Images");
        }
    }
}
