using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class BaseAnalizModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [DefaultValue(true)]
        public bool ActiveStatus { get; set; } = true;
        public long PatientsId { get; set; }
        public Patients patients { get; set; }
        public DateTime regDateTime { get; set; } = DateTime.Now;
    }
}
