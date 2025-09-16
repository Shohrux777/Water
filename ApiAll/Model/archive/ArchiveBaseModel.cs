using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    public class ArchiveBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy HH:mm:ss}")]
        public DateTime? created_date_time { get; set; } = DateTime.Now;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy HH:mm:ss}")]
        public DateTime? updated_date_time { get; set; } = DateTime.Now;
        public long company_id { get; set; } = 0;
        [NotMapped]
        public String created_date_time_str => created_date_time != null ? created_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";

        [NotMapped]
        public String updated_date_time_str => updated_date_time != null ? updated_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";

    }
}
