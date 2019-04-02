using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class OrganizationType
    {
        public Guid OrganizationTypeId { get; set; }
        public string OrganizationTypeName { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }

        public OrganizationType()
        {
            Organizations = new List<Organization>();
        }
    }

    public class OrganizationTypeConfiguration : EntityTypeConfiguration<OrganizationType>
    {
        public OrganizationTypeConfiguration()
        {
            HasKey(k => k.OrganizationTypeId);
            //HasMany(m => m.Organizations).WithRequired().HasForeignKey(k => k.OrganizationTypeId);
        }
    }
}
