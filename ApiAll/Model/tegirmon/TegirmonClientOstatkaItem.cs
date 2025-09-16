using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_client_ostatka_item")]
    public class TegirmonClientOstatkaItem:TegirmonBaseModel
    {
        public long TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double qty { get; set; }
        public double real_qty { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;

        public bool get_or_take_status { get; set; } = false;
    }
}
