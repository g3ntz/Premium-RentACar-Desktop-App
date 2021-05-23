using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class Maintenance:BaseAuditObject
    {
        public int MaintenanceID { get; set; }
        public int VehicleID { get; set; }
        public string ResponsibleCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Description { get; set; }
        public decimal Costs { get; set; }
        public bool IsReturned { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        // String Concatination
        public string VehicleInfos { get; set; }
        public string StringMaintenanceID { get; set; }
        public string StringStartDate { get; set; }
        public string StringReturnDate { get; set; }

        public void init()
        {
            VehicleInfos = VehicleID != 0 ? $"{Vehicle.VehicleBrand.Make} {Vehicle.VehicleBrand.Model}" : null;
            StringMaintenanceID = $"#{this.MaintenanceID}";
            StringStartDate = StartDate.ToString("d MMM");
            StringReturnDate = ReturnDate != DateTime.MinValue ? ReturnDate.ToString("d MMM") : null;
        }
    }
}
