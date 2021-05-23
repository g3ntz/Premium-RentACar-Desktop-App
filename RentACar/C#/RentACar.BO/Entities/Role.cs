using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class Role:BaseAuditObject
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // String Concatination

        public string StringRoleID { get; set; }

        public void init()
        {
            StringRoleID = $"#{this.RoleID}";
        }
    }
}
