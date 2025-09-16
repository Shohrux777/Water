using ApiAll.Model.tegirmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Controllers.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_tortilgan_bugdoy_royxati")]
    public class TegirmonTortilganBugdoyRoyxati : TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public long? TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }
        public String note { get; set; }
        public String info { get; set; }
        public bool accepted_get_value { get; set; } = false;
        public long? TegirmonAuthid { get; set; }
        public TegirmonAuth auth { get; set; }
        public String client_name{ get; set; }

    }
}
