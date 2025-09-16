using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class CustomReportMd
    {
        public List<String> groupNames { get; set; }
        public long districtId { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
