using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.UserForms.Returns
{
    public partial class FrmReturnCRUD : Form
    {
        int rentalID;
        int bookingID;

        public Fee lateFee;
        BunifuDataGridView dgRentals = null;

        Rental_Return rental;
        Booking booking;

        // -----BLL
        RentalBLL rentalBLL = new RentalBLL();
        ReturnBLL returnBLL = new ReturnBLL();
        BookingsBLL bookingBLL = new BookingsBLL();
        VehicleBLL vehicleBLL = new VehicleBLL();

        FrmDashboard frmDashboard;

        public FrmReturnCRUD(FrmDashboard frm,int rentalID, BunifuDataGridView dgRentals)
        {
            InitializeComponent();
            this.rentalID = rentalID;
            this.dgRentals = dgRentals;
            this.frmDashboard = frm;
            rbDamagesYes.Checked = false;
            rbDamagesNo.Checked = true;
            initPage();
        }

        private void initPage()
        {
            rental = rentalBLL.Get(this.rentalID);
            booking = bookingBLL.Get(rental.BookingID);

            this.bookingID = rental.BookingID;
            BookingIDValue.Text = $"#{booking.BookingID}";
            ClientInfos.Text = $"{booking.clientInfos}";
            VehicleInfos.Text = $"{booking.vehicleInfos}";
            txtVehicleActualCondition.Text = rental.VehicleActualConditionRental_Return;
            ReturnDateValue.Text = booking.ReturnDate.ToString("dd/MM");
        }

        private Rental_Return initReturn()
        {
            Rental_Return Return = new Rental_Return();
            Return.Fee = new Fee();
            Return.BookingID = this.bookingID;
            Return.Date = DateTime.Now;
            Return.VehicleActualConditionRental_Return = txtVehicleActualCondition.Text;
            Return.FuelAmount = decimal.Parse(txtFuelAmount.Text);
            Return.Mileage = txtMileage.Text;
            Return.InsertBy = UserSession.CurrentUser.UserID;

            if(this.lateFee != null)
            {
                Return.Fee.returnDate = lateFee.returnDate;
                Return.Fee.IsPaid = lateFee.IsPaid;
                Return.Fee.IsLate = lateFee.IsLate;
                Return.Fee.Costs = lateFee.Costs;
                if (lateFee.returnDate != DateTime.Today)
                    Return.Date= lateFee.returnDate;
            }
            Return.Fee.Reason = txtDamages.Text.Trim() != "" ? txtDamages.Text : null;
            Return.Fee.returnID = this.rentalID;

            return Return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateDamage() != false)
            {
                saveChanges();
                dgRentals.DataSource = rentalBLL.GetAll();
                this.Close();
            }
        }

        private void saveChanges()
        {
            bool result = returnBLL.Add(initReturn());
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this,"Return is Created");
        }

        private void rbLateYes_Click(object sender, EventArgs e)
        {
            if (booking.ReturnDate.Date >= DateTime.Now.Date)
            {
                TimeSpan difference = booking.ReturnDate.Date - DateTime.Now.Date;
                double daysLater = difference.TotalDays;
                rbLateYes.Checked = false;
                rbLateNo.Checked = true;
                if (daysLater == 0)
                    MessageBox.Show($"The car from reservation is supposed to return today,there is no late");
                else
                    MessageBox.Show($"This return is not late,there are still {daysLater} days left available to return");
            }
            else
                llCalculateFee.Visible = true;
        }

        private void llCalculateFee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vehicle vehicle = vehicleBLL.Get(booking.VehicleID);
            FrmSetLateFee frmSetLateFee = new FrmSetLateFee(booking.ReturnDate, vehicle.DailyPrice, this);
            frmSetLateFee.Show();
        }

        private bool validateDamage()
        {
            if (txtDamages.Text.Trim() == "" && rbDamagesYes.Checked == true)
            {
                MessageBox.Show("The damage field cannot be empty,please click no if there is no damage");
                return false;
            }
            else
                return true;
        }

        private void rbDamagesYes_Click(object sender, EventArgs e)
        {
            txtDamages.Enabled = true;
        }

        private void rbDamagesNo_Click(object sender, EventArgs e)
        {
            txtDamages.Text = "";
            txtDamages.Enabled = false;
        }

        private void rbLateNo_Click(object sender, EventArgs e)
        {
            llCalculateFee.Visible = false;
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
