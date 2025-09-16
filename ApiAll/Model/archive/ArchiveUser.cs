using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_user")]
    public class ArchiveUser:ArchiveBaseModel
    {
        [Required]
        public String fio { get; set; }
        public int emp_number { get; set; } = 0;
        public String father_name { get; set; }
        public String position { get; set; }
        public String note { get; set; }
        public String card_number { get; set; }
        public String device_number { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public long user_type { get; set; } 
        public String image { get; set; }
        public ArchiveDepartment department { get; set; }
        public long ArchiveDepartmentid { get; set; }
        [NotMapped]
        public String department_name => department != null ? department.name : "";
        [NotMapped]
        public TimeSpan? working_time { get; set; } = TimeSpan.Parse("00:00");
        [NotMapped]
        public String checked_date_str { get; set; } = "------";

    }
}
