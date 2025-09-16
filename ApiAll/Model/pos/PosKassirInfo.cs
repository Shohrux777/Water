using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [NotMapped]
    [Table("pos_kassa_info")]
    public class PosKassirInfo
    {
      public String name { get; set; }
      public double? total_sum { get; set; }
      public double? profit_sum { get; set; }  
    }
}
