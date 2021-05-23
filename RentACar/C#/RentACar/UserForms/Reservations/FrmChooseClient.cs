using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RentACar.UserForms.Reservations
{
    public partial class FrmChooseClient : Form
    {
        FrmReservationsCRUD frmReservations = null;
        ClientBLL clientBLL = new ClientBLL();
        int clientID;
        string clientInfo;

        public FrmChooseClient(FrmReservationsCRUD frmReservations)
        {
            InitializeComponent();
            dgClients.AutoGenerateColumns = false;
            this.frmReservations = frmReservations;
            dgClients.DataSource = clientBLL.GetAll();
            ifEmpty();
        }
        private void ifEmpty()
        {
            if (dgClients.RowCount == 0)
            {
                lblTip.ForeColor = Color.Red;
                lblTip.Text = "Go and create some clients first";
            }
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmReservations.storeClientID(this.clientID);
            frmReservations.updateLblClient(this.clientInfo);
            frmReservations.updateBtnClient();
            BunifuMessage.show(frmReservations, "Client Added.", BunifuSnackbar.MessageTypes.Success, 800);
            this.Close();
        }

        private void dgClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
            lblTip.Text = "A Client Is Selected,Click The Add Button To Add The Client";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgClients.Rows[e.RowIndex];
                clientID = int.Parse(row.Cells["ID"].Value.ToString());
                clientInfo = "Selected Client: " + row.Cells["clientName"].Value.ToString() + " | " + row.Cells["Surname"].Value.ToString();
            }
        }
    }
}
