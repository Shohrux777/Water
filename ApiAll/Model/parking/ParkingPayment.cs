using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.parking
{
    [Table("parking_payments")]
    public class ParkingPayment:ParkingBase
    {
        public String vaqti { get; set; }
        public long code { get; set; }
        public double real_qty { get; set; }
        public double changed_qty { get; set; }
        public double dif_qty { get; set; }
        public DateTime reg_date_time { get; set; } = DateTime.Now;

    }
}
