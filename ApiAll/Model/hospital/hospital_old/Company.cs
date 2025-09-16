using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Company : BaseModel
    {
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Note { get; set; }
        [DefaultValue(true)]
        public Boolean client { get; set; } = true;
        [DefaultValue(true)]
        public Boolean supplier { get; set; } = true;
        [DefaultValue(true)]
        public Boolean maincompany { get; set; } = true;
        public List<Authorization> authorizations { get; set; }
        public List<Department> departmentList { get; set; }
        
    }
}
