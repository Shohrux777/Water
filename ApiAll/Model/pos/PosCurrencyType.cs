using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_currency_type")]
    public class PosCurrencyType : PosBaseModel
    {
        public String name { get; set; }
        public double nds_persantage { get; set; } = 0.0;
      
    }
}
