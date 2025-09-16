using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tegirmon
{
    [Table("tegirmon_ostatka")]
    public class TegirmonOstatka : TegirmonBaseModel
    {
        public long TegirmonProductid { get; set; }
        public TegirmonProduct product { get; set; }
        public double qty { get; set; }
        public double real_qty { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        [NotMapped]
        public TegirmonUnitMeasurment measurment => product != null ? product.unitMeasurment : null;
        [NotMapped]
        public String product_name_str => product != null ? product.name : "";
        [NotMapped]
        public String product_name_str_unit_measurment_name => product != null && product.unitMeasurment != null ? product.unitMeasurment.name : "";


    }
}
