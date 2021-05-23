using Bunifu.UI.WinForms;
using System;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using System.Windows.Forms;
using System.Drawing;
using RentACar.UserForms.Maintenances;
using RentACar.UIHelper;

namespace RentACar.UserForms.Repairs
{
    public partial class FrmRepairsCRUD : Form
    {
        int repairID;
        public int vehicleID;
        BunifuDataGridView dgRepairs = null;
        RepairsBLL repairBLL = new RepairsBLL();
        FrmDashboard frmDashboard;

        public FrmRepairsCRUD(int repairID, BunifuDataGridView dgRepairs,FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480, frm.Location.Y + 200);
            this.repairID = repairID;
            this.dgRepairs = dgRepairs;
            this.frmDashboard = frm;
            readRepairByID(this.repairID);
        }

        public FrmRepairsCRUD(BunifuDataGridView dgRepairs, FrmDashboard frm)
        {
            InitializeComponent();
            this.Location = new Point(frm.Location.X + 480, frm.Location.Y + 200);
            this.dgRepairs = dgRepairs;
            this.frmDashboard = frm;
            customizeDatePickersFromToday();
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

        private void rbReturnDateYes_Click(object sender, EventArgs e)
        {
            dpReturnDate.Enabled = true;
            dpReturnDate.IconColor = Color.Teal;
        }

        private void rbReturnDateNo_Click(object sender, EventArgs e)
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
            Repair repair = InitRepair();
            bool result;
            if (repairID == 0)
            {
                result = repairBLL.Add(repair);
                refreshData();
            }
            else
            {
                result = repairBLL.Modify(repair);
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
            dgRepairs.DataSource = repairBLL.GetAll();
        }

        private Repair InitRepair()
        {
            Repair repair = new Repair();
            repair.RepairID = this.repairID;
            repair.VehicleID = vehicleID;
            repair.ResponsibleCompany = txtResponsibleCompany.Text;
            repair.Description = txtDescription.Text;
            if (txtCosts.Text.Trim() != "")
                repair.Costs = decimal.Parse(txtCosts.Text);
            repair.StartDate = dpStartDate.Value;
            if (rbReturnDateYes.Checked)
                repair.ReturnDate = dpReturnDate.Value;
            repair.InsertBy = UserSession.CurrentUser.UserID;
            return repair;
        }

        public void readRepairByID(int maintenanceID)
        {
            Repair repair = new Repair();
            repair = repairBLL.Get(maintenanceID);
            customizeDatePicker(repair);
            customizeCosts(repair);
            txtResponsibleCompany.Text = repair.ResponsibleCompany;
            txtDescription.Text = repair.Description;
            dpStartDate.Value = repair.StartDate;
            lblVehicle.Text = "Selected Vehicle: " + repair.Vehicle.VehicleBrand.Make + " | " + repair.Vehicle.VehicleBrand.Model;
            this.vehicleID = repair.VehicleID;
            updateButton();
        }

        private void customizeDatePickersFromToday()
        {
            dpStartDate.MinDate = DateTime.Today;
            dpReturnDate.MinDate = dpStartDate.Value.AddDays(1).Date;
        }

        private void customizeDatePicker(Repair repair)
        {
            if (repair.ReturnDate != DateTime.MinValue)
            {
                rbReturnDateYes.Checked = true;
                rbReturnDateNo.Enabled = false;
                rbReturnDateNo.Checked = false;
                dpReturnDate.Enabled = true;
                dpReturnDate.Value = repair.ReturnDate.Date;
            }
        }

        private void customizeCosts(Repair repair)
        {
            if(repair.Costs != 0)
            {
                rbCostsNo.Checked = false;
                rbCostsYes.Checked = true;
                txtCosts.Enabled = true;
                txtCosts.Text = repair.Costs.ToString().Remove(repair.Costs.ToString().Length - 2, 2);
            }
        }

        private void rbCostsYes_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = true;
        }

        private void rbCostsNo_Click(object sender, EventArgs e)
        {
            txtCosts.Enabled = false;
        }

        private void dpStartDate_ValueChanged(object sender, EventArgs e)
        {
            customizeDatePickersFromToday();
        }
    }
}
