using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{

    [Table("oquv_markaz_pupil_groups_detail_info")]
    public class OquvMarkazPupilGroupDetailInfo : OquvMarkazBaseModel
    {
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient oquvchi { get; set; }
        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }
        public bool finished_group { get; set; } = false;

        [NotMapped]
        public long lessons_cout { get; set; } = 0;
        [NotMapped]
        public double payments_count { get; set; } = 0.0;

    }
}
