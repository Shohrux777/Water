using System;
namespace ApiAll.Model
{
    public class Datchik : BaseModel
    {
        public String name { get; set; }
        public String serialNumber { get; set; }
        public String model { get; set; }
        public String note { get; set; }
        public double min { get; set; }
        public double max { get; set; }

    }
}
