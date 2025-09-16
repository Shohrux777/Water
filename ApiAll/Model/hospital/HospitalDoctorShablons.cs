using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital
{
    public class HospitalDoctorShablons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        public DateTime created_date_time { get; set; } = DateTime.Now;
        public DateTime updated_date_time { get; set; } = DateTime.Now;
        public String shablon_name { get; set; }
        public String shablon_content { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
    }
}
