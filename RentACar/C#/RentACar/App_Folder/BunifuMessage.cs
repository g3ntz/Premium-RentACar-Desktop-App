using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.App_Folder
{
    public class BunifuMessage
    {
        public static void show(Form frm,string text,BunifuSnackbar.MessageTypes messageType)
        {
            BunifuSnackbar bunifuSnackBar = new BunifuSnackbar();
            bunifuSnackBar.Show(frm, text, messageType);
        }
        public static void show(Form frm, string text, BunifuSnackbar.MessageTypes messageType,int duration)
        {
            BunifuSnackbar bunifuSnackBar = new BunifuSnackbar();
            bunifuSnackBar.Show(frm, text, messageType, duration);
        }
    }
}
