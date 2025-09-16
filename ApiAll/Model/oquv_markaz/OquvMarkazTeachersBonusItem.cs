using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_teacher_bonus_payed_item")]
    public class OquvMarkazTeachersBonusItem : OquvMarkazBaseModel
    {
        public double summ { get; set; }
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
    }
}
