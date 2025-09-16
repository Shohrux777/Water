using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_payments")]
    public class TegirmonPayments : TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public long TegirmonCheckid { get; set; }
        public TegirmonCheck check { get; set; }
        public double qty { get; set; }
        public double summa { get; set; }
        public double profit_summ { get; set; }
    }
}
