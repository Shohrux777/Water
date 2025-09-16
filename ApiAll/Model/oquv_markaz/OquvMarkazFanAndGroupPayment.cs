using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_fan_and_group_payment")]
    public class OquvMarkazFanAndGroupPayment : OquvMarkazBaseModel
    {
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }
        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }
        public String note { get; set; }
        public bool payed_or_not { get; set; } = false;
        [NotMapped]
        public int dars_soni { get; set; } = 0;
        [NotMapped]
        public int otilgan_dars_soni { get; set; } = 0;
        [NotMapped]
        public double all_summ { get; set; } = 0;
        [NotMapped]
        public long user_id { get; set; } = 0;


    }
}
