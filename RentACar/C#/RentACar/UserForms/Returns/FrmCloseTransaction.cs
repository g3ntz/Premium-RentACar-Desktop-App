using RentACar.BO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentACar.BLL;
using Bunifu.UI.WinForms;
using RentACar.App_Folder;
using RentACar.UIHelper;

namespace RentACar.UserForms.Returns
{
    public partial class FrmCloseTransaction : Form
    {
        Fee lateFee;
        Fee damageFee;
        int returnID;
        BunifuDataGridView dgReturns;
        FrmDashboard frmDashboard;

        ReturnBLL returnBLL = new ReturnBLL();
        BookingsBLL bookingBLL = new BookingsBLL();

        public FrmCloseTransaction(FrmDashboard frm,Fee lateFee,Fee damageFee,int returnID,BunifuDataGridView dgReturns)
        {
            InitializeComponent();
            this.lateFee = lateFee;
            this.damageFee = damageFee;
            this.returnID = returnID;
            this.dgReturns = dgReturns;
            this.frmDashboard = frm;
            init();
        }

        private void init()
        {
            Rental_Return Return = returnBLL.Get(returnID);
            Booking booking = bookingBLL.Get(Return.BookingID);
            
            if(lateFee != null)
            {
                lblLateCostsValue.Text = decimal.Round(lateFee.Costs, 2).ToString(); 
                lblReturnedLateValue.Text = "Returned " + calculateReturnedLateDays(booking);       
            }
            if(damageFee != null)
            {
                lblDamagesValue.Text = decimal.Round(damageFee.Costs, 2).ToString(); 
                txtDamages.Text = this.damageFee.Reason;
            }

            lblNormalPriceValue.Text = decimal.Round(booking.TotalPrice, 2).ToString();
            decimal total = decimal.Parse(lblNormalPriceValue.Text) + decimal.Parse(lblLateCostsValue.Text) + decimal.Parse(lblDamagesValue.Text);
            lblTotalValue.Text = decimal.Round(total, 2).ToString();
        }

        private string calculateReturnedLateDays(Booking booking)
        {
            TimeSpan difference = DateTime.Now.Date - booking.ReturnDate.Date;
            double daysLater = difference.TotalDays;
            if (daysLater < 0)
                return "";
            else 
                return daysLater == 1 ? daysLater.ToString() + " Day Later" : daysLater.ToString() + " Days Later";
        }

        private void refreshData()
        {
            var returns = this.frmDashboard.hasDamageOrLate();
            dgReturns.DataSource = returns;
        }

        private void saveChanges()
        {
            bool result = returnBLL.Modify(new Rental_Return() { Rental_ReturnID = this.returnID });
            refreshData();
            UIGeneralHelper.isSavedSuccessfully(result, frmDashboard, this, "Successfully Closed the Transaction.");
        }

        private void btnCloseTran_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Closing this transaction means that damage and late fees are paid,are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveChanges();
            }
            else
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
