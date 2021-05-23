using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using Syncfusion.Windows.Forms.Grid;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RentACar.AdminForms.Users
{
    public partial class FrmUsersCRUD : Form
    {
        int userID;
        BunifuDataGridView dgUsers = null;
        UserBLL userBLL = new UserBLL();
        RoleBLL roleBLL = new RoleBLL();
        FrmDashboard frmDashboard;

        //---------UPDATE
        public FrmUsersCRUD(FrmDashboard frm, int userID, BunifuDataGridView dgUsers)
        {
            InitializeComponent();
            this.userID = userID;
            this.dgUsers = dgUsers;
            this.frmDashboard = frm;
            updateLblUser();
            initDropdown();
            readUserByID(this.userID);
            btnUsersClear.ToolTipText = "Refresh";
        }
        //-------ADD
        public FrmUsersCRUD(FrmDashboard frm, BunifuDataGridView dgUsers)
        {
            InitializeComponent();
            this.dgUsers = dgUsers;
            this.frmDashboard = frm;
            updateLblUser();
            initDropdown();
        }

        private void initDropdown()
        {
            RoleBLL roleBLL = new RoleBLL();
            ddRole.DataSource = roleBLL.GetAll().Select(item => item.Name).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void refreshData()
        {
            var users = userBLL.GetAll();
            dgUsers.DataSource = users;
        }

        private User initUser()
        {
            User user = new User();
            user.Role = new Role();
            user.UserID = this.userID;
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            if (txtEmail.Text.Trim() != "")
                user.Email = txtEmail.Text;
            Role role = roleBLL.GetAll().Where(x => x.Name == ddRole.SelectedItem.ToString()).Single();
            user.RoleID = role.RoleID;
            user.InsertBy = UserSession.CurrentUser.UserID;
            return user;
        }

        private void readUserByID(int userID)
        {
            User user = new User();
            user = userBLL.Get(userID);

            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            ddRole.SelectedItem = user.Role.Name;
            if (user.Email != null)
                txtEmail.Text = user.Email;
        }

        private void saveChanges()
        {
            User user = initUser();
            bool result;
            if (userID == 0)
            {
                result = userBLL.Add(user);
                refreshData();
            }
            else
            {
                result = userBLL.Modify(user);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        private void updateLblUser()
        {
            if (userID == 0)
                lblUser.Text = "Add User";
            else
                lblUser.Text = "Edit User";
        }

        private void btnUsersClear_Click(object sender, EventArgs e)
        {
            if (userID == 0)
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
                readUserByID(userID);
        }
    }
}
