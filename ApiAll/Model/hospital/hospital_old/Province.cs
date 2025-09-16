using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Province :BaseModel
    {
        public String Name { get; set; }
        public List<Districts> districtList { get; set; }

    }
}
