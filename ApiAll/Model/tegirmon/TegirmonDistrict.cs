using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_distict")]
    public class TegirmonDistrict : TegirmonBaseModel
    {
        public String name { get; set; }
    }
}
