using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class EmployeeFolder
    {
        public Guid EmployeeFolderId { get; set; }
        public string FolderName { get; set; }
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public virtual ICollection<EmployeeFileMeta> EmployeeFileMetas { get; set; }

        public EmployeeFolder()
        {
            EmployeeFileMetas = new List<EmployeeFileMeta>();
        }
    }

    public class EmployeeFolderConfiguration: EntityTypeConfiguration<EmployeeFolder>
    {
        public EmployeeFolderConfiguration()
        {
            HasKey(k => k.EmployeeFolderId);
        }
    }
}
