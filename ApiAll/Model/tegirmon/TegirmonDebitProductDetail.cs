using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_debit_product_detail")]
    public class TegirmonDebitProductDetail:TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public double summ { get; set; } = 0.0;
        public long TegirmonDebitid { get; set; }
        public TegirmonDebit debit { get; set; }
    }
}
