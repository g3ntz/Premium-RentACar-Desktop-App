using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class BookingStatus:BaseAuditObject
    {
        public int BookingStatusID { get; set; }
        public string StatusName { get; set; }
    }
}
