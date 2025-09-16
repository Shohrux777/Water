using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.tekistil
{
    [Table("tex_sub_proccess")]
    public class TexSubProccess : TekstilBaseModel
    {

        public String name { get; set; }

    }
}
