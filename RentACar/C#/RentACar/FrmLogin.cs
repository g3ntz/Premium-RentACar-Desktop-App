using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using System;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace RentACar
{
    public partial class frmLogin : Form
    {
        bool passLogin;
        private FrmDashboard frmDashboard;
        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(FrmDashboard frmDashboard)
        {
            InitializeComponent();
            this.frmDashboard = frmDashboard;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunExitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authenticate();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UserSession.CurrentUser == null && passLogin != true)
                Application.Exit();
        }


        //----------User Methods-----------------

        private void Authenticate()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem != null ? cbRole.SelectedItem.ToString() : "";

            if (username.Trim() != "" && password != "" && role != "")
            {
                User User = UserBLL.Login(username, password, role);
                if (User != null)
                {
                    UserSession.CurrentUser = User;

                    //Parent Form
                    initUserInfos(User);
                    this.frmDashboard.bunifuPager.SetPage(1);
                    BunifuMessage.show(frmDashboard, "Successfully Logged", BunifuSnackbar.MessageTypes.Success,1000);
                    this.Close();
                }
                else
                {
                    BunifuMessage.show(this, "Invalid Username Or Password.", BunifuSnackbar.MessageTypes.Error);
                }
            }
            else
                BunifuMessage.show(this, "Make sure there are no empty values.", BunifuSnackbar.MessageTypes.Error);
        }

        private void initUserInfos(User User)
        {
            frmDashboard.lblUsername.Text = UserSession.CurrentUser.Username;
            frmDashboard.lblUserRole.Text += " " + User.Role.Name;
            if (User.Role.Name == "User")
                frmDashboard.disableAdminLeftMenu();
            if (User.LastLoginDate != DateTime.MinValue)
                frmDashboard.lblLastLoginDate.Text += "  " + User.LastLoginDate.ToString("d MMM HH:mm");
        }
    }
}
