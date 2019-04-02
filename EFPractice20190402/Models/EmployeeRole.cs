using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class EmployeeRole
    {        
        public Guid EmployeeRoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public EmployeeRole()
        {
            Employees = new List<Employee>();
        }

    }

    public class EmployeeRoleConfiguration: EntityTypeConfiguration<EmployeeRole>
    {
        public EmployeeRoleConfiguration()
        {
            HasKey(k => k.EmployeeRoleId);
        }
    }


}
