using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;


namespace RentACar.BO.Entities
{
    public class Booking:BaseAuditObject
    {
        public int BookingID { get; set; }
        public decimal TotalPrice { get; set; } = 00.00M;
        public DateTime BookingDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ClientID { get; set; }
        public int VehicleID { get; set; }
        public int BookingStatusID { get; set; }

        public virtual Client Client { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }

        // String Concationation
        public string StringBookingID { get; set; }
        public string StringBookingDate { get; set; }
        public string StringRentalDate { get; set; }
        public string StringReturnDate { get; set; }
        public string clientInfos { get; set; }
        public string vehicleInfos { get; set; }
        public string statusName { get; set; }

        public void init()
        {
            StringBookingID = $"#{this.BookingID}";
            clientInfos = $"{Client.Name} {Client.Surname}";
            vehicleInfos = $"{Vehicle.VehicleBrand.Make} {Vehicle.VehicleBrand.Model}";
            statusName = $"{BookingStatus.StatusName}";
            StringBookingDate = BookingDate.ToString("d MMM");
            StringRentalDate = RentalDate.ToString("d MMM");
            StringReturnDate = ReturnDate.ToString("d MMM");
        }
    }
}
