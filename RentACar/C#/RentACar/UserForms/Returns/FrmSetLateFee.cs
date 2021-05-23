using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UserForms.Reservations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Forms;

namespace RentACar.UserForms.Returns
{
    public partial class FrmSetLateFee : Form
    {
        decimal vehicleDailyPrice;
        int count;
        DateTime returnDate;
        FrmReturnCRUD frm;

        public FrmSetLateFee(DateTime returnDate, decimal vehicleDailyPrice, FrmReturnCRUD frm)
        {
            InitializeComponent();
            this.returnDate = returnDate;
            this.vehicleDailyPrice = vehicleDailyPrice;
            this.frm = frm;
            calculate();
        }

        private void calculate()
        {
            dpReturnedDate.MinDate = this.returnDate.AddDays(1);
            DateTime todayDate = dpReturnedDate.Value;
            count++;
            lblExpectedDate.Text = $"Expected Return Date: {this.returnDate.ToString("dd MMMM")}";
            lblReturnedAt.Text = $"Returned At: {todayDate.ToString("dd MMMM")}";

            double daysLater = double.Parse(todayDate.Subtract(this.returnDate).TotalDays.ToString());
            int daysLaterInt = (int)daysLater;
            lblDaysLater.Text = daysLaterInt == 1 ? daysLaterInt.ToString() + " Day Later" : daysLaterInt.ToString() + " Days Later";
            decimal costs = this.vehicleDailyPrice * daysLaterInt;
            lblCostsValue.Text = costs.ToString();
        }

        private void dpReturnedDate_ValueChanged(object sender, EventArgs e)
        {
            if(count > 0)
            {
                Font fnt = new Font(lblTip.Font, FontStyle.Strikeout);
                lblTip.Font = fnt;
                calculate();
            }     
        }

        private Fee initLateFee()
        {
            Fee fee = new Fee();
            fee.IsLate = true;
            fee.Costs = decimal.Parse(lblCostsValue.Text);
            fee.IsPaid = rbYes.Checked;
            fee.returnDate = dpReturnedDate.Value;
            fee.InsertBy = UserSession.CurrentUser.UserID;
            return fee;
        }
        private void saveChanges()
        {
            frm.lateFee = initLateFee();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveChanges();
            BunifuMessage.show(frm, "Added Fee", BunifuSnackbar.MessageTypes.Success,800);
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
    }
}
