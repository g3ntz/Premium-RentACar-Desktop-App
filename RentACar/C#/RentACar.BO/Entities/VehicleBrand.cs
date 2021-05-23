using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class VehicleBrand:BaseAuditObject
    {
        public int VehicleBrandID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
    }
}
