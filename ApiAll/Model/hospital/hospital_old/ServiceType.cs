using System;

namespace ApiAll.Model
{
    public class ServiceType : BaseModel
    {
        public String Name { get; set; }
        public long Price { get; set; }
        public bool calculateWithPersentage { get; set; }
        public double  persantage { get; set; }
        public long HospitalServiceTypeGroupId { get; set; }
        public HospitalServiceTypeGroup hospitalServiceTypeGroup { get; set; }
        public double contragentPrice { get; set; }
        public bool paymentable { get; set; }
        public String link_str { get; set; }
    }
}
      
