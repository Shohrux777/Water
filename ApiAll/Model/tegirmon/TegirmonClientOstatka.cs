using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_client_ostatka")]
    public class TegirmonClientOstatka:TegirmonBaseModel
    {
        public long TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public DateTime created_date { get; set; } = DateTime.Now;
        
    }
}
