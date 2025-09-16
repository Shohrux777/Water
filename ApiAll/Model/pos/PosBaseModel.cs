using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.pos
{
    public class PosBaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        public DateTime? created_date_time { get; set; } = DateTime.Now;
        public DateTime? updated_date_time { get; set; } = DateTime.Now;
        [NotMapped]
        public String created_date_time_str => created_date_time != null ? created_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";

        [NotMapped]
        public String created_date_str => created_date_time != null ? created_date_time?.ToString("dd-MM-yyyy ") : "";

        [NotMapped]
        public String updated_date_time_str => updated_date_time != null ? updated_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";
        public long? real_company_id { get; set; }

    }
}
