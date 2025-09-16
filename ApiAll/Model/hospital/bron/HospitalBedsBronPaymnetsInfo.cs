using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.bron
{
    [Table("hospital_bron_payments")]
    public class HospitalBedsBronPaymnetsInfo : HospitalBaseStandartModel
    {
        public HospitalPatientBronBeds bron { get; set; }
        public long HospitalPatientBronBedsid { get; set; }
        public double summ { get; set; } = 0.0;
        public double real_summ { get; set; } = 0.0;
        public double payed_summ { get; set; } = 0.0;
        public HospitalBedsTypeAndPrice summ_type { get; set; }
        public long HospitalBedsTypeAndPriceid { get; set; }
        public int days_count { get; set; } = 0;
    }
}
