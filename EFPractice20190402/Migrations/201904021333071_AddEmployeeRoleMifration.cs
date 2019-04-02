namespace EFPractice20190402.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeRoleMifration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        EmployeeRoleId = c.Guid(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeRoleId);
            
            CreateTable(
                "dbo.EmployeesEmployeeRoles",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.RoleId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeesEmployeeRoles", "RoleId", "dbo.EmployeeRoles");
            DropForeignKey("dbo.EmployeesEmployeeRoles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeesEmployeeRoles", new[] { "RoleId" });
            DropIndex("dbo.EmployeesEmployeeRoles", new[] { "EmployeeId" });
            DropTable("dbo.EmployeesEmployeeRoles");
            DropTable("dbo.EmployeeRoles");
        }
    }
}
