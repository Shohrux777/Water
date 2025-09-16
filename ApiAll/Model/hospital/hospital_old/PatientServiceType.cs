using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiAll.Model
{
    public class PatientServiceType : BaseModel
    {
        public String Name { get; set; }
    }
}
