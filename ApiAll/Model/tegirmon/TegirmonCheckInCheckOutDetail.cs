using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_check_in_out_detail")]
    public class TegirmonCheckInCheckOutDetail : TegirmonBaseModel
    {
        public String name { get; set; }
        public DateTime reg_date_time { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime reg_date { get; set; } = DateTime.Now;

        [Column(TypeName = "time")]
        public TimeSpan check_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime check_date { get; set; }

        public long? TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }

        public long? TegirmonUserid { get; set; }
        public TegirmonUser user { get; set; }

        public int id_ev { get; set; }
        public String image_base_64 { get; set; }

        public String image_url { get; set; }
    }
}
