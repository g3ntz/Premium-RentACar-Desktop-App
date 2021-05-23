using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class VehicleRegistration:BaseAuditObject
    {
        public int VehicleRegistrationID { get; set; }
        public DateTime  RegistrationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
