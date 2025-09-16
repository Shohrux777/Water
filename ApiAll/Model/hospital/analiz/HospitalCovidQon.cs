using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_covid_qon")]
    public class HospitalCovidQon:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String method_check { get; set; }
        public String result_lgg { get; set; }
        public String result_lgm { get; set; }
    }
}
