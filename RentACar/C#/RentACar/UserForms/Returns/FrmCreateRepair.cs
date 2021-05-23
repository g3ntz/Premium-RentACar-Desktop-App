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
    public partial class FrmCreateRepair : Form
    {
        int vehicleID;
        int returnID;

        ReturnBLL returnBLL = new ReturnBLL();
        BookingsBLL bookingBLL = new BookingsBLL();
        VehicleBLL vehicleBLL = new VehicleBLL();
        RepairsBLL repairBLL = new RepairsBLL();

        FrmDashboard frmDashboard;

        public FrmCreateRepair(FrmDashboard frm,int returnID)
        {
            InitializeComponent();
            this.returnID = returnID;
            this.frmDashboard = frm;
            initVehicle();
            customizeDatePickers();
        }

        private void initVehicle()
        {
            Rental_Return Return = returnBLL.Get(this.returnID);
            Booking booking = bookingBLL.Get(Return.BookingID);
            Vehicle vehicle = vehicleBLL.Get(booking.VehicleID);
            this.vehicleID = vehicle.VehicleID;
            lblVehicle.Text = $"Vehicle: {vehicle.StringVehicleMake} {vehicle.StringVehicleModel}";
        }

        private void customizeDatePickers()
        {
            dpStartDate.MinDate = DateTime.Today;
            dpReturnDate.MinDate = DateTime.Today.AddDays(1);
        }

        private void rbCostsNo_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = false;
        }

        private void rbCostsYes_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = true;
        }

        private void rbReturnDateNo_Click(object sender, EventArgs e)
        {
            dpReturnDate.Enabled = false;
            dpReturnDate.IconColor = Color.Gray;
        }

        private void rbReturnDateYes_Click(object sender, EventArgs e)
        {
            dpReturnDate.Enabled = true;
            dpReturnDate.IconColor = Color.Teal;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges(initRepair());
        }
        private Repair initRepair()
        {
            Repair repair = new Repair();
            repair.VehicleID = this.vehicleID;
            repair.Rental_ReturnID = this.returnID;
            repair.ResponsibleCompany = txtResponsibleCompany.Text;
            repair.Description = txtDescription.Text;
            repair.Costs = txtCosts.Text.Trim() != "" ? decimal.Parse(txtCosts.Text) : 0.00M;
            repair.StartDate = dpStartDate.Value;
            repair.ReturnDate = rbReturnDateYes.Checked == true ? dpReturnDate.Value : DateTime.MinValue;
            return repair;
        }
        private void saveChanges(Repair repair)
        {
            bool result = repairBLL.Add(repair);
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this,"Repair is Created.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
