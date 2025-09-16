using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_remoproba")]
    public class HospitalRemaproba: HospitalBaseModel
    {
        public String device_name { get; set; }
        public String srb { get; set; }
        public String rf { get; set; }
        public String aslo { get; set; }

    }
}
