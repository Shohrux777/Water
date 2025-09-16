using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.hospital.analiz
{
    [Table("hospital_covid_express")]
    public class HospitalCovidExpress:HospitalBaseModel
    {
        public String device_name { get; set; }
        public String result { get; set; }
        public DateTime date_time { get; set; }
    }
}
