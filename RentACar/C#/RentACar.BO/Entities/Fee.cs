using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class Fee:BaseAuditObject
    {
        public int FeeID { get; set; }
        public int returnID { get; set; }
        public string Reason { get; set; }
        public Decimal Costs { get; set; } = 00.00M;
        public bool IsPaid { get; set; }
        public bool IsLate { get; set; }
        public DateTime returnDate { get; set; }

        public virtual Rental_Return Return { get; set; }
    }
}
