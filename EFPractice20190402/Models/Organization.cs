using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class Organization
    {
        public Guid OrganizationId { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid OrganizationTypeId { get; set; }

        public OrganizationType OrganizationType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Organization()
        {
            Employees = new List<Employee>();
        }
    }

    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            HasKey(k => k.OrganizationId);
            //HasMany(m => m.Employees).WithRequired().HasForeignKey(k => k.OrganizationId);

            //Property(p => p.OrganizationTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
