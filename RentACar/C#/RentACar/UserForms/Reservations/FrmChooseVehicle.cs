using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RentACar.UserForms.Reservations
{
    public partial class FrmChooseVehicle : Form
    {
        FrmReservationsCRUD frmReservations = null;
        VehicleBLL vehicleBLL = new VehicleBLL();
        int vehicleID;
        string vehicleInfo;

        public FrmChooseVehicle(FrmReservationsCRUD frmReservations)
        {
            InitializeComponent();
            dgVehicles.AutoGenerateColumns = false;
            this.frmReservations = frmReservations;
            dgVehicles.DataSource = vehicleBLL.GetAll().Where(x => x.IsAvailable == true).Where(x => x.InGoodCondition == true).ToList();
            ifEmpty();
        }
        private void ifEmpty()
        {
            if (dgVehicles.RowCount == 0)
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
            frmReservations.storeVehicleID(this.vehicleID);
            frmReservations.updateLblVehicle(this.vehicleInfo);
            frmReservations.updateBtnVehicle();
            frmReservations.calculatePrice();
            BunifuMessage.show(frmReservations, "Vehicle Added.", BunifuSnackbar.MessageTypes.Success, 800);
            this.Close();
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

        private void bunMinimizeIcon_Click_1(object sender, EventArgs e)
        {

        }
    }
}
