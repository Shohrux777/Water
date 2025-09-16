using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_smenam")]
    public class SkudSmena
    {
        [Key]
        public String smena_nomi { get; set; }

        [DataType(DataType.Time)]
        public DateTime boshlanishi { get; set; }

        [DataType(DataType.Time)]
        public DateTime tugashi { get; set; }   
        
        [DataType(DataType.Time)]
        public DateTime obed_b { get; set; }

        [DataType(DataType.Time)]
        public DateTime obed_t { get; set; }

        [DataType(DataType.Time)]
        public DateTime kech_keldi { get; set; }    
        
        [DataType(DataType.Time)]
        public DateTime vox_ketdi { get; set; }

 
    }
}
