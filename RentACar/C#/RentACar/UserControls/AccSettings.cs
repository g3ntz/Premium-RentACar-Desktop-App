using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.UserControls
{
    public partial class AccSettings : UserControl
    {
        FrmDashboard frm = null;
        public AccSettings()
        {
            InitializeComponent();
        }

        public AccSettings(FrmDashboard frm) : this()
        {
            this.frm = frm;
        }

        private void ItemMyAcc_Click(object sender, EventArgs e)
        {
            frm.disablePageStates();
            frm.disableNavigateButtons();
            frm.bunifuPager.SetPage("AccountInfo");
            frm.changePageTitle("Account Info");
            frm.initDataAccInfo();
        }

        private void ItemChangePass_Click(object sender, EventArgs e)
        {
            frm.disablePageStates();
            frm.disableNavigateButtons();
            frm.bunifuPager.SetPage("ChangePassword");
            frm.changePageTitle("Password");
        }
    }
}
