using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_salary_monthly_info")]
    public class OquvMarkazUserSalaryMonthly:OquvMarkazBaseModel
    {
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        public double summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;
        public double payed_summ { get; set; } = 0.0;
        public double payed_for_card_summ { get; set; } = 0.0;
        public double bounus_summ { get; set; } = 0.0;
        public long year { get; set; } = 2022;
        public long month { get; set; } = 0;

    }
}
