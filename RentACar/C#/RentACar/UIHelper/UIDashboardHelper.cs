using RentACar.App_Folder;

namespace RentACar.UIHelper
{
    public static class UIDashboardHelper
    {
        public static void logOut(FrmDashboard previousFrmDashboard)
        {
            UserSession.CurrentUser = null;
            FrmDashboard frmDashboard = new FrmDashboard();
            previousFrmDashboard.Hide();
            frmDashboard.Show();
        }
    }
}
