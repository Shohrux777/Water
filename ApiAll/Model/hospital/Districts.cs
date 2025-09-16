using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Districts : BaseModel
    {
        public String Name { get; set; }
        public long ProvinceId { get; set; }
        public Province province { get; set; }
        [NotMapped]
        public String province_name => province != null ? province.Name : "";
    }
}
