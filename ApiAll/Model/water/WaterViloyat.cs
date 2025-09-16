using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_viloyat")]
    public class WaterViloyat: WaterBaseModel
    {
       public String name { get; set; }
    }
}
