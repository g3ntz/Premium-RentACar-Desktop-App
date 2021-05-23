using RentACar.BLL;
using RentACar.BO.Entities;
using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.UserForms.Reservations
{
    public partial class FrmFullDetails : Form
    {
        int bookingID;

        bool rentalButton = false;
        bool returnButton = false;

        BookingsBLL bookingBLL = new BookingsBLL();
        RentalBLL rentalBLL = new RentalBLL();
        ReturnBLL returnBLL = new ReturnBLL();
        FeeBLL feeBLL = new FeeBLL();

        //-------Booking
        public FrmFullDetails(FrmDashboard frm, int bookingID)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480, frm.Location.Y + 200);
            this.bookingID = bookingID;
            validateForm(bookingID);
            changeIndicatorPosition(btnBookingsPage);
        }

        //-------Rental Or Return
        public FrmFullDetails(FrmDashboard frm, int rentalID, bool isRental)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480, frm.Location.Y + 200);

            if (isRental)
            {
                Rental_Return rental = rentalBLL.Get(rentalID);
                validateForm(rental.BookingID);
                bunifuPages1.SetPage(1);
                changeIndicatorPosition(btnRentalsPage);
            }
            else
            {
                Rental_Return Return = returnBLL.Get(rentalID);
                validateForm(Return.BookingID);
                bunifuPages1.SetPage(2);
                changeIndicatorPosition(btnReturnsPage);
            }
        }

        void validateForm(int bookingID)
        {
            List<Rental_Return> rentals = new List<Rental_Return>();
            List<Rental_Return> returns = new List<Rental_Return>();
            rentals = rentalBLL.GetAll().Where(x => x.BookingID == bookingID).ToList();
            returns = returnBLL.GetAll().Where(x => x.BookingID == bookingID).ToList();

            if(rentals.Any())
            {
                rentalButton = true;
                initRental(rentals[0].Rental_ReturnID);
            }
            if (returns.Any())
            {
                returnButton = true;
                initReturn(returns[0].Rental_ReturnID);
            }
            initBooking(bookingID);
        }


        void initBooking(int bookingID)
        {
            Booking booking = bookingBLL.Get(bookingID);
            BookingIDValue.Text = $"#{booking.BookingID}";
            BookingDateValue.Text = booking.BookingDate.ToString("dd/MM");
            lblClient.Text += $"  #{booking.ClientID}";
            lblVehicle.Text += $"  #{booking.VehicleID}";
            ClientInfos.Text = $"{booking.clientInfos}";
            VehicleInfos.Text = $"{booking.vehicleInfos}";
            FromValue.Text = booking.RentalDate.ToString("dd/MM");
            ToValue.Text = booking.ReturnDate.ToString("dd/MM");
            lblPrice.Text = booking.TotalPrice.ToString();
        }

        void initRental(int rentalID)
        {
            Rental_Return rental = rentalBLL.Get(rentalID);
            Booking booking = bookingBLL.Get(rental.BookingID);

            RentalBookingIDValue.Text = $"#{booking.BookingID}";
            RentalDateValue.Text = rental.Date.ToString("dd/MM");
            lblRentalClient.Text += $"  #{booking.ClientID}";
            lblRentalVehicle.Text += $"  #{booking.VehicleID}";
            RentalClientInfos.Text = booking.clientInfos;
            RentalVehicleInfos.Text = booking.vehicleInfos;
            FuelAmountValue.Text = rental.FuelAmount.ToString() + "L";
            MileageValue.Text = rental.Mileage;
            RentalFromValue.Text = booking.RentalDate.ToString("dd/MM");
            RentalToValue.Text = booking.ReturnDate.ToString("dd/MM");
            txtVehicleCondition.Text = rental.VehicleActualConditionRental_Return;
            RentalPriceValue.Text = booking.TotalPrice.ToString();
        }

        void initReturn(int returnID)
        {
            Rental_Return Return = returnBLL.Get(returnID);
            Booking booking = bookingBLL.Get(Return.BookingID);
            List<Fee> lateFees = new List<Fee>();
            List<Fee> damageFees = new List<Fee>();

            lateFees = feeBLL.GetAll().Where(x => x.returnID == Return.Rental_ReturnID).Where(x => x.IsLate == true).ToList();
            damageFees = feeBLL.GetAll().Where(x => x.returnID == Return.Rental_ReturnID).Where(x => x.IsLate == false).ToList();

            Fee lateFee = lateFees.Any() == true ? lateFees[0] : null;
            Fee damageFee = damageFees.Any() == true ? damageFees[0] : null;

            ReturnBookingIDValue.Text = $"#{booking.BookingID}";
            ReturnDate.Text = Return.Date.ToString("dd/MM");
            ReturnClient.Text += $"  #{booking.ClientID}";
            ReturnVehicle.Text += $"  #{booking.VehicleID}";
            ReturnClientInfos.Text = booking.clientInfos;
            ReturnVehicleInfos.Text = booking.vehicleInfos;
            ReturnFuelAmount.Text = Return.FuelAmount.ToString() + "L";
            ReturnMileage.Text = Return.Mileage;
            txtReturnVehicleActualCondition.Text = Return.VehicleActualConditionRental_Return;
            txtDamageDetails.Text = damageFee != null ? damageFee.Reason : "";
            NormalPriceValue.Text = booking.TotalPrice.ToString();
            LateCostsValue.Text = lateFee != null ? decimal.Round(lateFee.Costs,2).ToString() : "0.00";
            DamagesValue.Text = damageFee != null ? decimal.Round(damageFee.Costs,2).ToString() : "0.00";

            TotalValue.Text = calculateTotal(NormalPriceValue.Text,LateCostsValue.Text,DamagesValue.Text);
            lblReturnedLater.Text = calculateReturnedLate(booking.ReturnDate, Return.Date);
            if (lblReturnedLater.Text != "")
                expectedDateValue.Text = booking.ReturnDate.ToString("dd/MM");
            else
            {
                lblExpectedReturnDate.Visible = false;
                expectedDateValue.Visible = false;
                bunifuSeparator28.Visible = false;
            }

        }

        private string calculateTotal(string NormalPrice, string LateCosts, string Damages )
        {
            decimal total = decimal.Parse(NormalPrice) + decimal.Parse(LateCosts) + decimal.Parse(Damages);
            return decimal.Round(total, 2).ToString();
        }

        private string calculateReturnedLate(DateTime expectedReturnDate, DateTime returnedDate)
        {
            TimeSpan diff = returnedDate.Date - expectedReturnDate.Date;
            double daysLater = diff.TotalDays;

            if (daysLater <= 0)
                return "";
            else
                return daysLater == 1 ? $"Returned {daysLater} Day Later" : $"Returned {daysLater} Days Later";
        }

        private void changeIndicatorPosition(Control control)
        {
            reservationPageIndicator.Width = control.Width - 8;
            reservationPageIndicator.Left = control.Location.X + 5;
        }

        private void btnBookingsPage_Click(object sender, EventArgs e)
        {
            if (bunifuPages1.PageName != "Reservations")
            {
                bunifuPages1.SetPage(0);
                changeIndicatorPosition(btnBookingsPage);
            }
        }

        private void btnRentalsPage_Click(object sender, EventArgs e)
        {
            if(rentalButton)
            {
                if (bunifuPages1.PageName != "Rentals")
                {
                    bunifuPages1.SetPage(1);
                    changeIndicatorPosition(btnRentalsPage);
                }
            }
            else
                MessageBox.Show("Rental doesn't exist");
        }

        private void btnReturnsPage_Click(object sender, EventArgs e)
        {
            if(returnButton)
            {
                if (bunifuPages1.PageName != "Returns")
                {
                    bunifuPages1.SetPage(2);
                    changeIndicatorPosition(btnReturnsPage);
                }
            }
            else
                MessageBox.Show("Return doesn't exist");
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
