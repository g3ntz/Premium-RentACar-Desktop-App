using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RentACar.UserForms.Maintenances
{
    public partial class FrmMaintenancesCRUD : Form
    {
        int maintenanceID;
        public int vehicleID;

        BunifuDataGridView dgMaintenances = null;
        MaintenancesBLL maintenanceBLL = new MaintenancesBLL();
        FrmDashboard frmDashboard;

        public FrmMaintenancesCRUD(int maintenanceID, BunifuDataGridView dgMaintenances,FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480, frm.Location.Y + 200);
            this.maintenanceID = maintenanceID;
            this.dgMaintenances = dgMaintenances;
            this.frmDashboard = frm;
            bool result = readMaintenanceByID(this.maintenanceID);
        }

        public FrmMaintenancesCRUD(BunifuDataGridView dgMaintenances,FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480 , frm.Location.Y + 200);
            this.dgMaintenances = dgMaintenances;
            this.frmDashboard = frm;
            customizeDatePickerFromToday();
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

        private void rbYes_Click(object sender, EventArgs e)
        {
            dpReturnDate.Enabled = true;
            dpReturnDate.IconColor = Color.Teal;
        }

        private void rbNo_Click(object sender, EventArgs e)
        {
            dpReturnDate.Enabled = false;
            dpReturnDate.IconColor = Color.Gray;
        }

        private void btnChooseVehicle_Click(object sender, EventArgs e)
        {
            FrmChooseVehicle frmChooseVehicle = new FrmChooseVehicle(this);
            frmChooseVehicle.Show();
        }

        //----------User Methods----------
        private void saveChanges()
        {
            Maintenance maintenance = InitMaintenance();
            bool result;
            if (maintenanceID == 0)
            {
                result = maintenanceBLL.Add(maintenance);
                refreshData();
            }
            else
            {
                result = maintenanceBLL.Modify(maintenance);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        public void updateLblVehicle(string vehicleInfo)
        {
            lblVehicle.Text = vehicleInfo;
        }

        public void storeVehicleID(int vehicleID)
        {
            this.vehicleID = vehicleID;
        }

        public void updateButton()
        {
            btnChooseVehicle.ButtonText = "Change Vehicle";
            btnChooseVehicle.IdleForecolor = Color.White;
            btnChooseVehicle.IdleFillColor = Color.DodgerBlue;
            btnChooseVehicle.IdleLineColor = Color.White;
            btnChooseVehicle.ActiveLineColor = Color.Indigo;
            btnChooseVehicle.ActiveFillColor = Color.DodgerBlue;
            btnChooseVehicle.ActiveForecolor = Color.White;
        }

        private void refreshData()
        {
            dgMaintenances.DataSource = maintenanceBLL.GetAll();
        }

        private Maintenance InitMaintenance()
        {
            Maintenance maintenance = new Maintenance();
            maintenance.MaintenanceID = this.maintenanceID;
            maintenance.VehicleID = vehicleID;
            maintenance.ResponsibleCompany = txtResponsibleCompany.Text;
            maintenance.Description = txtDescription.Text;
            if (txtCosts.Text.Trim() != "")
                maintenance.Costs = decimal.Parse(txtCosts.Text);
            maintenance.StartDate = dpStartDate.Value;
            if (rbYes.Checked)
                maintenance.ReturnDate = dpReturnDate.Value;
            maintenance.InsertBy = UserSession.CurrentUser.UserID;
            return maintenance;
        }

        public bool readMaintenanceByID(int maintenanceID)
        {
            Maintenance maintenance = new Maintenance();
            maintenance = maintenanceBLL.Get(maintenanceID);
            if (maintenance != null)
            {
                customizeDatePicker(maintenance);
                txtResponsibleCompany.Text = maintenance.ResponsibleCompany;
                txtDescription.Text = maintenance.Description;
                txtCosts.Text = maintenance.Costs.ToString();
                dpStartDate.Value = maintenance.StartDate;
                lblVehicle.Text = "Selected Vehicle: " + maintenance.Vehicle.VehicleBrand.Make + " | " + maintenance.Vehicle.VehicleBrand.Model;
                this.vehicleID = maintenance.VehicleID;
                updateButton();
                return true;
            }
            return false;
        }

        private void customizeDatePickerFromToday()
        {
            dpStartDate.MinDate = DateTime.Today;
            dpReturnDate.MinDate = dpStartDate.Value.AddDays(1).Date;
        }

        private void customizeDatePicker(Maintenance maintenance)
        {
            if (maintenance.ReturnDate != DateTime.MinValue)
            {
                rbYes.Checked = true;
                rbNo.Enabled = false;
                rbNo.Checked = false;
                dpReturnDate.Enabled = true;
                dpReturnDate.Value = maintenance.ReturnDate.Date;
            }
            else
            {
                rbNo.Checked = true;
                rbYes.Checked = false;
                dpReturnDate.Enabled = false;
            }
        }

        private void rbCostsNo_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = false;
        }

        private void rbCostsYes_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dpStartDate_ValueChanged(object sender, EventArgs e)
        {
            customizeDatePickerFromToday();
        }
    }
}
