using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_daily_pupil_calculation_info")]
    public class OquvMarkazDailyPupilsCalculationInfo : OquvMarkazBaseModel
    {
        public long OquvMarkazDailyPupilsCalculationid { get; set; }
        public OquvMarkazDailyPupilsCalculation calc { get; set; }

        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }

        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }

        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        

        public double oqituvchi_bounus { get; set; } = 0.0;

        public bool accepted_status_client { get; set; } = false;

        public bool disaccepted_staus_client { get; set; } = false;

        public String note { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_only { get; set; } = DateTime.Now;

        [NotMapped]
        public String group_name => group != null ? group.name : "";

        [NotMapped]
        public String clinet_name => client != null ? client.fio : "";

        [NotMapped]
        public String user_name => user != null ? user.fio : "";
    }
}
