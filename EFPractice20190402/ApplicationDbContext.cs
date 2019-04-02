using EFPractice20190402.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402
{
    public class ApplicationDbContext:DbContext
    {
        static readonly string connection = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeFolder> EmployeeFolders { get; set; }
        public DbSet<EmployeeFileMeta> EmployeeFileMetas { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrganizationTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new EmployeeFolderConfiguration());
            modelBuilder.Configurations.Add(new EmployeeFileMetaConfiguration());
            modelBuilder.Configurations.Add(new EmployeeRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext():base(connection)
        {
        }
    }
}
