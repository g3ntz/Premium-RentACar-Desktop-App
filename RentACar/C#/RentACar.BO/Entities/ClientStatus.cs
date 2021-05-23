using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    class ClientStatus:BaseAuditObject
    {
        public int ClientStatusID { get; set; }
        public string StatusName { get; set; }
    }
}
