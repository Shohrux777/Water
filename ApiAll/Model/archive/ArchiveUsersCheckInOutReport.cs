using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_user_check_in_out_report")]
    public class ArchiveUsersCheckInOutReport : ArchiveBaseModel
    {
        public int emp_number { get; set; }
        public String device_name { get; set; }
        public String device_type { get; set; }
        public String device_ip { get; set; }
        public DateTime date_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime checkdate { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan checktime { get; set; }

        public long device_id { get; set; }
        [NotMapped]
        public String user_name { get; set; }
    }
}
