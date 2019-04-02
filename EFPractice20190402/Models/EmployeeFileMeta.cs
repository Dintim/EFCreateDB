using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice20190402.Models
{
    public class EmployeeFileMeta
    {
        public Guid EmployeeFileMetaId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid EmployeeFolderId { get; set; }
        public string S3StorageObjectId { get; set; }

        public EmployeeFolder EmployeeFolder { get; set; }
    }

    public class EmployeeFileMetaConfiguration: EntityTypeConfiguration<EmployeeFileMeta>
    {
        public EmployeeFileMetaConfiguration()
        {
            HasKey(k => k.EmployeeFileMetaId);
        }
    }


}
