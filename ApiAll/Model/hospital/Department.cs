using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Department : BaseModel
    {
        public String Name { get; set; }
        public long CompanyId { get; set; }
        public Company company { get; set; }
        public List<Rooms> roomsList { get; set; }
        public List<Users> userList { get; set; }
        [NotMapped]
        public String company_name => company != null ? company.Name : "";
    }
}
