using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class Vehicle:BaseAuditObject
    {
        public int VehicleID { get; set; }
        public int VehicleBrandID { get; set; }
        public int VehicleRegistrationID { get; set; }
        public string Transmission { get; set; }
        public int ProductionYear { get; set; }
        public decimal DailyPrice { get; set; } = 00.00M;
        public string PlateNr { get; set; }
        public int SeatsNr { get; set; }
        public string OtherInfos { get; set; }
        public bool IsAvailable { get; set; }
        public string FuelType { get; set; }
        public decimal FuelAmount { get; set; }
        public string VehicleActualCondition { get; set; }
        public bool InGoodCondition { get; set; }
        public string Mileage { get; set; }

        public VehicleBrand VehicleBrand { get; set; }
        public VehicleRegistration VehicleRegistration { get; set; }


        // String Concatination

        public string StringVehicleID { get; set; }
        public string StringVehicleMake { get; set; }
        public string StringVehicleModel { get; set; }
        public string StringVehicleCategory { get; set; }
        public string StringVehicleRegistrationDate { get; set; }
        public string StringVehicleExpirationDate { get; set; }
        public string StringFuelAmount { get; set; }
        public string StringRegDaysLeft { get; set; }

        public void init()
        {
            StringVehicleID = $"#{this.VehicleID}";
            StringVehicleMake = this.VehicleBrand.Make;
            StringVehicleModel = this.VehicleBrand.Model;
            StringVehicleCategory = this.VehicleBrand.Category;
            StringVehicleRegistrationDate = this.VehicleRegistration.RegistrationDate.ToString();
            StringVehicleExpirationDate = this.VehicleRegistration.ExpirationDate.ToString();
            StringFuelAmount = $"{this.FuelAmount}L";
            TimeSpan diff = VehicleRegistration.ExpirationDate - DateTime.Today;
            if (diff.TotalDays > 0)
                StringRegDaysLeft = diff.TotalDays == 1 ? $"{diff.TotalDays} Day Left" : $"{diff.TotalDays} Days Left";
            else
                StringRegDaysLeft = "Expired";
        }
    }
}
