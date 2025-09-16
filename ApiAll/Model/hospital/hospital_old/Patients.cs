using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Patients : BaseModel
    {

        public String FIO { get; set; }
        public String PassportSerialNumber { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime RegistratedDate { get; set; } = DateTime.Now;
        //0 female 1 male
        public int PolType { get; set; }
        public String Address { get; set; }
        public String WorkAddress { get; set; }
        public DateTime UnregistratedDate { get; set; } = DateTime.Now;
        public String ReasonUnregistrated { get; set; }
        public String TreatmentPlaces { get; set; }
        public String TreatmentPlacesCurrentPlaces { get; set; }
        public String TreatmentPlacesOtherPlaces { get; set; }
        public long DistrictsId { get; set; }
        public Districts districts { get; set; }
        public long? chatBotId { get; set; }


    }
}
