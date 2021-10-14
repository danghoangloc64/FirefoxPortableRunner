namespace FirefoxPortableDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
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
                        FolderName = c.String(),
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
                        NgayKichHoat = c.DateTime(),
                        GioiHanLuotDownload = c.Int(nullable: false),
                        SoLuotDaDownload = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        LinkDownloadProfile_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinkDownloadProfiles", t => t.LinkDownloadProfile_Id)
                .Index(t => t.LinkDownloadProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoans", "LinkDownloadProfile_Id", "dbo.LinkDownloadProfiles");
            DropIndex("dbo.TaiKhoans", new[] { "LinkDownloadProfile_Id" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.LinkDownloadProfiles");
        }
    }
}
