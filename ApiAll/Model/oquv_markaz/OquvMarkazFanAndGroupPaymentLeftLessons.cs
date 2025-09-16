using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_fan_and_group_payment_left_lessons")]
    public class OquvMarkazFanAndGroupPaymentLeftLessons : OquvMarkazBaseModel
    {
        public long OquvMarkazClientid { get; set; }
        public OquvMarkazClient client { get; set; }
        public long OquvMarkazPupilGroupsid { get; set; }
        public OquvMarkazPupilGroups group { get; set; }
        public long left_real_lessons_count { get; set; } = 0;
        public long lessons_count { get; set; } = 0;
        public double bonus_summ { get; set; } = 0.0;
        public double bonus_summ_for_one_lesson { get; set; } = 0.0;
        

    }
}
