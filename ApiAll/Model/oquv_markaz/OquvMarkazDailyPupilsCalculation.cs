using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_daily_pupil_calculation")]
    public class OquvMarkazDailyPupilsCalculation : OquvMarkazBaseModel
    {
        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_only { get; set; } = DateTime.Now;

        public bool all_accepted_status { get; set; } = false;

        public List<OquvMarkazDailyPupilsCalculationInfo> item_list { get; set; }

        [NotMapped]
        public String group_name => group != null ? group.name : "";
    }
}
