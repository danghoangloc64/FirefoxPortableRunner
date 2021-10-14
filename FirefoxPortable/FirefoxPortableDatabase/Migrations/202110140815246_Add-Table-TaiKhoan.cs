namespace FirefoxPortableDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTaiKhoan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LinkDownloadProfiles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TenLinkDownloadProfile = c.String(),
                        LinkLinkDownloadProfile = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Key = c.String(),
                        NgayHetHan = c.DateTime(),
                        Actived = c.Boolean(nullable: false),
                        DiskSerial = c.String(),
                        LinkDownloadProfileId = c.Guid(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinkDownloadProfiles", t => t.LinkDownloadProfileId, cascadeDelete: true)
                .Index(t => t.LinkDownloadProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoans", "LinkDownloadProfileId", "dbo.LinkDownloadProfiles");
            DropIndex("dbo.TaiKhoans", new[] { "LinkDownloadProfileId" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.LinkDownloadProfiles");
        }
    }
}
