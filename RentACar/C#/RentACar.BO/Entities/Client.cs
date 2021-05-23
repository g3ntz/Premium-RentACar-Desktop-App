using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class Client:BaseAuditObject
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public DateTime Birthdate{ get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneNr{ get; set; }
        public string DrivingLicense{ get; set; }
        public string Email{ get; set; }

        // String Concatination 

        public string StringID { get; set; }
        public string StringBirthDate { get; set; }

        public void init()
        {
            StringID = $"#{this.ClientID}";
            StringBirthDate = this.Birthdate.ToString("dd-MMMM-yyyy");
            Age = DateTime.Today.Year - Birthdate.Year;
        }
    }
}
