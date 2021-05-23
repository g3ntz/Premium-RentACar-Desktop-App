using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using RentACar.UserForms.Clients;
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
    public partial class FrmReservationsCRUD : Form
    {
        bool firstTime = true;
        bool isUpdate;
        Booking booking;

        BunifuDataGridView dgBookings = null;
        BunifuDataGridView dgVehicles = null;

        BookingsBLL bookingBLL = new BookingsBLL();
        VehicleBLL vehicleBLL = new VehicleBLL();
        FrmDashboard frmDashboard;


        //----- ADD
        public FrmReservationsCRUD(BunifuDataGridView dgBookings,FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 470, frm.Location.Y + 215);
            this.dgBookings = dgBookings;
            this.booking = new Booking();
            this.frmDashboard = frm;
            firstTime = false;
            customizeDates();
        }

        //----- UPDATE
        public FrmReservationsCRUD(BunifuDataGridView dgBookings,Booking booking,FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 470, frm.Location.Y + 215);
            this.dgBookings = dgBookings;
            this.booking = booking;
            this.frmDashboard = frm;
            isUpdate = true;
            customizeDates();
            readByID();
            calculatePrice();
        }

        //------ Reserve from vehicle
        public FrmReservationsCRUD(BunifuDataGridView dgVehicles,string vehicleInfos, FrmDashboard frm,int vehicleID)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 470, frm.Location.Y + 215);
            this.dgVehicles = dgVehicles;
            this.booking = new Booking();
            booking.VehicleID = vehicleID;
            booking.vehicleInfos = vehicleInfos;
            firstTime = false;
            customizeDates();
            updateBtnVehicle();
            updateLblVehicle($"Selected Vehicle: {booking.vehicleInfos}");
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveReservation_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void dpRentalDate_ValueChanged(object sender, EventArgs e)
        {
            if(firstTime != true)
            {
                calculatePrice();
                customizeDates();
            }
        }

        private void dpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (firstTime != true)
            {
                calculatePrice();
            }
        }

        private void readByID()
        {
            updateBtnClient();
            updateBtnVehicle();
            updateLblClient($"Selected Client: {booking.clientInfos}");
            updateLblVehicle($"Selected Vehicle: {booking.vehicleInfos}");
            dpRentalDate.Value = booking.RentalDate;
            dpReturnDate.Value = booking.ReturnDate.Date;
            firstTime = false;
        }

        public void calculatePrice()
        {
            Vehicle vehicle = vehicleBLL.Get(booking.VehicleID);

            DateTime from = dpRentalDate.Value;
            DateTime to = dpReturnDate.Value;

            TimeSpan diff = to.Date - from.Date;
            double days = diff.TotalDays;
            if (from.ToString() != to.ToString() && this.booking.VehicleID != 0 && to.Date > from.Date)
            {
                decimal price = vehicle.DailyPrice * (decimal)days;
                lblPrice.Text = Math.Round(price, 2).ToString();
            }
            else
                lblPrice.Text = "0.00";
        }

        private void customizeDates()
        {
            dpRentalDate.MinDate = DateTime.Today;
            dpReturnDate.MinDate = dpRentalDate.Value.AddDays(1).Date;
        }

        private void saveChanges()
        {
            Booking booking = initBooking();
            bool result;
            if (this.isUpdate == false)
            {
                result = bookingBLL.Add(booking);
                refreshData();
            }
            else
            {
                result = bookingBLL.Modify(booking);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        private Booking initBooking()
        {
            Booking booking = new Booking();
            booking.BookingID = this.booking.BookingID;
            booking.Client = new Client();
            booking.Vehicle = new Vehicle();
            booking.BookingStatus = new BookingStatus();

            booking.ClientID = this.booking.ClientID;
            booking.VehicleID = this.booking.VehicleID;
            booking.TotalPrice = decimal.Parse(lblPrice.Text);
            booking.RentalDate = dpRentalDate.Value;
            booking.ReturnDate = dpReturnDate.Value;
            booking.InsertBy = UserSession.CurrentUser.UserID;
            return booking;
        }

        private void refreshData()
        {
            if(dgBookings != null)
            {
                var bookings = bookingBLL.GetAll();
                dgBookings.DataSource = bookings;
            }
            else
            {
                var vehicles = vehicleBLL.GetAll();
                dgVehicles.DataSource = vehicles;
            }
        }


        //----------ADD CLIENT
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            FrmChooseClient frmChooseClient = new FrmChooseClient(this);
            frmChooseClient.Show();
        }

        public void updateLblClient(string clientInfo)
        {
            lblClient.Text = clientInfo;
        }

        public void storeClientID(int clientID)
        {
            this.booking.ClientID = clientID;
        }

        public void updateBtnClient()
        {
            btnAddClient.ButtonText = "Change Client";
            btnAddClient.IdleForecolor = Color.White;
            btnAddClient.IdleFillColor = Color.FromArgb(40, 96, 144);
            btnAddClient.IdleLineColor = Color.FromArgb(40, 96, 144);
            btnAddClient.ActiveLineColor = Color.FromArgb(40, 96, 144);
            btnAddClient.ActiveFillColor = Color.FromArgb(40, 96, 144);
            btnAddClient.ActiveForecolor = Color.White;
        }


        //----------ADD VEHICLE
        public void updateLblVehicle(string vehicleInfo)
        {
            lblVehicle.Text = vehicleInfo;
        }

        public void storeVehicleID(int vehicleID)
        {
            this.booking.VehicleID = vehicleID;
        }

        public void updateBtnVehicle()
        {
            btnAddVehicle.ButtonText = "Change Vehicle";
            btnAddVehicle.IdleForecolor = Color.White;
            btnAddVehicle.IdleFillColor = Color.FromArgb(40, 96, 144);
            btnAddVehicle.IdleLineColor = Color.FromArgb(40, 96, 144);
            btnAddVehicle.ActiveLineColor = Color.FromArgb(40, 96, 144);
            btnAddVehicle.ActiveFillColor = Color.FromArgb(40, 96, 144);
            btnAddVehicle.ActiveForecolor = Color.White;
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            FrmChooseVehicle frmChooseVehicle = new FrmChooseVehicle(this);
            frmChooseVehicle.Show();
        }

        private void llAddNewClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmClientsCRUD frmClients = new FrmClientsCRUD();
            frmClients.Show();
        }
    }
}
