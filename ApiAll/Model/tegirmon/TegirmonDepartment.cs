using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_department")]
    public class TegirmonDepartment : TegirmonBaseModel
    {
        public String name { get; set; }
        public long TegirmonCompanyid { get; set; }
        public TegirmonCompany company { get; set; }
    }
}
