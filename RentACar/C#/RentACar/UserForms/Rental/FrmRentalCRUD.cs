using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimToo;
using RentACar.UIHelper;

namespace RentACar.UserForms.Rental
{
    public partial class FrmRentalCRUD : Form
    {
        private int bookingID;

        BookingsBLL bookingBLL = new BookingsBLL();
        RentalBLL rentalBLL = new RentalBLL();
        VehicleBLL vehicleBLL = new VehicleBLL();
        ClientBLL clientBLL = new ClientBLL();
        BunifuSnackbar bunifuSnackBar = new BunifuSnackbar();
        EasyHTMLReports easyHtmlReports;
        FrmDashboard frmDashboard;

        BunifuDataGridView dgBookings = null;
        public FrmRentalCRUD(FrmDashboard frm,int bookingID, BunifuDataGridView dgBookings,EasyHTMLReports easyHtml)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.dgBookings = dgBookings;
            this.easyHtmlReports = easyHtml;
            this.frmDashboard = frm;
            initPage();
        }

        void initPage()
        {
            Booking booking = bookingBLL.Get(this.bookingID);
            Vehicle vehicle = vehicleBLL.Get(booking.VehicleID);
            Client client = clientBLL.Get(booking.ClientID);

            bookingIDValue.Text = $"#{booking.BookingID}";
            ClientValue.Text = $"{client.Name} {client.Surname}";
            VehicleValue.Text = $"{vehicle.StringVehicleMake} {vehicle.StringVehicleModel}";
            FuelAmountValue.Text = vehicle.FuelAmount.ToString();
            MileageValue.Text = vehicle.Mileage;
            PriceValue.Text = booking.TotalPrice.ToString();
            txtVehicleCondition.Text = vehicle.VehicleActualCondition;
            FromValue.Text = booking.RentalDate.ToString("dd/MM");
            ToValue.Text = booking.ReturnDate.ToString("dd/MM");
        }

        private Rental_Return initRental()
        {
            Rental_Return rental = new Rental_Return();
            rental.Booking = new Booking();
            rental.BookingID = this.bookingID;
            rental.IsRental = true;
            rental.VehicleActualConditionRental_Return = txtVehicleCondition.Text;
            rental.InsertBy = UserSession.CurrentUser.UserID;
            return rental;
        }

        private void saveChanges()
        {
            Rental_Return rental = initRental();
            bool result = rentalBLL.Add(rental);
            refreshData();
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this,"Rental is Created");
        }

        private void refreshData()
        {
            var rentals = rentalBLL.GetAll();
            dgBookings.DataSource = bookingBLL.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Booking booking = bookingBLL.Get(bookingID);
            Client client = clientBLL.Get(booking.ClientID);
            Vehicle vehicle = vehicleBLL.Get(booking.VehicleID);

            DataTable clients = new DataTable();
            clients.Columns.Add("ID");
            clients.Columns.Add("Name");
            clients.Columns.Add("Surname");
            clients.Rows.Add($"#{client.ClientID}", client.Name, client.Surname);

            DataTable vehicles = new DataTable();
            vehicles.Columns.Add("ID");
            vehicles.Columns.Add("Make");
            vehicles.Columns.Add("Model");
            vehicles.Columns.Add("Fuel Amount");
            vehicles.Columns.Add("Mileage");
            vehicles.Rows.Add($"#{vehicle.VehicleID}", vehicle.VehicleBrand.Make, vehicle.VehicleBrand.Model, $"{ vehicle.FuelAmount}L", vehicle.Mileage);

            printInvoice(booking, client, vehicle, clients, vehicles);
        }

        private void printInvoice(Booking booking,Client client,Vehicle vehicle,DataTable clients,DataTable vehicles)
        {
            easyHtmlReports.Clear();
            easyHtmlReports.AddImage(Properties.Resources.Logo2);
            easyHtmlReports.AddString("<h1 style=\"text-align:right;margin-top:-70px;\">RENTAL INVOICE</h1>");
            easyHtmlReports.AddString($"<h4 style=\"text-align:right;margin-top:-15px;\">Invoice Date: {DateTime.Today.ToShortDateString()}</h4>");
            easyHtmlReports.AddLineBreak();
            easyHtmlReports.AddString("<h3>Client:</h3>");
            easyHtmlReports.AddDataTable(clients);
            easyHtmlReports.AddString("<h3>Vehicle:</h3>");
            easyHtmlReports.AddDataTable(vehicles);
            easyHtmlReports.AddLineBreak();
            easyHtmlReports.AddLineBreak();
            easyHtmlReports.AddString("<h3>Vehicle Actual Condition:</h3>");
            easyHtmlReports.AddString($"<h5 style=\" font-weight:normal; font-family:Verdana; padding:5px; border: 1px solid black; width:420px; height:70px; background-color:#B9DCE8; \">{vehicle.VehicleActualCondition} </h5>");
            easyHtmlReports.AddLineBreak();
            easyHtmlReports.AddLineBreak();
            easyHtmlReports.AddString("<h5 style=\" color:red; font-weight:normal; font-family:Verdana; \">Terms and Conditions:</br>" +
                $"Me {client.Name} {client.Surname},agree that I will pay for every damage</br>" +
                "that is not included in this invoice and for every late return day</h5>");
            easyHtmlReports.AddString($"<h4 style=\" text-align:right; margin-top:-80px; \" >Rented At: {booking.RentalDate.ToString("MMMM dd")}</h4>");
            easyHtmlReports.AddString($"<h4 style=\" text-align:right; margin-top:-10px; \">Has to Return: {booking.ReturnDate.ToString("MMMM dd")}</h4>" +
                $"<h3 style=\" color:green; margin-top:40px; text-align:right; font-size:40px; \" >Price: {booking.TotalPrice}</h3>");
            easyHtmlReports.AddString("<h3 style=\" margin-top:-50px; \" >Signature:</br></h3><hr style=\" width:150px; text-align:left; \">");

            easyHtmlReports.ShowPrintPreviewDialog();
        }
    }
}
