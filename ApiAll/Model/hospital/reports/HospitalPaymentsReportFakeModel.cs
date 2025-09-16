using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.reports
{

    [Table("hospital_payments_fake_model")]
    public class HospitalPaymentsReportFakeModel
    {
        public string service_group_name { get; set; }
        public double total { get; set; } = 0.0;
        public double cash { get; set; } = 0.0;
        public double card { get; set; } = 0.0;
        public double service_count { get; set; } = 0.0;
    }
}
