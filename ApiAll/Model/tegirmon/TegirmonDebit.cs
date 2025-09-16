using System;
using System.Collections.Generic;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_debit")]
    public class TegirmonDebit : TegirmonBaseModel
    {
        public double money_summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;
        public long TegirmonClientid { get; set; }
        public TegirmonClient client { get; set; }
        public bool finish { get; set; } = false;
        public List<TegirmonDebitProductDetail> product_list { get; set; }
        public List<TegirmonDebitDetail> debits_list { get; set; }

    }
}
