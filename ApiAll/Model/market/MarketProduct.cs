using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketProduct : BaseModel
    {
        public String Name { get; set; }
        public String NameForPrint { get; set; }
        public String Code { get; set; }
        public String Specs { get; set; }
        public String ManifacturerName { get; set; }
        public String Image { get; set; }
        public String Note { get; set; }
        public long MarketUnitMeasurmentId {get;set;}
        public MarketUnitMeasurment marketUnitMeasurment { get; set; }
        public double price { get; set; }
        [NotMapped]
        public long? marketProductGroupId { get; set; }
        [NotMapped]
        public MarketProductGroup marketProductGroup { get; set; }
        [NotMapped]
        public String unimeasurmentName => this.marketUnitMeasurment == null ? " " : this.marketUnitMeasurment.Name;
        
    }
}
