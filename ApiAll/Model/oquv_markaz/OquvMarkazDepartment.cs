using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_department")]
    public class OquvMarkazDepartment:OquvMarkazBaseModel
    {
        public long OquvMarkazCompanyid { get; set; }
        public OquvMarkazCompany company { get; set; }
        public String name { get; set; }
    }
}
