using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using System;
using System.Windows.Forms;

namespace RentACar.AdminForms.Roles
{
    public partial class FrmRolesCRUD : Form
    {
        int roleID;
        BunifuDataGridView dgRoles = null;
        RoleBLL roleBLL = new RoleBLL();
        FrmDashboard frmDashboard;

        public FrmRolesCRUD(FrmDashboard frm,int roleID, BunifuDataGridView dgRoles)
        {
            InitializeComponent();
            this.roleID = roleID;
            this.dgRoles = dgRoles;
            this.frmDashboard = frm;
            updateLblRole();
            readRoleByID(this.roleID);
            btnRolesClear.ToolTipText = "Refresh";
        }

        public FrmRolesCRUD(FrmDashboard frm,BunifuDataGridView dgRoles)
        {
            InitializeComponent();
            this.dgRoles = dgRoles;
            this.frmDashboard = frm;
            updateLblRole();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizeIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveChanges()
        {
            Role role = initRole();
            bool result;
            if (roleID == 0)
            {
                result = roleBLL.Add(role);
                refreshData();
            }
            else
            {
                result = roleBLL.Modify(role);
                refreshData();
            }
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this);
        }

        private void refreshData()
        {
            var roles = roleBLL.GetAll();
            dgRoles.DataSource = roles;
        }

        private Role initRole()
        {
            Role role = new Role();
            role.RoleID = this.roleID;
            role.Name = txtRoleName.Text;
            role.Description = txtRoleDescription.Text;
            role.InsertBy = UserSession.CurrentUser.UserID;
            return role;
        }

        private void readRoleByID(int roleID)
        {
            Role role = new Role();
            role = roleBLL.Get(roleID);
            txtRoleName.Text = role.Name;
            txtRoleDescription.Text = role.Description;
        }

        private void updateLblRole()
        {
            if (roleID == 0)
                lblRole.Text = "Add Role";
            else
                lblRole.Text = "Edit Role";
        }

        private void btnRolesClear_Click(object sender, EventArgs e)
        {
            if (roleID == 0)
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
                readRoleByID(roleID);
        }
    }
}
