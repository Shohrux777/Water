using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Rooms : BaseModel
    {
        public String Name { get; set; }
        public String Number { get; set; }
        public long DepartmentId { get; set; }
        public Department department { get; set; }
        public List<Users> userList { get; set; }
        public int BedsCount { get; set; }
        // 0 patient 1 doctor 2 archive
        public int Type { get; set; }
    }
}
