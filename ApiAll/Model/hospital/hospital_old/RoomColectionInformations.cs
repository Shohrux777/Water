using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class RoomColectionInformations : BaseModel
    {
        public String number { get; set; }
        public String name { get; set; }
        public long count { get; set; }
        public String note { get; set; }

    }
}
