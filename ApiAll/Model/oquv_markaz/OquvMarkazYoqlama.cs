using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_oquvchi_yoqlama")]
    public class OquvMarkazYoqlama : OquvMarkazBaseModel
    {
        public bool status_keldi_ketdi { get; set; } = false;
        public DateTime date_keldi_ketti { get; set; } = DateTime.Now;
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }
        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }
        public String note { get; set; }


    }
}
