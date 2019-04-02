namespace EFPractice20190402.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeFileMetaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeFileMetas",
                c => new
                    {
                        EmployeeFileMetaId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        EmployeeFolderId = c.Guid(nullable: false),
                        S3StorageObjectId = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeFileMetaId)
                .ForeignKey("dbo.EmployeeFolders", t => t.EmployeeFolderId, cascadeDelete: true)
                .Index(t => t.EmployeeFolderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeFileMetas", "EmployeeFolderId", "dbo.EmployeeFolders");
            DropIndex("dbo.EmployeeFileMetas", new[] { "EmployeeFolderId" });
            DropTable("dbo.EmployeeFileMetas");
        }
    }
}
