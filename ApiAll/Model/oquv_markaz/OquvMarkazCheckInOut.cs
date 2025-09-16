using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_check_in_out")]
    public class OquvMarkazCheckInOut:OquvMarkazBaseModel
    {
        public long? OquvMarkazClientid  { get; set; }
        public OquvMarkazClient client { get; set; }

        public long? OquvMarkazUserid  { get; set; }
        public OquvMarkazUser user { get; set; }

        [Column(TypeName = "date")]
        public DateTime get_date { get; set; } = DateTime.Now;

        [Column(TypeName = "time")]
        public TimeSpan get_time { get; set; }

        public DateTime saved_date_time { get; set; } = DateTime.Now;

        public bool user_or_client { get; set; } = true;
    }
}
