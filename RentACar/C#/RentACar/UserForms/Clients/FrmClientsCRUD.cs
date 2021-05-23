using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using System;
using System.Windows.Forms;
using RentACar.UIHelper;

namespace RentACar.UserForms.Clients
{
    public partial class FrmClientsCRUD : Form
    {
        int clientID;
        BunifuDataGridView dgClients = null;
        ClientBLL clientBLL = new ClientBLL();
        FrmDashboard frmDashboard;

        //----ADD
        public FrmClientsCRUD(FrmDashboard frm, BunifuDataGridView dgClients)
        {
            InitializeComponent();
            this.dgClients = dgClients;
            this.frmDashboard = frm;
            updateLblClients();
        }

        //------UPDATE
        public FrmClientsCRUD(FrmDashboard frm,int clientID, BunifuDataGridView dgClients)
        {
            InitializeComponent();
            this.clientID = clientID;
            this.dgClients = dgClients;
            this.frmDashboard = frm;
            updateLblClients();
            readClientByID(this.clientID);
            btnClientsClear.ToolTipText = "Refresh";
        }

        //-----ADD NEW FROM OTHER FORMS
        public FrmClientsCRUD()
        {
            InitializeComponent();
            updateLblClients();
        }


        //-------Events----------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //--------User Methods------------
        private void refreshData()
        {
            if(dgClients != null)
            {
                var clients = clientBLL.GetAll();
                dgClients.DataSource = clients;
            }
        }

        private void updateLblClients()
        {
            if (clientID == 0)
                lblClient.Text = "Add Client";
            else
                lblClient.Text = "Edit Client";
        }

        private void saveChanges()
        {
            Client client = initClient();
            bool result;
            if (clientID == 0)
            {
                result = clientBLL.Add(client);
                refreshData();
            }
            else
            {
                result = clientBLL.Modify(client);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        private Client initClient()
        {
            Client client = new Client();
            client.ClientID = this.clientID;
            client.Name = txtName.Text.Trim() != "" ? txtName.Text : null;
            client.Surname = txtSurname.Text.Trim() != "" ? txtSurname.Text : null;
            client.PhoneNr = txtPhoneNr.Text.Trim() != "" ? txtPhoneNr.Text : null;
            client.Email = txtEmail.Text.Trim() != "" ? txtEmail.Text : null;
            client.DrivingLicense = txtDrivingLicense.Text.Trim() != "" ? txtDrivingLicense.Text : null;
            client.Birthdate = dpBirthdate.Value;
            client.Address = txtAddress.Text.Trim() != "" ? txtAddress.Text : null;
            client.InsertBy = UserSession.CurrentUser.UserID;
            return client;
        }

        private void readClientByID(int clientID)
        {
            Client client = new Client();
            client = clientBLL.Get(this.clientID);
            txtName.Text = client.Name;
            txtSurname.Text = client.Surname;
            txtPhoneNr.Text = client.PhoneNr;
            if (client.Email != "No Email")
                txtEmail.Text = client.Email;
            txtDrivingLicense.Text = client.DrivingLicense;
            dpBirthdate.Value = client.Birthdate;
            txtAddress.Text = client.Address;
        }

        private void btnClientsClear_Click(object sender, EventArgs e)
        {
            if (clientID == 0)
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
                readClientByID(clientID);
        }
    }
}
