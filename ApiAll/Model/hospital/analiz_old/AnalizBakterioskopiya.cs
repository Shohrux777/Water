using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class AnalizBakterioskopiya : BaseAnalizModel
    {
        public String bakterios { get; set; }
        public String leykosit { get; set; }
        public String epitkletka { get; set; }
        public String gonokokki { get; set; }
        public String trixomonad { get; set; }
        public String mikflora { get; set; }
        public String ureplazma { get; set; }
        public String xlamidoz { get; set; }
        public String gardnerelez { get; set; }
        public String gribok { get; set; }
        public String vposeve { get; set; }
    }
}
