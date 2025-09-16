using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_unit_measurment")]
    public class TegirmonUnitMeasurment : TegirmonBaseModel
    {
        public String name { get; set; }
    }
}
