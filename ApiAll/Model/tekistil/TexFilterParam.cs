using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tekistil
{
    public class TexFilterParam
    {
        public String name { get; set; }
        public long? company_id { get; set; }
        public long? department_id { get; set; }
        public long? color_id { get; set; }
        public long? device_id { get; set; }
        public long? unitmeasurment_id { get; set; }
        public long? product_type_id { get; set; }
        public long? sklad_id { get; set; }


    }
}
