using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using System;
using System.Windows.Forms;

namespace RentACar.UserForms.Vehicles
{
    public partial class FrmVehicleBrandCRUD : Form
    {
        FrmVehiclesCRUD frmVehicleBrand = null;
        VehicleBrandBLL vehicleBrandBLL = new VehicleBrandBLL();

        public FrmVehicleBrandCRUD(FrmVehiclesCRUD frmVehicleBrand)
        {
            this.frmVehicleBrand = frmVehicleBrand;
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
            BunifuMessage.show(frmVehicleBrand, "Vehicle Brand Added.", BunifuSnackbar.MessageTypes.Success, 1500);
            this.Close();
        }

        private void saveChanges()
        {
            bool result = vehicleBrandBLL.Add(initVehicleBrand());
            frmVehicleBrand.initDropDownMake();
        }

        private VehicleBrand initVehicleBrand()
        {
            VehicleBrand vehicleBrand = new VehicleBrand();
            vehicleBrand.Make = txtMake.Text;
            vehicleBrand.Model = txtModel.Text;
            vehicleBrand.Category = ddCategory.SelectedItem.ToString();
            vehicleBrand.InsertBy = UserSession.CurrentUser.UserID;
            return vehicleBrand;
        }
    }
}
