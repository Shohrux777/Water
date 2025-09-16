using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_product_persantage_detail")]
    public class TegirmonProductToProductPersentageDetail : TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct sub_product { get; set; }
        public double persantage { get; set; } = 0;
        public long TegirmonProductToProductPersentageid { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public TegirmonProductToProductPersentage main_inv { get; set; }

        [NotMapped]
        public String product_name => sub_product != null ? sub_product.name : "";
        [NotMapped]
        public List<TegirmonOstatka> ostatkaList { get; set; }
    }
}
