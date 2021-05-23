using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
   public class Repair:BaseAuditObject
    {
        public int RepairID { get; set; }
        public int VehicleID { get; set; }
        public int Rental_ReturnID { get; set; }
        public string ResponsibleCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal Costs { get; set; } = 0.00M;
        public string Description { get; set; }
        public bool IsRepaired { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Rental_Return Rental_Return { get; set; }

        // String Concatination
        public string VehicleInfos { get; set; }
        public string StringRepairID { get; set; }
        public string StringStartDate { get; set; }
        public string StringReturnDate { get; set; }

        public void init()
        {
            VehicleInfos = $"{Vehicle.VehicleBrand.Make} {Vehicle.VehicleBrand.Model}";
            StringRepairID = $"#{this.RepairID}";
            StringStartDate = StartDate.ToString("d MMM");
            StringReturnDate = ReturnDate != DateTime.MinValue ? ReturnDate.ToString("d MMM") : null;
        }
    }
}
