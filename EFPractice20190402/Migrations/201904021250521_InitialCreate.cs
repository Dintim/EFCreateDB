namespace EFPractice20190402.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeFolders",
                c => new
                    {
                        EmployeeFolderId = c.Guid(nullable: false),
                        FolderName = c.String(),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeFolderId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        DoB = c.DateTime(nullable: false),
                        OrganizationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Guid(nullable: false),
                        FullName = c.String(),
                        IdentificationNumber = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        OrganizationTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrganizationId)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationTypeId, cascadeDelete: true)
                .Index(t => t.OrganizationTypeId);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        OrganizationTypeId = c.Guid(nullable: false),
                        OrganizationTypeName = c.String(),
                    })
                .PrimaryKey(t => t.OrganizationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationTypeId", "dbo.OrganizationTypes");
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.EmployeeFolders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Organizations", new[] { "OrganizationTypeId" });
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropIndex("dbo.EmployeeFolders", new[] { "EmployeeId" });
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.Organizations");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeFolders");
        }
    }
}
