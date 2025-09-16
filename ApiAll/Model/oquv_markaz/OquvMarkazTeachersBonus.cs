using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_teacher_bonus")]
    public class OquvMarkazTeachersBonus : OquvMarkazBaseModel
    {
        public double summ { get; set; }
        public double real_summ { get; set; }
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        [NotMapped]
        public String user_name => user != null ? user.fio : "";
    }
}
