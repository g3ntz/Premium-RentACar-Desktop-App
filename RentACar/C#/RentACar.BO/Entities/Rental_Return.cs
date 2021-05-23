using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
   public class Rental_Return:BaseAuditObject
    {
        public int Rental_ReturnID { get; set; }
        public int BookingID { get; set; }
        public int VehicleID { get; set; }
        public int ClientID { get; set; }
        public bool IsRental { get; set; }
        public bool IsClosed { get; set; }
        public DateTime Date { get; set; }
        public string VehicleActualConditionRental_Return{ get; set; }
        public decimal FuelAmount { get; set; }
        public string Mileage { get; set; }

        public bool hasDamage { get; set; }
        public bool returnedLate { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Fee Fee { get; set; }


        // String Concationation
        public string StringFuelAmount { get; set; }
        public string StringDate { get; set; }
        public string StringRental_ReturnID { get; set; }
        public string clientInfos { get; set; }
        public string vehicleInfos { get; set; }

        public void init()
        {
            StringRental_ReturnID = $"#{this.Rental_ReturnID}";
            VehicleID = Booking.VehicleID;
            ClientID = Booking.ClientID;
            clientInfos = Booking.clientInfos;
            vehicleInfos = Booking.vehicleInfos;
            StringFuelAmount = FuelAmount + "L";
            StringDate = Date.ToString("d MMM");
        }
    }
}
