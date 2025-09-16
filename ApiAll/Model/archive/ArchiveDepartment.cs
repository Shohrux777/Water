using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_department")]
    public class ArchiveDepartment:ArchiveBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public ArchiveCompany company { get; set; }
        public long ArchiveCompanyid { get; set; }
        [NotMapped]
        public String company_name => company != null ? company.name: "";
    }
}
