using System;
using System.Collections.Generic;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_product_persantage")]
    public class TegirmonProductToProductPersentage : TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public List<TegirmonProductToProductPersentageDetail> item_list { get; set; }

    }
}
