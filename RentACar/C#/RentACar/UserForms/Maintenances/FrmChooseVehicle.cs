using RentACar.BLL;
using RentACar.UserForms.Repairs;
using System;
using System.Windows.Forms;
using System.Linq;
using RentACar.BO.Entities;
using System.Collections.Generic;
using System.Drawing;
using Bunifu.UI.WinForms;
using RentACar.App_Folder;

namespace RentACar.UserForms.Maintenances
{
    public partial class FrmChooseVehicle : Form
    {
        FrmMaintenancesCRUD frmMaintenances = null;
        FrmRepairsCRUD frmRepairs = null;
        VehicleBLL vehicleBLL = new VehicleBLL();
        int vehicleID;
        string vehicleInfo;

        public FrmChooseVehicle(FrmMaintenancesCRUD frmMaintenances)
        {
            InitializeComponent();
            dgVehicles.AutoGenerateColumns = false;
            this.frmMaintenances = frmMaintenances;
            dgVehicles.DataSource = vehicleBLL.GetAll().Where(x => x.IsAvailable == true).Where(x => x.InGoodCondition == true).ToList();
            ifEmpty();
        }

        public FrmChooseVehicle(FrmRepairsCRUD frmRepairs)
        {
            InitializeComponent();
            dgVehicles.AutoGenerateColumns = false;
            this.frmRepairs = frmRepairs;
            dgVehicles.DataSource = vehicleBLL.GetAll().Where(x => x.IsAvailable == true).ToList();
            ifEmpty();
        }

        private void ifEmpty()
        {
            if(dgVehicles.RowCount == 0)
            {
                lblTip.ForeColor = Color.Red;
                lblTip.Text = "No vehicles available";
            }
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
            if(frmRepairs == null)
            {
                frmMaintenances.storeVehicleID(this.vehicleID);
                frmMaintenances.updateLblVehicle(this.vehicleInfo);
                frmMaintenances.updateButton();
                BunifuMessage.show(frmMaintenances, "Vehicle Added.", BunifuSnackbar.MessageTypes.Success,800);
                this.Close();

            }
            else
            {
                frmRepairs.storeVehicleID(this.vehicleID);
                frmRepairs.updateLblVehicle(this.vehicleInfo);
                frmRepairs.updateButton();
                BunifuMessage.show(frmRepairs, "Vehicle Added.", BunifuSnackbar.MessageTypes.Success, 800); 
                this.Close();

            }
        }

        private void dgVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            lblTip.Text = "A Vehicle Is Selected,Click The Add Button To Add The Car";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgVehicles.Rows[e.RowIndex];
                vehicleID = int.Parse(row.Cells["StringVehicleID"].Value.ToString().Remove(0,1));
                vehicleInfo = "Selected Vehicle: " + row.Cells["Make"].Value.ToString() + " | " + row.Cells["Model"].Value.ToString();
            }
        }
    }
}
