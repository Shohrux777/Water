using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_contragent_type")]
    public class WaterContragentType : WaterBaseModel
    {
        public String name { get; set; }
        
    }
}
