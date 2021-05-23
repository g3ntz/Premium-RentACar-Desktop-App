using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentACar.App_Folder;
using RentACar.BO.Entities;
using RentACar.BLL;

namespace RentACar.Admin.AccountForms
{
    public partial class FrmAccount : Form
    {
        public FrmAccount()
        {
            InitializeComponent();
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            lblUsername.Text = UserSession.CurrentUser.Username;
            //get the role from database for this user
            txtPassword.Text = UserSession.CurrentUser.Password;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //if (txtPassword.Text != "")
            //{
            //    User user = UserSession.CurrentUser;
            //    user.Password = txtPassword.Text;
            //    if(UserBLL.ChangePassword(user) != null)
            //    {
            //        MessageBox.Show("Your password has been changed");
            //    }
            //    else
            //    {
            //        MessageBox.Show("An has ocurred,please try again");
            //    }
            //}
        }

        private void lblHello_Click(object sender, EventArgs e)
        {

        }
    }
}
