using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;

namespace RentACar.UserForms.Vehicles
{
    public partial class FrmVehiclesCRUD : Form
    {
        int vehicleID;
        BunifuDataGridView dgVehicles = null;
        VehicleBLL vehicleBLL = new VehicleBLL();
        VehicleBrandBLL vehicleBrandBLL = new VehicleBrandBLL();
        FrmDashboard frmDashboard;

        //----UPDATE
        public FrmVehiclesCRUD(FrmDashboard frm,BunifuDataGridView dgVehicles, int vehicleID)
        {
            InitializeComponent();
            this.vehicleID = vehicleID;
            this.dgVehicles = dgVehicles;
            this.frmDashboard = frm;
            initDropDownMake();
            bool result = readVehicleByID(vehicleID);
            customizeVehicleRegistrationDate();
            btnVehiclesClear.ToolTipText = "Refresh";
            lblCondition.Visible = true;
        }

        //-----ADD
        public FrmVehiclesCRUD(FrmDashboard frm, BunifuDataGridView dgVehicles)
        {
            InitializeComponent();
            this.dgVehicles = dgVehicles;
            this.frmDashboard = frm;
            initDropDownMake();
            customizeVehicleRegistrationDate();
        }

        private void customizeVehicleRegistrationDate()
        {
            dpVehicleRegistrationDate.MinDate = DateTime.Today.AddYears(-1).AddDays(7);
            dpVehicleRegistrationDate.MaxDate = DateTime.Today;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void saveChanges()
        {
            Vehicle vehicle = initVehicle();
            bool result;
            if (vehicleID == 0)
            {
                result = vehicleBLL.Add(vehicle);
                refreshData();
            }
            else
            {
                result = vehicleBLL.Modify(vehicle);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        private void refreshData()
        {
            var vehicles = vehicleBLL.GetAll();
            dgVehicles.DataSource = vehicles;
        }

        private bool readVehicleByID(int vehicleID)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = vehicleBLL.Get(vehicleID);
            if (vehicle != null)
            {
                ddMake.SelectedItem = vehicle.VehicleBrand.Make;
                ddModel.SelectedItem = vehicle.VehicleBrand.Model;
                ddCategory.SelectedItem = vehicle.VehicleBrand.Category;
                dpVehicleRegistrationDate.Value = vehicle.VehicleRegistration.RegistrationDate;
                txtDailyPrice.Text = vehicle.DailyPrice.ToString();
                ddTransmission.SelectedItem = vehicle.Transmission;
                numProductionYear.Value = vehicle.ProductionYear;
                txtPlateNr.Text = vehicle.PlateNr;
                numSeatsNr.Value = vehicle.SeatsNr;
                txtOtherInfos.Text = vehicle.OtherInfos;
                ddFuelType.SelectedItem = vehicle.FuelType;
                txtFuelAmount.Text = vehicle.FuelAmount.ToString();
                txtVehicleActualCondition.Text = vehicle.VehicleActualCondition;
                txtMileage.Text = vehicle.Mileage;
                if(vehicle.InGoodCondition)
                {
                    lblCondition.Text = "Good Condition";
                    lblCondition.ForeColor = Color.Green;
                }
                else
                {
                    lblCondition.Text = "Bad Condition";
                    lblCondition.ForeColor = Color.Red;
                }
                return true;
            }
            return false;
        }

        private Vehicle initVehicle()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.VehicleID = this.vehicleID;
            vehicle.VehicleBrand = new VehicleBrand();
            vehicle.VehicleRegistration = new VehicleRegistration();
            vehicle.VehicleBrand.Make = ddMake.SelectedItem.ToString();
            vehicle.VehicleBrand.Model = ddModel.SelectedItem.ToString();
            vehicle.VehicleBrand.Category = ddCategory.SelectedItem.ToString();

            vehicle.VehicleRegistration.RegistrationDate = dpVehicleRegistrationDate.Value;

            vehicle.DailyPrice = decimal.Parse(txtDailyPrice.Text);
            vehicle.Transmission = ddTransmission.SelectedItem.ToString();
            vehicle.ProductionYear = (int)numProductionYear.Value;
            vehicle.PlateNr = txtPlateNr.Text;
            vehicle.SeatsNr = (int)numSeatsNr.Value;
            vehicle.FuelType = ddFuelType.SelectedItem.ToString();
            vehicle.FuelAmount = decimal.Parse(txtFuelAmount.Text);
            vehicle.VehicleActualCondition = txtVehicleActualCondition.Text;
            vehicle.Mileage = txtMileage.Text;
            vehicle.OtherInfos = txtOtherInfos.Text;
            vehicle.InsertBy = UserSession.CurrentUser.UserID;
            vehicle.IsAvailable = true;
            return vehicle;
        }

        private void ddMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            initModelByMake();
        }

        private void ddModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            initCategoryByMake();
        }

        public void initDropDownMake()
        {
            ddMake.Items.Clear();
            var distinctMakeList = vehicleBrandBLL.GetAll().Select(x => x.Make).Distinct().ToList();
            foreach (var item in distinctMakeList)
            {
                ddMake.Items.Add(item);
            }
        }

        private void initModelByMake()
        {
            ddModel.Items.Clear();
            string selectedMake = ddMake.SelectedItem.ToString();
            var distinctModelList = vehicleBrandBLL.GetAll().Where(x => x.Make == selectedMake).Select(x => x.Model).Distinct().ToList();

            foreach (var item in distinctModelList)
            {
                ddModel.Items.Add(item);
            }
            if (ddModel.Items != null)
                ddModel.SelectedIndex = 0;
        }

        private void initCategoryByMake()
        {
            ddCategory.Items.Clear();
            string selectedModel = ddModel.SelectedItem.ToString();
            string selectedMake = ddMake.SelectedItem.ToString();
            List<VehicleBrand> customList = vehicleBrandBLL.GetAll().Where(x => x.Make == selectedMake && x.Model == selectedModel).ToList();
            foreach (var item in customList)
            {
                ddCategory.Items.Add(item.Category);
            }
            if (ddCategory.Items != null)
                ddCategory.SelectedIndex = 0;
        }

        private void llAddNewBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmVehicleBrandCRUD frmVehicleBrand = new FrmVehicleBrandCRUD(this);
            frmVehicleBrand.Show();
        }

        private void btnVehiclesClear_Click(object sender, EventArgs e)
        {
            if (vehicleID == 0)
            {
                foreach (Control control in this.Controls)
                {
                    string test = control.GetType().ToString();
                    if (control.GetType().ToString() == "Bunifu.UI.WinForms.BunifuTextBox")
                    {
                        BunifuTextBox txt = (BunifuTextBox)control;
                        txt.Clear();
                    }
                }
            }
            else
                readVehicleByID(vehicleID);
        }
    }
}
