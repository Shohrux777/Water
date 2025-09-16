using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_client_test_result")]
    public class OquvMarkazTestResult : OquvMarkazBaseModel
    {
        public long OquvMarkazTestid { get; set; }
        public OquvMarkazTest test { get; set; }
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient oquvchi { get; set; }
        public double min_value { get; set; } = 0.0;
        public double max_value { get; set; } = 0.0;
        public double current_value { get; set; } = 0.0;
        public double current_value_in_persantage { get; set; } = 0.0;
        public DateTime current_reg_date_time { get; set; } = DateTime.Now;
        public long? OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }
    }
}
