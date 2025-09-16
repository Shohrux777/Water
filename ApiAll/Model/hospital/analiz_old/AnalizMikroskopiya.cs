using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class AnalizMikroskopiya : BaseAnalizModel
    {
        public String mish_volokna { get; set; }
        public String soed_tkan { get; set; }
        public String jir_kislota { get; set; }
        public String mila { get; set; }
        public String kletachka { get; set; }
        public String kraxmal { get; set; }
        public String epiteliy { get; set; }
        public String leykosit { get; set; }
        public String eritrosit { get; set; }
        public String deytrit { get; set; }
        public String prosteyshiy { get; set; }
        public String yaglist { get; set; }
    }
}
