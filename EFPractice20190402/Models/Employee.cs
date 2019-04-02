using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public virtual ICollection<EmployeeFolder> EmployeeFolders { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }

        public Employee()
        {
            EmployeeFolders = new List<EmployeeFolder>();
            EmployeeRoles = new List<EmployeeRole>();
        }
    }

    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(k => k.EmployeeId);
            HasMany(m => m.EmployeeRoles).WithMany(m => m.Employees).Map(p =>
            {
                p.MapLeftKey("EmployeeId");
                p.MapRightKey("RoleId");
                p.ToTable("EmployeesEmployeeRoles");
            });

            //HasMany(m => m.EmployeeFolders).WithRequired().HasForeignKey(k => k.EmployeeId);
            //Property(p => p.OrganizationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
