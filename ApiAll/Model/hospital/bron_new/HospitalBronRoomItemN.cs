using System.Collections.Generic;

namespace ApiAll.Model.hospital.bron_new
{
    public class HospitalBronRoomItemN: HospitalBaseStandartModel
    {
        public HospitalBronRoomN hospitalBronRoom { get; set; }
        public long HospitalBronRoomNid { get; set; }
        public string name { get; set; }
        public ServiceType serviceType { get; set; }
        public long? ServiceTypeId { get; set; }
        public long reserved_number_1 { get; set; } = 0;
        public long reserved_number_2 { get; set; } = 0;
        public long reserved_number_3 { get; set; } = 0;
        public long reserved_number_4 { get; set; } = 0;
        public long reserved_number_5 { get; set; } = 0;

        public string reserved_name_1 { get; set; }
        public string reserved_name_2 { get; set; }
        public string reserved_name_3 { get; set; }
        public string reserved_name_4 { get; set; }
        public string reserved_name_5 { get; set; }

        public double reserved_number_db_1 { get; set; } = 0.0;
        public double reserved_number_db_2 { get; set; } = 0.0;
        public double reserved_number_db_3 { get; set; } = 0.0;
        public double reserved_number_db_4 { get; set; } = 0.0;
        public double reserved_number_db_5 { get; set; } = 0.0;

        public bool reserved_status_1 { get; set; } = false;
        public bool reserved_status_2 { get; set; } = false;
        public bool reserved_status_3 { get; set; } = false;
        public bool reserved_status_4 { get; set; } = false;
        public bool reserved_status_5 { get; set; } = false;

    }
}
