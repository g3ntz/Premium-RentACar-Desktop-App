using Bunifu.UI.WinForms;
using RentACar.AdminForms.Roles;
using RentACar.AdminForms.Users;
using RentACar.App_Folder;
using RentACar.BLL;
using RentACar.BO.Entities;
using RentACar.UIHelper;
using RentACar.UserForms.Clients;
using RentACar.UserForms.Maintenances;
using RentACar.UserForms.Repairs;
using RentACar.UserForms.Reservations;
using RentACar.UserForms.Returns;
using RentACar.UserForms.Vehicles;
using System;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Windows.Forms;
using RentACar.UserForms.Rental;
using System.Windows.Media;
using LiveCharts;
using System.Data;
using LiveCharts.Wpf;

namespace RentACar
{
    public partial class FrmDashboard : Form
    {
        bool switchingBool = true;
        UserBLL userBLL = new UserBLL();
        RoleBLL roleBLL = new RoleBLL();
        VehicleBLL vehicleBLL = new VehicleBLL();
        VehicleBrandBLL vehicleBrandBLL = new VehicleBrandBLL();
        ClientBLL clientBLL = new ClientBLL();
        MaintenancesBLL maintenanceBLL = new MaintenancesBLL();
        BookingsBLL bookingBLL = new BookingsBLL();
        RentalBLL rentalBLL = new RentalBLL();
        ReturnBLL returnBLL = new ReturnBLL();
        RepairsBLL repairBLL = new RepairsBLL();
        FeeBLL feeBLL = new FeeBLL();

        public FrmDashboard()
        {
            InitializeComponent();
            disableAutoGenerateColumns();
            customizeDataGrid();
            disablePageStates();
            disableNavigateButtons();
            HideLeftMenu();
        }


        //----------- General Methods ------------------------------
        private void disableAutoGenerateColumns()
        {
            dgRoles.AutoGenerateColumns = false;
            dgUsers.AutoGenerateColumns = false;
            dgClients.AutoGenerateColumns = false;
            dgMaintenances.AutoGenerateColumns = false;
            dgVehicles.AutoGenerateColumns = false;
            dgBookings.AutoGenerateColumns = false;
            dgRentals.AutoGenerateColumns = false;
            dgReturns.AutoGenerateColumns = false;
            dgRepairs.AutoGenerateColumns = false;
        }

        private void customizeDataGrid()
        {
            UIGeneralHelper.customizeDataGrid(dgUsers);
            UIGeneralHelper.customizeDataGrid(dgRoles);
            UIGeneralHelper.customizeDataGrid(dgVehicles);
            UIGeneralHelper.customizeDataGrid(dgClients);
            UIGeneralHelper.customizeDataGrid(dgMaintenances);
            UIGeneralHelper.customizeDataGrid(dgBookings);
            UIGeneralHelper.customizeDataGrid(dgRentals);
            UIGeneralHelper.customizeDataGrid(dgReturns);
            UIGeneralHelper.customizeDataGrid(dgRepairs);
        }

        private void changeAllToName(BunifuDropdown dropDown, string text)
        {
            if (dropDown.Name == "ddVehicleMake" && dropDown.SelectedIndex == 0)
            {
                dropDown.Text = "Make";
                ddVehicleModel.Text = "Model";
            }
            else if (dropDown.SelectedIndex == 0)
                dropDown.Text = text;
        }

        private void validateDaysByMonth(BunifuDropdown dropDown,int selectedIndex)
        {
            dropDown.Items.Clear();
            dropDown.Text = "Day";
            if (selectedIndex == 2)
            {
                dropDown.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 28))
                {
                    dropDown.Items.Add(item);
                }
            }
            else if (selectedIndex == 4 || selectedIndex == 6 || selectedIndex == 9 || selectedIndex == 11)
            {
                dropDown.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 30))
                {
                    dropDown.Items.Add(item);
                }
            }
            else if (selectedIndex == 0 || selectedIndex == 1 || selectedIndex == 3 || selectedIndex == 5 || selectedIndex == 7 || selectedIndex == 8 || selectedIndex == 10 || selectedIndex == 12)
            {
                dropDown.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 31))
                {
                    dropDown.Items.Add(item);
                }
            }
        }

        private void validateYear(BunifuDropdown dropDown)
        {
            dropDown.Items.Add("All");
            for (int i = 2020; i <= DateTime.Today.Year; i++)
            {
                dropDown.Items.Add(i);
            }
            dropDown.SelectedIndex = 0;
        }

        private void initDdYear(BunifuDropdown dd)
        {
            dd.Items.Clear();
            for (int year = 2020; year <= DateTime.Today.Year; year++)
            {
                dd.Items.Add(year);
            }
            dd.SelectedIndex = 0;
        }

        public DataGridView CloneDataGrid(DataGridView mainDataGridView)
        {
            DataGridView cloneDataGridView = new DataGridView();
            int columnCount = mainDataGridView.Columns.Count;
            Type type = mainDataGridView.Columns[0].CellType;

            if (cloneDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
                {
                    if (datagrid.Index == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || datagrid.Index == columnCount - 1 || datagrid.Index == columnCount - 2 || datagrid.Index == columnCount - 3 || datagrid.Index == columnCount - 4)
                        continue;
                    else
                        cloneDataGridView.Columns.Add(datagrid.Clone() as DataGridViewColumn);
                }
            }

            DataGridViewRow dataRow = new DataGridViewRow();

            for (int i = 0; i < mainDataGridView.Rows.Count; i++)
            {

                dataRow = (DataGridViewRow)cloneDataGridView.Rows[i].Clone();
                int Index = 0;
                foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
                {
                    if (cell.ColumnIndex == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || cell.ColumnIndex == columnCount - 1 || cell.ColumnIndex == columnCount - 2 || cell.ColumnIndex == columnCount - 3 || cell.ColumnIndex == columnCount - 4)
                    {
                        Index++;
                        continue;
                    }
                    else if (mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell")
                        dataRow.Cells[Index - 1].Value = cell.Value;
                    else
                        dataRow.Cells[Index].Value = cell.Value;
                    Index++;
                }
                cloneDataGridView.Rows.Add(dataRow);
            }
            cloneDataGridView.Refresh();
            return cloneDataGridView;
        }

        public void bunifuDeletedMessage()
        {
            BunifuMessage.show(this, "Deleted Successfully.", BunifuSnackbar.MessageTypes.Success);
        }

        private void setTextboxesIconFalse()
        {
            txtSearchByUsername.RightIcon.Visible = false;
            txtSearchClient.RightIcon.Visible = false;
            txtVehicleSearch.RightIcon.Visible = false;
            txtSearchBooking.RightIcon.Visible = false;
            txtSearchRental.RightIcon.Visible = false;
            txtSearchReturn.RightIcon.Visible = false;
            txtSearchMaintenance.RightIcon.Visible = false;
            txtRepairSearch.RightIcon.Visible = false;
        }

        private void generateRaport(DataGridView dg, string title)
        {
            easyHTMLReports1.Clear();

            easyHTMLReports1.AddImage(Properties.Resources.Logo2);

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString(title);
            easyHTMLReports1.AddHorizontalRule();

            easyHTMLReports1.AddDatagridView(dg);

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private double getMonthlyIncomes(DateTime startDate, int i)
        {
            double totalIncome = 0.00;
            foreach (var item in returnBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).ToList())
            {
                bool hasFee = false;
                foreach (var fee in feeBLL.GetAll())
                {
                    if (item.Rental_ReturnID == fee.returnID)
                    {
                        hasFee = true;
                        if (fee.IsPaid == true)
                        {
                            totalIncome += (double)fee.Costs + (double)bookingBLL.Get(item.BookingID).TotalPrice;
                            hasFee = true;
                        }
                    }
                }
                if (hasFee == false)
                    totalIncome += (double)bookingBLL.Get(item.BookingID).TotalPrice;
            }
            return totalIncome;
        }

        private double getMonthlyExpenses(DateTime startDate, int i)
        {
            double totalExpenses = 0.00;
            foreach (var item in maintenanceBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i && x.IsReturned == true))
            {
                totalExpenses += (double)item.Costs;
            }
            foreach (var item in repairBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i && x.IsRepaired == true))
            {
                totalExpenses += (double)item.Costs;
            }
            return totalExpenses;
        }

        private double getDailyIncomes(DateTime date)
        {
            double totalIncomes = 0.00;
            foreach (var item in returnBLL.GetAll().Where(x => x.InsertDate.Date == date.Date).ToList())
            {
                bool hasFee = false;
                foreach (var fee in feeBLL.GetAll())
                {
                    if (item.Rental_ReturnID == fee.returnID)
                    {
                        hasFee = true;
                        if (fee.IsPaid == true)
                        {
                            totalIncomes += (double)fee.Costs + (double)bookingBLL.Get(item.BookingID).TotalPrice;
                            hasFee = true;
                        }
                    }
                }
                if (hasFee == false)
                    totalIncomes += (double)bookingBLL.Get(item.BookingID).TotalPrice;
            }
            return totalIncomes;
        }

        private double getDailyExpenses(DateTime date)
        {
            double totalExpenses = 0.00;
            foreach (var item in maintenanceBLL.GetAll().Where(x => x.InsertDate.Date == date.Date && x.IsReturned == true))
            {
                totalExpenses += (double)item.Costs;
            }
            foreach (var item in repairBLL.GetAll().Where(x => x.InsertDate.Date == date.Date && x.IsRepaired == true))
            {
                totalExpenses += (double)item.Costs;
            }
            return totalExpenses;
        }

        public DataGridView CloneDataGridSevenCol(DataGridView mainDataGridView)
        {
            DataGridView cloneDataGridView = new DataGridView();
            int columnCount = mainDataGridView.Columns.Count;
            Type type = mainDataGridView.Columns[0].CellType;

            if (cloneDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
                {
                    if (datagrid.Index == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || datagrid.Index == columnCount - 1 || datagrid.Index == columnCount - 2 || datagrid.Index == columnCount - 3 || datagrid.Index == columnCount - 4 || datagrid.Index == columnCount - 5 || datagrid.Index == columnCount - 6 || datagrid.Index == columnCount - 7)
                        continue;
                    else
                        cloneDataGridView.Columns.Add(datagrid.Clone() as DataGridViewColumn);
                }
            }

            DataGridViewRow dataRow = new DataGridViewRow();

            for (int i = 0; i < mainDataGridView.Rows.Count; i++)
            {

                dataRow = (DataGridViewRow)cloneDataGridView.Rows[i].Clone();
                int Index = 0;
                foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
                {
                    if (cell.ColumnIndex == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || cell.ColumnIndex == columnCount - 1 || cell.ColumnIndex == columnCount - 2 || cell.ColumnIndex == columnCount - 3 || cell.ColumnIndex == columnCount - 4 || cell.ColumnIndex == columnCount - 5 || cell.ColumnIndex == columnCount - 6 || cell.ColumnIndex == columnCount - 7)
                    {
                        Index++;
                        continue;
                    }
                    else if (mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell")
                        dataRow.Cells[Index - 1].Value = cell.Value;
                    else
                        dataRow.Cells[Index].Value = cell.Value;
                    Index++;
                }
                cloneDataGridView.Rows.Add(dataRow);
            }
            cloneDataGridView.Refresh();
            return cloneDataGridView;
        }

        public DataGridView CloneDataGridThreeCol(DataGridView mainDataGridView)
        {
            DataGridView cloneDataGridView = new DataGridView();
            int columnCount = mainDataGridView.Columns.Count;
            Type type = mainDataGridView.Columns[0].CellType;

            if (cloneDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
                {
                    if (datagrid.Index == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || datagrid.Index == columnCount - 1 || datagrid.Index == columnCount - 2 || datagrid.Index == columnCount - 3)
                        continue;
                    else
                        cloneDataGridView.Columns.Add(datagrid.Clone() as DataGridViewColumn);
                }
            }

            DataGridViewRow dataRow = new DataGridViewRow();

            for (int i = 0; i < mainDataGridView.Rows.Count; i++)
            {

                dataRow = (DataGridViewRow)cloneDataGridView.Rows[i].Clone();
                int Index = 0;
                foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
                {
                    if (cell.ColumnIndex == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || cell.ColumnIndex == columnCount - 1 || cell.ColumnIndex == columnCount - 2 || cell.ColumnIndex == columnCount - 3)
                    {
                        Index++;
                        continue;
                    }
                    else if (mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell")
                        dataRow.Cells[Index - 1].Value = cell.Value;
                    else
                        dataRow.Cells[Index].Value = cell.Value;
                    Index++;
                }
                cloneDataGridView.Rows.Add(dataRow);
            }
            cloneDataGridView.Refresh();
            return cloneDataGridView;
        }

        public DataGridView CloneDataGridOneCol(DataGridView mainDataGridView)
        {
            DataGridView cloneDataGridView = new DataGridView();
            int columnCount = mainDataGridView.Columns.Count;
            Type type = mainDataGridView.Columns[0].CellType;

            if (cloneDataGridView.Columns.Count == 0)
            {
                foreach (DataGridViewColumn datagrid in mainDataGridView.Columns)
                {
                    if (datagrid.Index == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || datagrid.Index == columnCount - 1)
                        continue;
                    else
                        cloneDataGridView.Columns.Add(datagrid.Clone() as DataGridViewColumn);
                }
            }

            DataGridViewRow dataRow = new DataGridViewRow();

            for (int i = 0; i < mainDataGridView.Rows.Count; i++)
            {

                dataRow = (DataGridViewRow)cloneDataGridView.Rows[i].Clone();
                int Index = 0;
                foreach (DataGridViewCell cell in mainDataGridView.Rows[i].Cells)
                {
                    if (cell.ColumnIndex == 0 && mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell" || cell.ColumnIndex == columnCount - 1)
                    {
                        Index++;
                        continue;
                    }
                    else if (mainDataGridView.Columns[0].CellType.Name == "DataGridViewImageCell")
                        dataRow.Cells[Index - 1].Value = cell.Value;
                    else
                        dataRow.Cells[Index].Value = cell.Value;
                    Index++;
                }
                cloneDataGridView.Rows.Add(dataRow);
            }
            cloneDataGridView.Refresh();
            return cloneDataGridView;
        }



        //-------Dashboard Structure----------------------------------------
        private void frmDashboard_Shown(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin(this);
            frmLogin.ShowDialog();
            rbVehicleDamaged.Checked = false;
            initDdYear(ddReportsYear);
            initDdYear(ddDashboardChart);
            initDashboardChart();
            initDashboard();
            validateAllYearFields();
            cancelReservationsWithLateRentals();
            setTextboxesIconFalse();
        }

        private void validateAllYearFields()
        {
            validateYear(ddBookingsCreateYear);
            validateYear(ddBookingsRentalYear);
            validateYear(ddBookingsReturnYear);

            validateYear(ddMaintenanceReturnYear);
            validateYear(ddMaintenanceStartYear);

            validateYear(ddRepairStartYear);
            validateYear(ddRepairReturnYear);

            validateYear(ddRentalYear);
            validateYear(ddReturnYear);
        }

        private void btnExitIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizeIcon_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch(ApplicationException ex)
            {

            }
        }

        private void btnRestoreDown_Click(object sender, EventArgs e)
        {
            btnRestoreDown.Visible = false;
            btnMaximize.Visible = !btnRestoreDown.Visible;
            this.WindowState = FormWindowState.Normal;
            bunifuElipse1.ElipseRadius = 20;
            guna2DragControl1.TargetControl = pnlTopBar;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = false;
            btnRestoreDown.Visible = !btnMaximize.Visible;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
            bunifuElipse1.ElipseRadius = 0;
            guna2DragControl1.TargetControl = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            logOut();
        }

        private void btnQuickReservation_Click(object sender, EventArgs e)
        {
            FrmReservationsCRUD frmReservations = new FrmReservationsCRUD(dgBookings, this);
            frmReservations.Show();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            rbVehicleAvailableAll.Checked = true;
            dpDailyReports.Value = DateTime.Today;
        }

        public void changePageTitle(string pageTitle)
        {
            lblPageTitle.Text = pageTitle;
        }

        public void disablePageStates()
        {
            reservationStates1.Visible = false;
            rentalStates1.Visible = false;
            returnStates1.Visible = false;
            repairStates1.Visible = false;
            maintenanceStates1.Visible = false;
            vehicleStates1.Visible = false;
        }

        private void changeLeftMenuIndicatorPosition(Control control)
        {
            if (pnlAdminSubMenu.Contains(control))
            {
                leftUserMenuIndicator.Visible = false;
                leftAdminMenuIndicator.Visible = true;
                leftAdminMenuIndicator.Top = control.Top + 2;
            }
            else if (pnlUserSubMenu.Contains(control))
            {
                leftAdminMenuIndicator.Visible = false;
                leftUserMenuIndicator.Visible = true;
                leftUserMenuIndicator.Top = control.Top + pnlPageTitle.Height - control.Height + 3;
            }
            else
            {
                leftAdminMenuIndicator.Visible = false;
                leftUserMenuIndicator.Visible = false;
            }
        }

        private void customizeStates(string page)
        {
            if (page == "Bookings")
            {
                reservationStates1.Visible = true;
                rentalStates1.Visible = false;
                returnStates1.Visible = false;
                repairStates1.Visible = false;
                maintenanceStates1.Visible = false;
                vehicleStates1.Visible = false;
            }
            else if (page == "Rentals")
            {
                rentalStates1.Visible = true;
                reservationStates1.Visible = false;
                returnStates1.Visible = false;
                repairStates1.Visible = false;
                maintenanceStates1.Visible = false;
                vehicleStates1.Visible = false;
            }
            else if (page == "Returns")
            {
                returnStates1.Visible = true;
                rentalStates1.Visible = false;
                reservationStates1.Visible = false;
                repairStates1.Visible = false;
                maintenanceStates1.Visible = false;
                vehicleStates1.Visible = false;
            }
            else if (page == "Repairs")
            {
                repairStates1.Visible = true;
                returnStates1.Visible = false;
                rentalStates1.Visible = false;
                reservationStates1.Visible = false;
                maintenanceStates1.Visible = false;
                vehicleStates1.Visible = false;
            }
            else if (page == "Maintenances")
            {
                maintenanceStates1.Visible = true;
                repairStates1.Visible = false;
                returnStates1.Visible = false;
                rentalStates1.Visible = false;
                reservationStates1.Visible = false;
                vehicleStates1.Visible = false;
            }
            else if (page == "Vehicles")
            {
                vehicleStates1.Visible = true;
                maintenanceStates1.Visible = false;
                repairStates1.Visible = false;
                returnStates1.Visible = false;
                rentalStates1.Visible = false;
                reservationStates1.Visible = false;
            }
        }

        public void logOut()
        {
            UserSession.CurrentUser = null;
            FrmDashboard frmDashboard = new FrmDashboard();
            this.Hide();
            frmDashboard.Show();
        }



        //----------Left Menu Manipulation------------------------------------
        private void btnExpandProfile_Click(object sender, EventArgs e)
        {
            HideOrShowCmsAccount(cmsAccount, new Point(this.Location.X + 12, this.Location.Y + 255));
        }

        private void cmsMyAccount_Click(object sender, EventArgs e)
        {
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("AccountInfo");
            changePageTitle("Account Info");
            initDataAccInfo();
            changeLeftMenuIndicatorPosition(btnExpandProfile);
        }

        private void cmsChangePassword_Click(object sender, EventArgs e)
        {
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("changePass");
            changePageTitle("Change Password");
            changeLeftMenuIndicatorPosition(btnExpandProfile);
        }

        private void cmsLogOut_Click(object sender, EventArgs e)
        {
            logOut();
        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            HideOrShowAdminLeftMenu();
        }

        private void btnUserMenu_Click(object sender, EventArgs e)
        {
            HideOrShowUserLeftMenu();
        }

        private void HideOrShowCmsAccount(ContextMenuStrip cms, Point shownLocation)
        {
            if (switchingBool)
                cmsAccount.Show(shownLocation);
            else
                cmsAccount.Hide();
            switchingBool = !switchingBool;
        }

        public void disableAdminLeftMenu()
        {
            btnAdminMenu.Enabled = false;
        }

        private void HideOrShowAdminLeftMenu()
        {
            pnlAdminSubMenu.Visible = !pnlAdminSubMenu.Visible;
        }

        private void HideOrShowUserLeftMenu()
        {
            pnlUserSubMenu.Visible = !pnlUserSubMenu.Visible;
        }

        private void HideLeftMenu()
        {
            pnlAdminSubMenu.Visible = false;
            pnlUserSubMenu.Visible = false;
        }



        //----------Left Menu/Navigation Click Events------------------------------------
        private void btnSubItemUsers_Click(object sender, EventArgs e)
        {
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("Users");
            changePageTitle("Users");
            var users = userBLL.GetAll();
            dgUsers.DataSource = users;
            usersCurrentList = users;
            initDropDown();
            ddSortValue.SelectedIndex = 0;
            changeLeftMenuIndicatorPosition(btnSubItemUsers);
        }

        private void btnSubItemRoles_Click(object sender, EventArgs e)
        {
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("Roles");
            changePageTitle("Roles");
            var roles = roleBLL.GetAll();
            dgRoles.DataSource = roles;
            changeLeftMenuIndicatorPosition(btnSubItemRoles);
        }

        private void btnSubItemDashboard_Click(object sender, EventArgs e)
        {     
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("Dashboard");
            changePageTitle("Dashboard");
            changeLeftMenuIndicatorPosition(btnSubItemDashboard);
            initDashboard();
        }

        private void btnSubItemVehicles_Click(object sender, EventArgs e)
        {
            disableNavigateButtons();
            bunifuPager.SetPage("Vehicles");
            changePageTitle("Vehicles");
            customizeStates(bunifuPager.PageName);
            initDropDownMake();
            var vehicles = vehicleBLL.GetAll();
            dgVehicles.DataSource = vehicles;
            vehicleCurrentList = vehicles;
            ddVehicleAZ.SelectedIndex = 0;
            changeLeftMenuIndicatorPosition(btnSubItemVehicles);
        }

        private void btnSubItemClients_Click(object sender, EventArgs e)
        {
            disablePageStates();
            disableNavigateButtons();
            bunifuPager.SetPage("Clients");
            changePageTitle("Clients");
            var clients = clientBLL.GetAll();
            dgClients.DataSource = clients;
            clientCurrentList = clients;
            ddClientAZ.SelectedIndex = 0;
            ddAge.SelectedIndex = 0;
            changeLeftMenuIndicatorPosition(btnSubItemClients);
        }

        private void btnSubItemBookings_Click(object sender, EventArgs e)
        {
            enableNavigateButtons();
            bunifuPager.SetPage("Bookings");
            changePageTitle("Reservations");
            customizeStates(bunifuPager.PageName);
            var bookings = bookingBLL.GetAll();
            dgBookings.DataSource = bookings;
            ddBookingState.SelectedIndex = 0;
            ddBookingAZ.SelectedIndex = 0;
            changeLeftMenuIndicatorPosition(btnSubItemBookings);
            changeIndicatorPosition(btnBookingsPage);
        }

        private void btnSubItemRepairs_Click(object sender, EventArgs e)
        {
            disableNavigateButtons();
            bunifuPager.SetPage("Repairs");
            changePageTitle("Repairs");
            customizeStates(bunifuPager.PageName);
            repairSetSelectedIndexes();
            var repairs = repairBLL.GetAll();
            dgRepairs.DataSource = repairs;
            repairCurrentList = repairs;
            changeLeftMenuIndicatorPosition(btnSubItemRepairs);
        }

        private void btnSubItemMaintenances_Click(object sender, EventArgs e)
        {
            disableNavigateButtons();
            bunifuPager.SetPage("Maintenances");
            changePageTitle("Maintenances");
            customizeStates(bunifuPager.PageName);
            maintenanceSetSelectedIndexes();
            var maintenances = maintenanceBLL.GetAll();
            dgMaintenances.DataSource = maintenances;
            changeLeftMenuIndicatorPosition(btnSubItemMaintenances);
        }



        //------------ CONTENT  PAGES ------------------------

        //---------  PAGE 1 - USERS  -----------------------------
        //-----------  GENERAL  ------------------------
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmUsersCRUD frmUsersCRUD = new FrmUsersCRUD(this,dgUsers);
            frmUsersCRUD.Show();
        }

        private void btnPrintUser_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgUsers);
            generateRaport(finalDataGrid, "Users List");
        }

        private void dgUsers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex, dgUsers);
        }

        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgUsers.Rows[e.RowIndex];
                if (e.ColumnIndex == dgUsers.ColumnCount - 4)
                {
                    int userID = int.Parse(row.Cells["UserID"].Value.ToString().Remove(0, 1));
                    FrmUsersCRUD frmUsers = new FrmUsersCRUD(this, userID, dgUsers);
                    frmUsers.Show();
                }
                else if (e.ColumnIndex == dgUsers.ColumnCount - 2)
                {
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int userID = int.Parse(row.Cells["UserID"].Value.ToString().Remove(0, 1));
                        userBLL.Remove(userID);
                        dgUsers.DataSource = userBLL.GetAll();
                        bunifuDeletedMessage();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dgUsers_DataSourceChanged(object sender, EventArgs e)
        {
            lblUserTotalRecords.Text = $"Total Records: {dgUsers.RowCount}";
        }

        private void initDropDown()
        {
            ddRoles.Items.Clear();
            ddRoles.Items.Add("All");
            foreach (var item in roleBLL.GetAll().Select(item => item.Name).ToList())
            {
                ddRoles.Items.Add(item);
            }
            ddSearchBy.SelectedIndex = 0;
            ddRoles.SelectedIndex = 0;
        }


        //-------------------------Filtering---------------
        List<User> usersCurrentList = new List<User>();

        private void txtSearchByUsername_TextChanged_1(object sender, EventArgs e)
        {
            filterUsers();
        }

        private void txtSearchByUsername_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchByUsername.Text = "";
        }

        private void ddRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUsers();
            changeAllToName(ddRoles, "Roles");
        }

        private void ddSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUsers();
        }

        private void chbInactiveUsers_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterUsers();
        }

        private void chbNeverLogged_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterUsers();
        }

        private List<User> filterUsersBySearch(List<User> tempList)
        {
            if (ddSearchBy.SelectedItem == null)
                return null;

            if (txtSearchByUsername.Text.Trim() != "")
            {
                txtSearchByUsername.RightIcon.Visible = true;

                switch (ddSearchBy.SelectedItem.ToString())
                {
                    case "Username":
                        tempList = tempList.Where(x => x.Username.ToUpper().StartsWith(txtSearchByUsername.Text.ToUpper())).ToList();
                        dgUsers.DataSource = tempList;

                        break;
                    case "Email":
                        tempList = tempList.Where(x => x.Email != null).Where(x => x.Email.ToUpper().StartsWith(txtSearchByUsername.Text.ToUpper())).ToList();
                        dgUsers.DataSource = tempList;
                        break;
                    case "Password":
                        tempList = tempList.Where(x => x.Password.ToUpper().StartsWith(txtSearchByUsername.Text.ToUpper())).ToList();
                        dgUsers.DataSource = tempList;
                        break;
                    default:
                        ddSearchBy.Focus();
                        break;
                }
            }
            else
            {
                txtSearchByUsername.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterUsers()
        {
            var tempList = new List<User>();
            tempList = userBLL.GetAll();

            //-----------USER ROLE FILTERING
            if (ddRoles.SelectedIndex != 0 && ddRoles.SelectedIndex != -1)
            {
                Role role = roleBLL.GetAll().Where(x => x.Name == ddRoles.SelectedItem.ToString()).Single();
                tempList = tempList.Where(x => x.RoleID == role.RoleID).ToList();
            }    


            //-----------USER SEARCH FILTERING
            var templistSearch = filterUsersBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;

            //-----------INACTIVE USERS FILTERING
            if (chbInactiveUsers.Checked)
            {
                var newList = new List<User>();
                foreach (var item in tempList)
                {
                    TimeSpan diff = DateTime.Now.Date - item.LastLoginDate.Date;
                    double days = diff.TotalDays;
                    if (days >= 14 && item.LastLoginDate != DateTime.MinValue)
                    {
                        newList.Add(item);
                    }
                }
                tempList = newList;
            }

            //-----------NEVER LOGGED USERS FILTERING
            if (chbNeverLogged.Checked)
            {
                tempList = tempList.Where(x => x.LastLoginDate == DateTime.MinValue).ToList();
            }

            dgUsers.DataSource = tempList;
            usersCurrentList = tempList;
        }

        private void sortUsers(List<User> tempList, bool isAscending)
        {
            if (ddSortBy.SelectedItem == null)
                return;

            switch (ddSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.UserID).ToList() : tempList.OrderByDescending(x => x.UserID).ToList();
                    break;
                case "Username":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Username).ToList() : tempList.OrderByDescending(x => x.Username).ToList();
                    break;
                case "Role":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StringRoleName).ToList() : tempList.OrderByDescending(x => x.StringRoleName).ToList();
                    break;
                case "Email":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Email).ToList() : tempList.OrderByDescending(x => x.Email).ToList();
                    break;
                case "Password":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Password).ToList() : tempList.OrderByDescending(x => x.Password).ToList();
                    break;
                case "Last Login Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.LastLoginDate).ToList() : tempList.OrderByDescending(x => x.LastLoginDate).ToList();
                    break;
                case "Last Password Change":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.LastPasswordChangeDate).ToList() : tempList.OrderByDescending(x => x.LastPasswordChangeDate).ToList();
                    break;
            }
            dgUsers.DataSource = tempList;
        }
        

        //--------------------------Sorting----------------
        private void ddSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddSortValue.SelectedIndex == 0)
                sortUsers(usersCurrentList, true);
            else
                sortUsers(usersCurrentList, false);
        }

        private void ddSortValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddSortValue.SelectedIndex == 0)
                sortUsers(usersCurrentList, true);
            else
                sortUsers(usersCurrentList, false);
        }



        //---------  PAGE 2 - ROLES  ---------------------------------
        //---------- GENERAL ------------------------
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            FrmRolesCRUD frmRolesCRUD = new FrmRolesCRUD(this,dgRoles);
            frmRolesCRUD.Show();
        }

        private void btnPrintRoles_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgRoles);
            generateRaport(finalDataGrid, "Roles List");
        }

        private void dgRoles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex, dgRoles);
        }

        private void dgRoles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgRoles.Rows[e.RowIndex];
                if (e.ColumnIndex == dgRoles.ColumnCount - 4)
                {
                    int roleID = int.Parse(row.Cells["RoleID"].Value.ToString().Remove(0, 1));
                    FrmRolesCRUD frmRoles = new FrmRolesCRUD(this, roleID, dgRoles);
                    frmRoles.Show();
                }
                else if (e.ColumnIndex == dgRoles.ColumnCount - 2)
                {
                    if (MessageBox.Show("If you delete this role all users associated with this role will be deleted too, Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int roleID = int.Parse(row.Cells["RoleID"].Value.ToString().Remove(0, 1));
                        roleBLL.Remove(roleID);
                        dgRoles.DataSource = roleBLL.GetAll();
                        bunifuDeletedMessage();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dgRoles_DataSourceChanged(object sender, EventArgs e)
        {
            lblRolesTotalRecords.Text = $"Total Records: {dgRoles.RowCount}";
        }



        //---------  PAGE 3 - DASHBOARD  ---------------------------------
        //---------- GENERAL ------------------------
        private void initDashboard()
        {
            initDashboardTop();
            initDashboardRight();
            initDashboardBottom();
        }

        private void initDashboardTop()
        {
            lblNrBookings.Text = bookingBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).ToList().Count.ToString();
            lblNrRentals.Text = rentalBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).ToList().Count.ToString();
            lblNrReturns.Text = returnBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).ToList().Count.ToString();
            lblNrCanceledBookings.Text = bookingBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date && x.BookingStatusID == 3).ToList().Count.ToString();
            lblNrMaintenances.Text = maintenanceBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).Count().ToString();
            lblNrRepairs.Text = repairBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).Count().ToString();
            lblNrLateReturns.Text = feeBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date && x.IsLate == true).Count().ToString();
            var returns = returnBLL.GetAll().Where(x => x.InsertDate.Date == DateTime.Today.Date).ToList();
            lblNrEstimates.Text = $"${getEstimates(returns):0.00}";
            lblNrDamagedVehicles.Text = getDamagedVehicles(returns).ToString();
            lblNrExpenses.Text = $"${getDailyExpenses(DateTime.Today.Date):0.00}";
        }

        private void initDashboardRight()
        {
            //--------DAMAGE/LATE PAID
            var fees = feeBLL.GetAll();
            int latesPaidNr = fees.Where(x => x.IsLate == true && x.IsPaid == true).ToList().Count;
            int damagesPaidNr = fees.Where(x => x.IsLate == false && x.IsPaid == true).ToList().Count;
            pbLatesPaid.Maximum = fees.Where(x => x.IsLate == true).ToList().Count;
            pbDamagesPaid.Maximum = fees.Where(x => x.IsLate == false).ToList().Count;
            pbLatesPaid.Value = latesPaidNr;
            pbDamagesPaid.Value = damagesPaidNr;
            latesPaidValue.Text = latesPaidNr.ToString();
            damagesPaidValue.Text = damagesPaidNr.ToString();

            //--------Vehicles
            var vehicles = vehicleBLL.GetAll();
            int vehiclesNr = vehicles.Count;
            int expiredRegistrationsNr = vehicles.Where(x => x.VehicleRegistration.ExpirationDate <= DateTime.Today).ToList().Count;
            int nearExpirationNr = vehicles.Where(x => x.VehicleRegistration.ExpirationDate > DateTime.Today && x.VehicleRegistration.ExpirationDate <= DateTime.Today.AddMonths(1)).ToList().Count();
            int availableVehicles = vehicleBLL.GetAll().Where(x => x.IsAvailable == true).ToList().Count;
            pbAvailableVehicles.Maximum = vehiclesNr;
            pbAvailableVehicles.Value = availableVehicles;
            availableVehiclesNr.Text = availableVehicles.ToString();
            pbExpiredRegistrations.Maximum = vehiclesNr;
            pbNearExpiration.Maximum = vehiclesNr;
            pbExpiredRegistrations.Value = expiredRegistrationsNr;
            pbNearExpiration.Value = nearExpirationNr;
            expiredRegistrationsValue.Text = expiredRegistrationsNr.ToString();
            nearExpirationValue.Text = nearExpirationNr.ToString();

            //-------Circle Progress
            var allRentals = rentalBLL.GetAll().Count;
            var returnedRentals = rentalBLL.GetAll().Where(x => x.IsClosed == true).ToList().Count;
            double divideValue = (double)returnedRentals / allRentals;
            dashboardCircleProgress.Value = double.IsNaN(divideValue) == false ? (int)(divideValue * 100) : 0;
        }

        private void initDashboardBottom()
        {
            populateDashboardChart();
        }

        private void initDashboardChart()
        {
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Revenue/Costs",
                LabelFormatter = value => value.ToString("C"),
                MinValue = 0
            });

            SeriesCollection series = new SeriesCollection();
            series.Add(new LineSeries()
            {
                Title = "Revenue",
                StrokeThickness = 3,
                PointGeometrySize = 10,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(48, 23, 107)),
                Values = new ChartValues<double>(getRevenuesForDashboard())
            });
            series.Add(new LineSeries()
            {
                Title = "Damage Costs",
                StrokeThickness = 3,
                PointGeometrySize = 10,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(156, 0, 65)),
                Values = new ChartValues<double>(getDamageCostsForDashboard())
            });
            series.Add(new LineSeries()
            {
                Title = "Repair Costs",
                StrokeThickness = 3,
                PointGeometrySize = 10,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(47, 166, 186)),
                Values = new ChartValues<double>(getRepairCostsForDashboard())
            });
            series.Add(new LineSeries()
            {
                Title = "Maintenance Costs",
                StrokeThickness = 3,
                PointGeometrySize = 10,
                Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 178, 30)),
                Values = new ChartValues<double>(getMaintenanceCostsForDashboard())
            });
            cartesianChart1.Series = series;
            cartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private void populateDashboardChart()
        {
            cartesianChart1.Series[0].Values = new ChartValues<double>(getRevenuesForDashboard());
            cartesianChart1.Series[1].Values = new ChartValues<double>(getDamageCostsForDashboard());
            cartesianChart1.Series[2].Values = new ChartValues<double>(getRepairCostsForDashboard());
            cartesianChart1.Series[3].Values = new ChartValues<double>(getMaintenanceCostsForDashboard());
        }

        private double getEstimates(List<Rental_Return> returns)
        {
            double estimates = 0.00;
            foreach (var item in returns)
            {
                bool hasFee = false;
                foreach (var fee in feeBLL.GetAll())
                {
                    if (item.Rental_ReturnID == fee.returnID)
                    {
                        hasFee = true;
                        if (fee.IsPaid)
                        {
                            estimates += (double)fee.Costs + (double)bookingBLL.Get(item.BookingID).TotalPrice;
                            hasFee = true;
                        }
                    }
                }
                if (hasFee == false)
                    estimates += (double)bookingBLL.Get(item.BookingID).TotalPrice;
            }
            return estimates;
        }

        private int getDamagedVehicles(List<Rental_Return> returns)
        {
            int damagedVehiclesNr = 0;
            foreach (var item in returns)
            {
                foreach (var fee in feeBLL.GetAll())
                {
                    if (item.Rental_ReturnID == fee.returnID && fee.IsLate == false)
                        damagedVehiclesNr++;
                }
            }
            return damagedVehiclesNr;
        }


        private List<double> getRevenuesForDashboard()
        {
            var revenues = new List<double>();
            DateTime startDate = new DateTime(int.Parse(ddDashboardChart.SelectedItem.ToString()), 01, 01);

            for (int month = 0; month <= 11; month++)
            {
                double revenueForMonth = 0.00;
                var returns = returnBLL.GetAll().Where(x => x.LUD.Month == startDate.AddMonths(month).Month).ToList();

                foreach (var Return in returns)
                {
                    bool hasFee = false;
                    double revenueForReturn = 0.00;
                    foreach (var fee in feeBLL.GetAll())
                    {
                        if (fee.returnID == Return.Rental_ReturnID)
                        {
                            hasFee = true;
                            if (fee.IsPaid)
                            {
                                revenueForReturn = (double)fee.Costs + (double)bookingBLL.Get(Return.BookingID).TotalPrice;
                                hasFee = true;
                            }
                        }
                    }
                    if (hasFee == false)
                    {
                        var booking = bookingBLL.Get(Return.BookingID);
                        revenueForReturn = (double)booking.TotalPrice;
                    }
                    revenueForMonth += revenueForReturn;
                }
                revenues.Add(revenueForMonth);
            }
            return revenues;
        }

        private List<double> getRepairCostsForDashboard()
        {
            var repairCosts = new List<double>();
            DateTime startDate = new DateTime(int.Parse(ddDashboardChart.SelectedItem.ToString()), 01, 01);

            for (int month = 0; month <= 11; month++)
            {
                double repairCostsForMonth = 0.00;
                var repairs = repairBLL.GetAll().Where(x => x.Rental_ReturnID == 0 && x.IsRepaired == true && x.LUD.Month == startDate.AddMonths(month).Month).ToList();

                foreach (var repair in repairs)
                {
                    repairCostsForMonth += (double)repair.Costs;
                }
                repairCosts.Add(repairCostsForMonth);
            }
            return repairCosts;
        }

        private List<double> getDamageCostsForDashboard()
        {
            var damageCosts = new List<double>();
            DateTime startDate = new DateTime(int.Parse(ddDashboardChart.SelectedItem.ToString()), 01, 01);

            for (int month = 0; month <= 11; month++)
            {
                double damageCostsForMonth = 0.00;
                var damageFees = feeBLL.GetAll().Where(x => x.IsLate == false && x.LUD.Month == startDate.AddMonths(month).Month && x.returnID != 0).ToList();

                foreach (var fee in damageFees)
                {
                    damageCostsForMonth += (double)fee.Costs;
                }
                damageCosts.Add(damageCostsForMonth);
            }
            return damageCosts;
        }

        private List<double> getMaintenanceCostsForDashboard()
        {
            var maintenanceCosts = new List<double>();
            DateTime startDate = new DateTime(int.Parse(ddDashboardChart.SelectedItem.ToString()), 01, 01);

            for (int month = 0; month <= 11; month++)
            {
                double maintenanceCostsForMonth = 0.00;
                var maintenances = maintenanceBLL.GetAll().Where(x => x.LUD.Month == startDate.AddMonths(month).Month).ToList();

                foreach (var maintenance in maintenances)
                {
                    maintenanceCostsForMonth += (double)maintenance.Costs;
                }
                maintenanceCosts.Add(maintenanceCostsForMonth);
            }
            return maintenanceCosts;
        }



        //---------  PAGE 3 - VEHICLES  -------------------------------------------------
        //---------- GENERAL ------------------------
        public void manageVehicleState()
        {
            for (int row = 0; row <= dgVehicles.Rows.Count - 1; row++)
            {
                if (dgVehicles.Rows[row].Cells["InGoodCondition"].Value.ToString() == "False")
                {
                    dgVehicles.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
                else if (dgVehicles.Rows[row].Cells["IsAvailable"].Value.ToString() == "False")
                {
                    dgVehicles.Rows[row].Cells[0].Value = Properties.Resources.orangeCircle;
                }
                else
                    dgVehicles.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
            }
        }

        public void initDropDownMake()
        {
            ddVehicleMake.Items.Clear();
            var distinctMakeList = vehicleBrandBLL.GetAll().Select(x => x.Make).Distinct().ToList();
            ddVehicleMake.Items.Add("All");
            foreach (var item in distinctMakeList)
            {
                ddVehicleMake.Items.Add(item);
            }
        }

        private void initModelByMake()
        {
            ddVehicleModel.Items.Clear();
            string selectedMake = ddVehicleMake.SelectedItem.ToString();
            var distinctModelList = vehicleBrandBLL.GetAll().Where(x => x.Make == selectedMake).Select(x => x.Model).Distinct().ToList();
            ddVehicleModel.Items.Add("All");
            foreach (var item in distinctModelList)
            {
                ddVehicleModel.Items.Add(item);
            }
        }

        private void dgVehicles_DataSourceChanged(object sender, EventArgs e)
        {
            manageVehicleState();
            lblVehiclesTotalRecords.Text = $"Total Records: {dgVehicles.RowCount}";
        }

        private void reserveForAClientToolStrip_Click(object sender, EventArgs e)
        {
            int rowIndex = dgVehicles.CurrentRow.Index;
            DataGridViewRow row = dgVehicles.Rows[rowIndex];

            if (row.Cells["IsAvailable"].Value.ToString() == "True" && row.Cells["InGoodCondition"].Value.ToString() == "True")
            {
                Vehicle vehicle = new Vehicle()
                {
                    VehicleID = int.Parse(row.Cells["VehicleID"].Value.ToString().Remove(0, 1)),
                    StringVehicleMake = row.Cells["Make"].Value.ToString(),
                    StringVehicleModel = row.Cells["Model"].Value.ToString()
                };
                string vehicleInfos = vehicle.StringVehicleMake + " " + vehicle.StringVehicleModel;
                FrmReservationsCRUD frmReservations = new FrmReservationsCRUD(dgVehicles, vehicleInfos, this, vehicle.VehicleID);
                frmReservations.Show();
            }
            else
                MessageBox.Show("Vehicle should be available and in good condition to reserve it");
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            FrmVehiclesCRUD frmVehiclesCRUD = new FrmVehiclesCRUD(this,dgVehicles);
            frmVehiclesCRUD.Show();
        }

        private void btnPrintVehicles_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgVehicles);
            generateRaport(finalDataGrid, "Vehicles List");
        }

        private void dgVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgVehicles.Rows[e.RowIndex];
                //----UPDATE
                if (e.ColumnIndex == dgVehicles.ColumnCount - 4)
                {
                    int vehicleID = int.Parse(row.Cells["VehicleID"].Value.ToString().Remove(0, 1));
                    FrmVehiclesCRUD frmVehiclesCRUD = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    frmVehiclesCRUD.Show();
                }
                //-----DELETE
                else if (e.ColumnIndex == dgVehicles.ColumnCount - 2)
                {
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int vehicleID = int.Parse(row.Cells["VehicleID"].Value.ToString().Remove(0, 1));
                        vehicleBLL.Remove(vehicleID);
                        bunifuDeletedMessage();
                        dgVehicles.DataSource = vehicleBLL.GetAll();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void dgVehicles_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        { 
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex , dgVehicles);
        }

        private void btnClearSeatsNr_Click(object sender, EventArgs e)
        {
            includeSeatsNrForFilter = false;
            btnClearSeatsNr.Visible = false;
            filterVehicles();
        }

        private void btnClearProductionYear_Click(object sender, EventArgs e)
        {
            includeProductionyearForFilter = false;
            btnClearProductionYear.Visible = false;
            filterVehicles();
        }


        //-----------------------FILTER------------------------
        List<Vehicle> vehicleCurrentList = new List<Vehicle>();
        bool includeSeatsNrForFilter = false;
        bool includeProductionyearForFilter = false;

        private void ddVehicleMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            initModelByMake();
            filterVehicles();
            changeAllToName(ddVehicleMake, "Make");
        }

        private void ddVehicleModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterVehicles();
            changeAllToName(ddVehicleModel, "Model");
        }

        private void ddVehicleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterVehicles();
            changeAllToName(ddVehicleCategory, "Category");
        }

        private void ddVehicleTransmission_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterVehicles();
            changeAllToName(ddVehicleTransmission, "Transmission");
        }

        private void ddVehicleFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterVehicles();
            changeAllToName(ddVehicleFuelType, "Fuel Type");
        }

        private void ddVehicleSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchVehicle_TextChanged(object sender, EventArgs e)
        {
            filterVehicles();
        }

        private void txtVehicleSearch_OnIconRightClick(object sender, EventArgs e)
        {
            txtVehicleSearch.Clear();
        }

        private void numSeatsNr_ValueChanged(object sender, EventArgs e)
        {
            btnClearSeatsNr.Visible = true;
            includeSeatsNrForFilter = true;
            filterVehicles();
        }

        private void numProductionYear_ValueChanged(object sender, EventArgs e)
        {
            btnClearProductionYear.Visible = true;
            includeProductionyearForFilter = true;
            filterVehicles();
        }

        private void sliderVehiclePrice_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblVehiclePriceBySlider.Text = $"${sliderVehiclePrice.Value}.00";
            filterVehicles();
        }

        private void rbVehicleAvailableAll_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void rbVehicleReserved_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void rbVehicleAvailable_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void rbVehicleConditionAll_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void rbVehicleHealthy_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void rbVehicleDamaged_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void chVehiclesLeftToExpire_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }

        private void cbVehicleMonthsWeeks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chVehiclesLeftToExpire.Checked)
                filterVehicles();
        }

        private void numVehicleNrValue_ValueChanged(object sender, EventArgs e)
        {
            if (chVehiclesLeftToExpire.Checked)
                filterVehicles();
        }

        private void chVehiclesWithoutRegistration_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterVehicles();
        }


        private List<Vehicle> filterVehiclesBySearch(List<Vehicle> tempList)
        {
            if (ddVehicleSearchBy.SelectedItem == null)
                return null;

            if (txtVehicleSearch.Text.Trim() != "")
            {
                txtVehicleSearch.RightIcon.Visible = true;

                switch (ddVehicleSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.VehicleID.ToString().StartsWith(txtVehicleSearch.Text)).ToList();
                        dgVehicles.DataSource = tempList;
                        break;
                    case "Make/Model":
                        tempList = tempList.Where(x => (x.StringVehicleMake.ToUpper() + " " + x.StringVehicleModel.ToUpper()).StartsWith(txtVehicleSearch.Text.ToUpper())).ToList();
                        dgVehicles.DataSource = tempList;
                        break;
                    case "Plate Nr":
                        tempList = tempList.Where(x => x.PlateNr.ToString().ToUpper().StartsWith(txtVehicleSearch.Text.ToUpper())).ToList();
                        dgVehicles.DataSource = tempList;
                        break;
                    case "Mileage":
                        tempList = tempList.Where(x => x.Mileage.ToString().StartsWith(txtVehicleSearch.Text.ToUpper())).ToList();
                        dgVehicles.DataSource = tempList;
                        break;
                    case "Other Infos":
                        tempList = tempList.Where(x => x.OtherInfos.ToString().ToUpper().Contains(txtVehicleSearch.Text.ToUpper())).ToList();
                        dgVehicles.DataSource = tempList;
                        break;
                    default:
                        ddVehicleSearchBy.Focus();
                        break;
                }
            }
            else
            {
                txtVehicleSearch.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterVehicles()
        {
            var tempList = new List<Vehicle>();
            tempList = vehicleBLL.GetAll();

            //-----------VEHICLE MAKE,MODEL,CATEGORY,TRANSMISSION,FUEL TYPE,FILTERING
            if (ddVehicleMake.SelectedIndex != 0 && ddVehicleMake.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StringVehicleMake == ddVehicleMake.SelectedItem.ToString()).ToList();
            if (ddVehicleModel.SelectedIndex != 0 && ddVehicleModel.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StringVehicleModel == ddVehicleModel.SelectedItem.ToString()).ToList();
            if (ddVehicleCategory.SelectedIndex != 0 && ddVehicleCategory.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StringVehicleCategory == ddVehicleCategory.SelectedItem.ToString()).ToList();
            if (ddVehicleTransmission.SelectedIndex != 0 && ddVehicleTransmission.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Transmission == ddVehicleTransmission.SelectedItem.ToString()).ToList();
            if (ddVehicleFuelType.SelectedIndex != 0 && ddVehicleFuelType.SelectedIndex != -1)
                tempList = tempList.Where(x => x.FuelType == ddVehicleFuelType.SelectedItem.ToString()).ToList();


            //-----------VEHICLE SEARCH FILTERING
            var templistSearch = filterVehiclesBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;


            //-----------VEHICLE SEATS NR,PRODUCTION YEAR FILTERING
            if(includeSeatsNrForFilter == true)
                tempList = tempList.Where(x => x.SeatsNr == numSeatsNr.Value).ToList();
            if(includeProductionyearForFilter == true)
                tempList = tempList.Where(x => x.ProductionYear == numProductionYear.Value).ToList();


            //-----------VEHICLE COSTS FILTERING
            if (sliderVehiclePrice.Value != 0)
                tempList = tempList.Where(x => x.DailyPrice >= sliderVehiclePrice.Value && x.DailyPrice <= (sliderVehiclePrice.Value + 0.99M)).ToList();


            //-----------VEHICLE STATE RESERVED,AVAILABLE-HEALTHY,DAMAGED FILTERING
            if(rbVehicleAvailableAll.Checked != true)
            {
                if(rbVehicleAvailable.Checked)
                    tempList = tempList.Where(x => x.IsAvailable == true && x.InGoodCondition == true).ToList();
                if(rbVehicleReserved.Checked)
                    tempList = tempList.Where(x => x.IsAvailable == false && x.InGoodCondition == true).ToList();
                if(rbVehicleHealthy.Checked)
                    tempList = tempList.Where(x => x.InGoodCondition == true).ToList();
                if(rbVehicleDamaged.Checked)
                    tempList = tempList.Where(x => x.InGoodCondition == false).ToList();
            }


            //-----------VEHICLES REGISTRATIONS LEFT TO EXPIRE FILTERING
            if (chVehiclesLeftToExpire.Checked == true)
            {
                tempList = tempList.Where(x => x.VehicleRegistration.ExpirationDate > DateTime.Today && x.VehicleRegistration.ExpirationDate <= DateTime.Today.AddMonths(1)).ToList();
            }


            //-----------VEHICLES WITHOUT REGISTRATIONS FILTERING
            if (chVehiclesWithoutRegistration.Checked == true)
                tempList = tempList.Where(x => x.VehicleRegistration.ExpirationDate <= DateTime.Today).ToList();

            dgVehicles.DataSource = tempList;
            vehicleCurrentList = tempList;

        }

        private void sortVehicles(List<Vehicle> tempList, bool isAscending)
        {
            if (ddVehicleSortBy.SelectedItem == null)
                return;

            switch (ddVehicleSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.VehicleID).ToList() : tempList.OrderByDescending(x => x.VehicleID).ToList();
                    break;
                case "Make":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StringVehicleMake).ToList() : tempList.OrderByDescending(x => x.StringVehicleMake).ToList();
                    break;
                case "Model":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StringVehicleModel).ToList() : tempList.OrderByDescending(x => x.StringVehicleModel).ToList();
                    break;
                case "Category":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StringVehicleCategory).ToList() : tempList.OrderByDescending(x => x.StringVehicleCategory).ToList();
                    break;
                case "Year":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ProductionYear).ToList() : tempList.OrderByDescending(x => x.ProductionYear).ToList();
                    break;
                case "Transmission":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Transmission).ToList() : tempList.OrderByDescending(x => x.Transmission).ToList();
                    break;
                case "Seats Nr":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.SeatsNr).ToList() : tempList.OrderByDescending(x => x.SeatsNr).ToList();
                    break;
                case "Price":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.DailyPrice).ToList() : tempList.OrderByDescending(x => x.DailyPrice).ToList();
                    break;
                case "Mileage":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Mileage).ToList() : tempList.OrderByDescending(x => x.Mileage).ToList();
                    break;
            }
            dgVehicles.DataSource = tempList;
        }


        //-----------------------SORTING------------------------
        private void ddVehicleSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddVehicleAZ.SelectedIndex == 0)
                sortVehicles(vehicleCurrentList, true);
            else
                sortVehicles(vehicleCurrentList, false);
        }

        private void ddVehicleAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddVehicleAZ.SelectedIndex == 0)
                sortVehicles(vehicleCurrentList, true);
            else
                sortVehicles(vehicleCurrentList, false);
        }



        //---------  PAGE 4 - CLIENTS  ---------------------------------
        //---------- GENERAL ------------------------
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            FrmClientsCRUD frmClients = new FrmClientsCRUD(this,dgClients);
            frmClients.Show();
        }

        private void btnPrintClient_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgClients);
            generateRaport(finalDataGrid, "Clients List");
        }

        private void dgClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgClients.Rows[e.RowIndex];
                //----UPDATE
                if (e.ColumnIndex == dgClients.ColumnCount - 4)
                {
                    int clientID = int.Parse(row.Cells["clientID"].Value.ToString().Remove(0, 1));
                    FrmClientsCRUD frmClients = new FrmClientsCRUD(this, clientID, dgClients);
                    frmClients.Show();
                }
                //------DELETE
                else if (e.ColumnIndex == dgClients.ColumnCount - 2)
                {
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int clientID = int.Parse(row.Cells["clientID"].Value.ToString().Remove(0, 1));
                        clientBLL.Remove(clientID);
                        bunifuDeletedMessage();
                        dgClients.DataSource = clientBLL.GetAll();
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void dgClients_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex, dgClients);
        }

        private void dgClients_DataSourceChanged(object sender, EventArgs e)
        {
            lblClientsTotalRecords.Text = $"Total Records: {dgClients.RowCount}";
        }


        //-----------------------FILTER------------------------
        List<Client> clientCurrentList = new List<Client>();

        private void ddAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterClients();
            changeAllToName(ddAge, "Age");
        }

        private void ddClientSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterClients();
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            filterClients();
        }

        private void txtSearchClient_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchClient.Clear();
        }

        private List<Client> filterClientsBySearch(List<Client> tempList)
        {
            if (ddClientSearchBy.SelectedItem == null)
                return null;

            if (txtSearchClient.Text.Trim() != "")
            {
                txtSearchClient.RightIcon.Visible = true;

                switch (ddClientSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.ClientID.ToString().ToUpper().StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    case "Name/Surname":
                        tempList = tempList.Where(x => (x.Name.ToUpper() + " " + x.Surname.ToUpper()).StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    case "Address":
                        tempList = tempList.Where(x => x.Address.ToString().ToUpper().StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    case "Phone Nr":
                        tempList = tempList.Where(x => x.PhoneNr.ToString().ToUpper().StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    case "Driving License":
                        tempList = tempList.Where(x => x.DrivingLicense.ToString().ToUpper().StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    case "Email":
                        tempList = tempList.Where(x => x.Email.ToString().ToUpper().StartsWith(txtSearchClient.Text.ToUpper())).ToList();
                        dgClients.DataSource = tempList;
                        break;
                    default:
                        ddClientSearchBy.Focus();
                        break;
                }
            }
            else
            {
                txtSearchClient.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterClients()
        {
            var tempList = new List<Client>();
            tempList = clientBLL.GetAll();


            //-----------CLIENT AGE FILTERING
            if(ddAge.SelectedIndex != 0 && ddAge.SelectedIndex != -1)
            {
                int fromRange = int.Parse(ddAge.SelectedItem.ToString().Substring(0, 2));
                int toRange = int.Parse(ddAge.SelectedItem.ToString().Remove(0, 5));

                tempList = tempList.Where(x => x.Age >= fromRange && x.Age <= toRange).ToList();
            }


            //-----------BOOKING SEARCH FILTERING
            var templistSearch = filterClientsBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;


            dgClients.DataSource = tempList;
            clientCurrentList = tempList;

        }

        private void sortClients(List<Client> tempList, bool isAscending)
        {
            if (ddClientSortBy.SelectedItem == null)
                return;

            switch (ddClientSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ClientID).ToList() : tempList.OrderByDescending(x => x.ClientID).ToList();
                    break;
                case "Name":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Name).ToList() : tempList.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Surname":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Surname).ToList() : tempList.OrderByDescending(x => x.Surname).ToList();
                    break;
                case "Age":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Age).ToList() : tempList.OrderByDescending(x => x.Age).ToList();
                    break;
                case "Address":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Address).ToList() : tempList.OrderByDescending(x => x.Address).ToList();
                    break;
                case "Phone Nr":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.PhoneNr).ToList() : tempList.OrderByDescending(x => x.PhoneNr).ToList();
                    break;
                case "Driving License":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.DrivingLicense).ToList() : tempList.OrderByDescending(x => x.DrivingLicense).ToList();
                    break;
                case "Email":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Email).ToList() : tempList.OrderByDescending(x => x.Email).ToList();
                    break;
            }
            dgClients.DataSource = tempList;
        }

        //-----------------------SORTING------------------------
        private void ddClientSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddClientAZ.SelectedIndex == 0)
                sortClients(clientCurrentList, true);
            else
                sortClients(clientCurrentList, false);
        }

        private void ddClientAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddClientAZ.SelectedIndex == 0)
                sortClients(clientCurrentList, true);
            else
                sortClients(clientCurrentList, false);
        }



        //---------  PAGE 5 - BOOKINGS  --------------------------
        //---------- GENERAL ------------------------
        private void btnBookingsPage_Click(object sender, EventArgs e)
        {
            if (bunifuPager.PageName != "Bookings")
            {
                changePageTitle("Reservations");
                enableNavigateButtons();
                bunifuPager.SetPage("Bookings");
                customizeStates(bunifuPager.PageName);
                changeIndicatorPosition(btnBookingsPage);
            }
        }

        private void btnRentalsPage_Click(object sender, EventArgs e)
        {
            if (bunifuPager.PageName != "Rentals")
            {
                changePageTitle("Rentals");
                bunifuPager.SetPage("Rentals");
                customizeStates(bunifuPager.PageName);
                var rentals = rentalBLL.GetAll();
                dgRentals.DataSource = rentals;
                rentalCurrentList = rentals;
                changeIndicatorPosition(btnRentalsPage);
            }
        }

        private void btnReturnsPage_Click(object sender, EventArgs e)
        {
            if (bunifuPager.PageName != "Returns")
            {
                changePageTitle("Returns");
                bunifuPager.SetPage("Returns");
                customizeStates(bunifuPager.PageName);
                var returns = hasDamageOrLate();
                dgReturns.DataSource = returns;
                returnCurrentList = returns;
                changeIndicatorPosition(btnReturnsPage);
            }
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            FrmReservationsCRUD frmReservations = new FrmReservationsCRUD(dgBookings,this);
            frmReservations.Show();
        }

        private void btnPrintReservation_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGridSevenCol(dgBookings);
            generateRaport(finalDataGrid, "Reservations List");
        }

        private void cancelReservation_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBookings.CurrentRow.Index;
            DataGridViewRow row = dgBookings.Rows[rowIndex];

            int bookingID = int.Parse(row.Cells["StringBookingID"].Value.ToString().Remove(0, 1));

            if (row.Cells["StatusName"].Value.ToString() != "Active")
                MessageBox.Show("Only active reservations can be canceled");
            else
            {
                Booking booking = new Booking();
                booking.BookingID = bookingID;
                booking.BookingStatusID = 3;
                booking.VehicleID = int.Parse(row.Cells["BookingVehicleID"].Value.ToString());
                bookingBLL.Modify(booking);
                dgBookings.DataSource = bookingBLL.GetAll();
            }
        }

        private void fullDetailsBooking_Click(object sender, EventArgs e)
        {
            int rowIndex = dgBookings.CurrentRow.Index;
            DataGridViewRow row = dgBookings.Rows[rowIndex];
            int bookingID = int.Parse(row.Cells["BookingID"].Value.ToString());

            FrmFullDetails frmDetails = new FrmFullDetails(this,bookingID);
            frmDetails.Show();
        }

        public void disableNavigateButtons()
        {
            btnBookingsPage.Visible = false;
            btnRentalsPage.Visible = false;
            btnReturnsPage.Visible = false;
            reservationPageIndicator.Visible = false;
        }

        private void enableNavigateButtons()
        {
            btnBookingsPage.Visible = true;
            btnRentalsPage.Visible = true;
            btnReturnsPage.Visible = true;
            reservationPageIndicator.Visible = true;
        }

        public void manageBookingState()
        {
            int columnIndex = dgBookings.ColumnCount - 1;
            for (int row = 0; row <= dgBookings.Rows.Count - 1; row++)
            {
                if (dgBookings.Rows[row].Cells[columnIndex].Value.ToString() == "Active")
                {
                    dgBookings.Rows[row].Cells[0].Value = Properties.Resources.orangeCircle;
                }
                else if (dgBookings.Rows[row].Cells[columnIndex].Value.ToString() == "Finished")
                {
                    dgBookings.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
                }
                else if (dgBookings.Rows[row].Cells[columnIndex].Value.ToString() == "Canceled")
                {
                    dgBookings.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
            }
        }

        private void changeIndicatorPosition(Control control)
        {
            reservationPageIndicator.Width = control.Width - 8;
            reservationPageIndicator.Left = control.Location.X + 5;
        }

        private bool isEarlyRental(int bookingID)
        {
            Booking booking = bookingBLL.Get(bookingID);
            if (DateTime.Now.Date < booking.RentalDate.Date)
                return true;
            else
                return false;
        }

        private bool validateBeforeRental(DataGridViewRow row)
        {
            int bookingID = int.Parse(row.Cells["BookingID"].Value.ToString());
            if (row.Cells["StatusName"].Value.ToString() == "Finished")
            {
                MessageBox.Show("You cannot create more than one rental for a reservation");
                return false;
            }
            else if (row.Cells["StatusName"].Value.ToString() == "Canceled")
            {
                MessageBox.Show("You cannot create rental from a canceled reservation");
                return false;
            }
            else if (isEarlyRental(bookingID))
            {
                MessageBox.Show("Car cannot be rented before rental date,please update rental date");
                return false;
            }
            return true;
        }

        private void cancelReservationsWithLateRentals()
        {
            var bookings = bookingBLL.GetAll();
            foreach (var booking in bookings)
            {
                if(booking.BookingStatusID == 1 && booking.RentalDate.Date < DateTime.Today.Date)
                {
                    booking.BookingStatusID = 3;
                    booking.VehicleID = booking.VehicleID;
                    bookingBLL.Modify(booking);
                }
            }
        }

        private void dgBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgBookings.Rows[e.RowIndex];
                int bookingID = int.Parse(row.Cells["BookingID"].Value.ToString());
                //--------RENTAL
                if (e.ColumnIndex == dgBookings.ColumnCount - 7)
                {
                    if (validateBeforeRental(row) == true)
                    {
                        FrmRentalCRUD frmRental = new FrmRentalCRUD(this, bookingID, dgBookings, easyHTMLReports1);
                        frmRental.Show();
                    }
                }
                //-------UPDATE
                else if (e.ColumnIndex == dgBookings.ColumnCount - 5)
                {
                    if (row.Cells["StatusName"].Value.ToString() != "Active")
                    {
                        MessageBox.Show("Only active reservations can be updated");
                    }
                    else
                    {
                        Booking booking = new Booking()
                        {
                            BookingID = bookingID,
                            ClientID = int.Parse(row.Cells["BookingClientID"].Value.ToString()),
                            clientInfos = row.Cells["ClientInfos"].Value.ToString(),
                            VehicleID = int.Parse(row.Cells["BookingVehicleID"].Value.ToString()),
                            vehicleInfos = row.Cells["VehicleInfos"].Value.ToString(),
                            RentalDate = DateTime.Parse(row.Cells["BookingRentalDate"].Value.ToString()),
                            ReturnDate = DateTime.Parse(row.Cells["BookingReturnDate"].Value.ToString())
                        };
                        FrmReservationsCRUD frmReservations = new FrmReservationsCRUD(dgBookings, booking, this);
                        frmReservations.Show();
                    }
                }
                //--------DELETE
                else if (e.ColumnIndex == dgBookings.ColumnCount - 3)
                {
                    if (row.Cells["StatusName"].Value.ToString() != "Active")
                    {
                        MessageBox.Show("Only active reservations can be deleted");
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            bookingBLL.Remove(bookingID);
                            BunifuMessage.show(this, "Deleted Successfully.", BunifuSnackbar.MessageTypes.Success);
                            dgBookings.DataSource = bookingBLL.GetAll();
                        }
                    }
                }
                //----WATCH VEHICLE INFOS
                if (e.ColumnIndex == 6)
                {
                    int vehicleID = int.Parse(row.Cells[7].Value.ToString());
                    FrmVehiclesCRUD viewVehicle = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    viewVehicle.Show();
                }
                //----WATCH CLIENT INFOS
                else if (e.ColumnIndex == 4)
                {
                    int clientID = int.Parse(row.Cells[5].Value.ToString());
                    FrmClientsCRUD viewClient = new FrmClientsCRUD(this, clientID, dgClients);
                    viewClient.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgBookings_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable2(e.ColumnIndex, dgBookings);
        }

        private void dgBookings_DataSourceChanged(object sender, EventArgs e)
        {
            manageBookingState();
            lblBookingsTotalRecords.Text = $"Total Records: {dgBookings.RowCount}";
        }


        //-----------------------FILTER------------------------
        List<Booking> bookingCurrentList = new List<Booking>();

        private void ddBookingState_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingState, "State");
        }

        private void ddBookingSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
        }

        private void txtSearchBooking_TextChanged(object sender, EventArgs e)
        {
            filterBookings();
        }

        private void txtSearchBooking_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchBooking.Clear();
        }

        private void sliderBookingPrice_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblPriceByBookingSlider.Text = $"${sliderBookingPrice.Value}.00";
            filterBookings();
        }

        private void ddBookingsCreateMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddBookingsCreateDay, ddBookingsCreateMonth.SelectedIndex);
            filterBookings();
            changeAllToName(ddBookingsCreateMonth, "Month");
        }

        private void ddBookingsCreateDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsCreateDay, "Day");
        }

        private void ddBookingsCreateYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsCreateYear, "Year");
        }

        private void ddBookingsRentalMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddBookingsRentalDay, ddBookingsRentalMonth.SelectedIndex);
            filterBookings();
            changeAllToName(ddBookingsRentalMonth, "Month");
        }

        private void ddBookingsRentalDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsRentalDay, "Day");
        }

        private void ddBookingsRentalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsRentalYear, "Year");
        }

        private void ddBookingsReturnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddBookingsReturnDay, ddBookingsReturnMonth.SelectedIndex);
            filterBookings();
            changeAllToName(ddBookingsReturnMonth, "Month");
        }

        private void ddBookingsReturnDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsReturnDay, "Day");
        }

        private void ddBookingsReturnYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBookings();
            changeAllToName(ddBookingsReturnYear, "Year");
        }

        private List<Booking> filterBookingsBySearch(List<Booking> tempList)
        {
            if (ddBookingSearchBy.SelectedItem == null)
                return null;

            if (txtSearchBooking.Text.Trim() != "")
            {
                txtSearchBooking.RightIcon.Visible = true;

                switch (ddBookingSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.BookingID.ToString().StartsWith(txtSearchBooking.Text)).ToList();
                        dgBookings.DataSource = tempList;
                        break;
                    case "Client":
                        tempList = tempList.Where(x => (x.clientInfos.ToUpper()).StartsWith(txtSearchBooking.Text.ToUpper())).ToList();
                        dgBookings.DataSource = tempList;
                        break;
                    case "Vehicle":
                        tempList = tempList.Where(x => x.vehicleInfos.ToString().ToUpper().StartsWith(txtSearchBooking.Text.ToUpper())).ToList();
                        dgBookings.DataSource = tempList;
                        break;
                    case "Price":
                        tempList = tempList.Where(x => x.TotalPrice.ToString().StartsWith(txtSearchBooking.Text.ToUpper())).ToList();
                        dgBookings.DataSource = tempList;
                        break;
                    default:
                        dgBookings.Focus();
                        break;
                }
            }
            else
            {
                txtSearchBooking.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterBookings()
        {
            var tempList = new List<Booking>();
            tempList = bookingBLL.GetAll();

            //-----------BOOKING STATE FILTERING
            if (ddBookingState.SelectedIndex != 0 && ddBookingState.SelectedIndex != -1)
                tempList = tempList.Where(x => x.BookingStatusID == ddBookingState.SelectedIndex).ToList();


            //-----------BOOKING SEARCH FILTERING
            var templistSearch = filterBookingsBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;

            //-----------BOOKING PRICE FILTERING
            if (sliderBookingPrice.Value != 0)
                tempList = tempList.Where(x => x.TotalPrice >= sliderBookingPrice.Value && x.TotalPrice <= (sliderBookingPrice.Value + 0.99M)).ToList();

            //-----------BOOKING CREATED DATE FILTERING
            if (ddBookingsCreateMonth.SelectedIndex != 0 && ddBookingsCreateMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.BookingDate.Month == ddBookingsCreateMonth.SelectedIndex).ToList();
            if (ddBookingsCreateDay.SelectedIndex != 0 && ddBookingsCreateDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.BookingDate.Day == ddBookingsCreateDay.SelectedIndex).ToList();
            if (ddBookingsCreateYear.SelectedIndex != 0 && ddBookingsCreateYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.BookingDate.Year == int.Parse(ddBookingsCreateYear.SelectedItem.ToString())).ToList();

            //-----------BOOKING RENTAL DATE FILTERING
            if (ddBookingsRentalMonth.SelectedIndex != 0 && ddBookingsRentalMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.RentalDate.Month == ddBookingsRentalMonth.SelectedIndex).ToList();
            if (ddBookingsRentalDay.SelectedIndex != 0 && ddBookingsRentalDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.RentalDate.Day == ddBookingsRentalDay.SelectedIndex).ToList();
            if (ddBookingsRentalYear.SelectedIndex != 0 && ddBookingsRentalYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.RentalDate.Year == int.Parse(ddBookingsRentalYear.SelectedItem.ToString())).ToList();

            //-----------BOOKING RETURN DATE FILTERING
            if (ddBookingsReturnMonth.SelectedIndex != 0 && ddBookingsReturnMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Month == ddBookingsReturnMonth.SelectedIndex).ToList();
            if (ddBookingsReturnDay.SelectedIndex != 0 && ddBookingsReturnDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Day == ddBookingsReturnDay.SelectedIndex).ToList();
            if (ddBookingsReturnYear.SelectedIndex != 0 && ddBookingsReturnYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Year == int.Parse(ddBookingsReturnYear.SelectedItem.ToString())).ToList();


            dgBookings.DataSource = tempList;
            bookingCurrentList = tempList;

        }

        private void sortBookings(List<Booking> tempList, bool isAscending)
        {
            if (ddBookingSortBy.SelectedItem == null)
                return;

            switch (ddBookingSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.BookingID).ToList() : tempList.OrderByDescending(x => x.BookingID).ToList();
                    break;
                case "Client":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.clientInfos).ToList() : tempList.OrderByDescending(x => x.clientInfos).ToList();
                    break;
                case "Vehicle":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.vehicleInfos).ToList() : tempList.OrderByDescending(x => x.vehicleInfos).ToList();
                    break;
                case "Price":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.TotalPrice).ToList() : tempList.OrderByDescending(x => x.TotalPrice).ToList();
                    break;
                case "Created Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.BookingDate).ToList() : tempList.OrderByDescending(x => x.BookingDate).ToList();
                    break;
                case "Rental Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.RentalDate).ToList() : tempList.OrderByDescending(x => x.RentalDate).ToList();
                    break;
                case "Return Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ReturnDate).ToList() : tempList.OrderByDescending(x => x.ReturnDate).ToList();
                    break;
            }
            dgBookings.DataSource = tempList;
        }


        //-----------------------SORTING------------------------
        private void ddBookingSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBookingAZ.SelectedIndex == 0)
                sortBookings(bookingCurrentList, true);
            else
                sortBookings(bookingCurrentList, false);
        }

        private void ddBookingAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBookingAZ.SelectedIndex == 0)
                sortBookings(bookingCurrentList, true);
            else
                sortBookings(bookingCurrentList, false);
        }



        //---------  PAGE 6 - BOOKINGS/RENTALS  ---------------------------------
        //---------- GENERAL ------------------------
        public void manageBookingStateRental()
        {
            int columnIndex = dgRentals.ColumnCount - 1;
            for (int row = 0; row <= dgRentals.Rows.Count - 1; row++)
            {
                if (dgRentals.Rows[row].Cells[columnIndex].Value.ToString() == "True")
                {
                    dgRentals.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
                }
                else if (dgRentals.Rows[row].Cells[columnIndex].Value.ToString() == "False")
                {
                    dgRentals.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
            }
        }

        private bool doesReturnExist(int bookingID)
        {
            List<Rental_Return> returns = new List<Rental_Return>();
            returns = returnBLL.GetAll().Where(x => x.BookingID == bookingID).ToList();
            if (returns.Any() == true)
                return true;
            else
                return false;
        }

        private void fullDetailsRental_Click(object sender, EventArgs e)
        {
            int rowIndex = dgRentals.CurrentRow.Index;
            DataGridViewRow row = dgRentals.Rows[rowIndex];
            int rentalID = int.Parse(row.Cells["RentalID"].Value.ToString().Remove(0,1));

            FrmFullDetails frmDetails = new FrmFullDetails(this, rentalID, true);
            frmDetails.Show();
        }

        private void dgRentals_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable3(e.ColumnIndex, e.RowIndex, dgRentals);
        }

        private void dgRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgRentals.Rows[e.RowIndex];
                int rentalID = int.Parse(row.Cells["RentalID"].Value.ToString().Remove(0, 1));
                int bookingID = int.Parse(row.Cells["RentalBookingID"].Value.ToString());

                //----WATCH VEHICLE INFOS
                if (e.ColumnIndex == 6)
                {
                    int vehicleID = int.Parse(row.Cells[4].Value.ToString());
                    FrmVehiclesCRUD viewVehicle = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    viewVehicle.Show();
                }
                //----WATCH CLIENT INFOS
                else if (e.ColumnIndex == 5)
                {
                    int clientID = int.Parse(row.Cells[3].Value.ToString());
                    FrmClientsCRUD viewClient = new FrmClientsCRUD(this, clientID, dgClients);
                    viewClient.Show();
                }
                //-----CREATE RETURN
                else if (e.ColumnIndex == dgRentals.ColumnCount - 3)
                {
                    if (doesReturnExist(bookingID))
                    {
                        MessageBox.Show("There is a return created from this rental,you cannot create more");
                    }
                    else
                    {
                        FrmReturnCRUD frmReturn = new FrmReturnCRUD(this, rentalID, dgRentals);
                        frmReturn.Show();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgRentals_DataSourceChanged(object sender, EventArgs e)
        {
            manageBookingStateRental();
            lblRentalsTotalRecords.Text = $"Total Records: {dgRentals.RowCount}";
        }

        private void btnPrintRental_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGridThreeCol(dgRentals);
            generateRaport(finalDataGrid, "Rentals List");
        }


        //-----------------------FILTER------------------------
        List<Rental_Return> rentalCurrentList = new List<Rental_Return>();
        private void ddRentalState_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRentals();
            changeAllToName(ddRentalState, "State");
        }

        private void ddRentalSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRentals();
        }

        private void txtSearchRental_TextChanged(object sender, EventArgs e)
        {
            filterRentals();
        }

        private void txtSearchRental_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchRental.Clear();
        }

        private void sliderRentalFuel_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblRentalFuelBySlider.Text = $"{sliderRentalFuel.Value}.0L";
            filterRentals();
        }

        private void ddRentalMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddRentalDay, ddRentalMonth.SelectedIndex);
            filterRentals();
            changeAllToName(ddRentalMonth, "Month");
        }

        private void ddRentalDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRentals();
            changeAllToName(ddRentalDay, "Day");
        }

        private void ddRentalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRentals();
            changeAllToName(ddRentalYear, "Year");
        }

        private List<Rental_Return> filterRentalsBySearch(List<Rental_Return> tempList)
        {
            if (ddRentalSearchBy.SelectedItem == null)
                return null;

            if (txtSearchRental.Text.Trim() != "")
            {
                txtSearchRental.RightIcon.Visible = true;

                switch (ddRentalSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.Rental_ReturnID.ToString().StartsWith(txtSearchRental.Text)).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    case "Client":
                        tempList = tempList.Where(x => (x.clientInfos.ToUpper()).StartsWith(txtSearchRental.Text.ToUpper())).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    case "Vehicle":
                        tempList = tempList.Where(x => x.vehicleInfos.ToString().ToUpper().StartsWith(txtSearchRental.Text.ToUpper())).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    case "Date":
                        tempList = tempList.Where(x => x.Date.ToString().StartsWith(txtSearchRental.Text.ToUpper())).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    case "Fuel Amount":
                        tempList = tempList.Where(x => x.FuelAmount.ToString().StartsWith(txtSearchRental.Text.ToUpper())).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    case "Mileage":
                        tempList = tempList.Where(x => x.Mileage.ToString().StartsWith(txtSearchRental.Text.ToUpper())).ToList();
                        dgRentals.DataSource = tempList;
                        break;
                    default:
                        dgRentals.Focus();
                        break;
                }
            }
            else
            {
                txtSearchRental.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterRentals()
        {
            var tempList = new List<Rental_Return>();
            tempList = rentalBLL.GetAll();

            //-----------RENTAL STATE FILTERING
            if (ddRentalState.SelectedIndex != 0 && ddRentalState.SelectedIndex != -1)
                tempList = ddRentalState.SelectedIndex == 1 ? tempList.Where(x => x.IsClosed == false).ToList() : tempList.Where(x => x.IsClosed == true).ToList();


            //-----------RENTAL SEARCH FILTERING
            var templistSearch = filterRentalsBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;

            //-----------RENTAL FUEL FILTERING
            if (sliderRentalFuel.Value != 0)
                tempList = tempList.Where(x => x.FuelAmount >= sliderRentalFuel.Value && x.FuelAmount <= (sliderRentalFuel.Value + 0.9M)).ToList();

            //-----------RENTAL DATE FILTERING
            if (ddRentalMonth.SelectedIndex != 0 && ddRentalMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Month == ddRentalMonth.SelectedIndex).ToList();
            if (ddRentalDay.SelectedIndex != 0 && ddRentalDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Day == ddRentalDay.SelectedIndex).ToList();
            if (ddRentalYear.SelectedIndex != 0 && ddRentalYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Year == int.Parse(ddRentalYear.SelectedItem.ToString())).ToList();


            dgRentals.DataSource = tempList;
            rentalCurrentList = tempList;

        }

        private void sortRentals(List<Rental_Return> tempList, bool isAscending)
        {
            if (ddRentalSortBy.SelectedItem == null)
                return;

            switch (ddRentalSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Rental_ReturnID).ToList() : tempList.OrderByDescending(x => x.Rental_ReturnID).ToList();
                    break;
                case "Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Date).ToList() : tempList.OrderByDescending(x => x.Date).ToList();
                    break;
                case "Client":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.clientInfos).ToList() : tempList.OrderByDescending(x => x.clientInfos).ToList();
                    break;
                case "Vehicle":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.vehicleInfos).ToList() : tempList.OrderByDescending(x => x.vehicleInfos).ToList();
                    break;
                case "Fuel Amount":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.FuelAmount).ToList() : tempList.OrderByDescending(x => x.FuelAmount).ToList();
                    break;
                case "Mileage":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Mileage).ToList() : tempList.OrderByDescending(x => x.Mileage).ToList();
                    break;
            }
            dgRentals.DataSource = tempList;
        }


        //-----------------------SORTING------------------------
        private void ddRentalSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRentalAZ.SelectedIndex == 0)
                sortRentals(rentalCurrentList, true);
            else
                sortRentals(rentalCurrentList, false);
        }

        private void ddRentalAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRentalAZ.SelectedIndex == 0)
                sortRentals(rentalCurrentList, true);
            else
                sortRentals(rentalCurrentList, false);
        }



        //---------  PAGE 7 - BOOKINGS/RETURNS  ---------------------------------
        //---------- GENERAL ------------------------
        public void manageBookingStateReturn()
        {
            int columnIndex = dgReturns.ColumnCount - 1;
            for (int row = 0; row <= dgReturns.Rows.Count - 1; row++)
            {
                if (dgReturns.Rows[row].Cells[columnIndex].Value.ToString() == "True")
                {
                    dgReturns.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
                }
                else if (dgReturns.Rows[row].Cells[columnIndex].Value.ToString() == "False")
                {
                    dgReturns.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
            }
        }

        public List<Rental_Return> hasDamageOrLate()
        {
            var returnsList = returnBLL.GetAll();
            foreach (var item in returnsList)
            {
                var fees = feeBLL.GetAll().Where(x => x.returnID == item.Rental_ReturnID).ToList();
                foreach (var fee in fees)
                {
                    if (fee.IsLate == true)
                        item.returnedLate = true;
                    else
                        item.hasDamage = true;
                }
            }
            return returnsList;
        }

        private void closeTransactionReturn_Click(object sender, EventArgs e)
        {
            int rowIndex = dgReturns.CurrentRow.Index;
            DataGridViewRow row = dgReturns.Rows[rowIndex];
            int returnID = int.Parse(row.Cells[1].Value.ToString().Remove(0, 1));

            var repair = repairBLL.GetAll().Where(x => x.Rental_ReturnID == returnID).FirstOrDefault();
            var lateFee = feeBLL.GetAll().Where(x => x.returnID == returnID).Where(x => x.IsLate == true).FirstOrDefault();
            var damageFee = feeBLL.GetAll().Where(x => x.returnID == returnID).Where(x => x.IsLate == false).FirstOrDefault();

            if (row.Cells["IsClosed"].Value.ToString() == "True")
            {
                MessageBox.Show("Transaction is already closed");
                return;
            }
            if(repair == null && damageFee != null)
            {
                MessageBox.Show("This return resulted in damage and there is no repair created for the damaged car,please create repair and make sure you close the " +
                    "repair transaction first");
                return;
            }    
            if(repair != null)
            {
                if (repair.IsRepaired == false)
                {
                    MessageBox.Show("Please close the repair transaction first");
                    return;
                }
            }
            if (repair != null || lateFee != null)
            {
                FrmCloseTransaction frmCloseTran = new FrmCloseTransaction(this,lateFee, damageFee, returnID ,dgReturns);
                frmCloseTran.Show();
            }
            else
                MessageBox.Show("No damage or late");
        }

        private void createRepairForDamage_Click(object sender, EventArgs e)
        {
            int rowIndex = dgReturns.CurrentRow.Index;
            DataGridViewRow row = dgReturns.Rows[rowIndex];
            int returnID = int.Parse(row.Cells["StringReturnID"].Value.ToString().Remove(0, 1));

            if (row.Cells["IsClosed"].Value.ToString() == "True")
            {
                MessageBox.Show("You cannot create repair for closed transactions");
                return;
            }

            FrmCreateRepair frmRepair = new FrmCreateRepair(this,returnID);
            frmRepair.Show();
        }

        private void fullDetailsReturn_Click(object sender, EventArgs e)
        {
            int rowIndex = dgReturns.CurrentRow.Index;
            DataGridViewRow row = dgReturns.Rows[rowIndex];
            int returnID = int.Parse(row.Cells["StringReturnID"].Value.ToString().Remove(0, 1));

            FrmFullDetails frmDetails = new FrmFullDetails(this,returnID,false);
            frmDetails.Show();
        }

        private void dgReturns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgReturns.Rows[e.RowIndex];
                //----WATCH VEHICLE INFOS
                if (e.ColumnIndex == 6)
                {
                    int vehicleID = int.Parse(row.Cells[4].Value.ToString());
                    FrmVehiclesCRUD viewVehicle = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    viewVehicle.Show();
                }
                //----WATCH CLIENT INFOS
                else if (e.ColumnIndex == 5)
                {
                    int clientID = int.Parse(row.Cells[3].Value.ToString());
                    FrmClientsCRUD viewClient = new FrmClientsCRUD(this, clientID, dgClients);
                    viewClient.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgReturns_DataSourceChanged(object sender, EventArgs e)
        {
            manageBookingStateReturn();
            lblReturnsTotalRecords.Text = $"Total Records: {dgReturns.RowCount}";
        }

        private void btnPrintReturn_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGridOneCol(dgReturns);
            generateRaport(finalDataGrid, "Returns List");
        }


        //-----------------------FILTER------------------------
        List<Rental_Return> returnCurrentList = new List<Rental_Return>();

        private void ddReturnState_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterReturns();
            changeAllToName(ddReturnState, "State");
        }

        private void ddReturnSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterReturns();
        }

        private void txtSearchReturn_TextChanged(object sender, EventArgs e)
        {
            filterReturns();
        }

        private void txtSearchReturn_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchReturn.Clear();
        }

        private void ddReturnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddReturnDay, ddReturnMonth.SelectedIndex);
            filterReturns();
            changeAllToName(ddReturnMonth, "Month");
        }

        private void ddReturnDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterReturns();
            changeAllToName(ddReturnDay, "Day");
        }

        private void ddReturnYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterReturns();
            changeAllToName(ddReturnYear, "Year");
        }

        private void chReturnIsLate_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbPaidByClientYes_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbPaidByClientNo_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void chReturnDamages_CheckedChanged(object sender, BunifuCheckBox.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbReturnNoRepair_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbReturnRepairCreated_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbReturnRepairFinished_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private void rbReturnDamagePaid_CheckedChanged2(object sender, BunifuRadioButton.CheckedChangedEventArgs e)
        {
            filterReturns();
        }

        private List<Rental_Return> filterReturnsBySearch(List<Rental_Return> tempList)
        {
            if (ddReturnSearchBy.SelectedItem == null)
                return null;

            if (txtSearchReturn.Text.Trim() != "")
            {
                txtSearchReturn.RightIcon.Visible = true;

                switch (ddReturnSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.Rental_ReturnID.ToString().StartsWith(txtSearchReturn.Text)).ToList();
                        dgReturns.DataSource = tempList;
                        break;
                    case "Client":
                        tempList = tempList.Where(x => (x.clientInfos.ToUpper()).StartsWith(txtSearchReturn.Text.ToUpper())).ToList();
                        dgReturns.DataSource = tempList;
                        break;
                    case "Vehicle":
                        tempList = tempList.Where(x => x.vehicleInfos.ToString().ToUpper().StartsWith(txtSearchReturn.Text.ToUpper())).ToList();
                        dgReturns.DataSource = tempList;
                        break;
                    case "Fuel Amount":
                        tempList = tempList.Where(x => x.FuelAmount.ToString().StartsWith(txtSearchReturn.Text.ToUpper())).ToList();
                        dgReturns.DataSource = tempList;
                        break;
                    case "Mileage":
                        tempList = tempList.Where(x => x.Mileage.ToString().StartsWith(txtSearchReturn.Text.ToUpper())).ToList();
                        dgReturns.DataSource = tempList;
                        break;
                    default:
                        dgReturns.Focus();
                        break;
                }
            }
            else
            {
                txtSearchReturn.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterReturns()
        {
            //var tempList = new List<Rental_Return>();
            //tempList = returnBLL.GetAll();
            var tempList = hasDamageOrLate();

            //-----------RETURN STATE FILTERING
            if (ddReturnState.SelectedIndex != 0 && ddReturnState.SelectedIndex != -1)
                tempList = ddReturnState.SelectedIndex == 1 ? tempList.Where(x => x.IsClosed == false).ToList() : tempList.Where(x => x.IsClosed == true).ToList();


            //-----------RETURN SEARCH FILTERING
            var templistSearch = filterReturnsBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;


            //-----------RETURN DATE FILTERING
            if (ddReturnMonth.SelectedIndex != 0 && ddReturnMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Month == ddReturnMonth.SelectedIndex).ToList();
            if (ddReturnDay.SelectedIndex != 0 && ddReturnDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Day == ddReturnDay.SelectedIndex).ToList();
            if (ddReturnYear.SelectedIndex != 0 && ddReturnYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.Date.Year == int.Parse(ddReturnYear.SelectedItem.ToString())).ToList();


            //-----------RETURN LATE FILTERING
            if(chReturnIsLate.Checked == true)
            {
                bool isPaid = false;          
                if (rbPaidByClientYes.Checked)
                    isPaid = true;

                var newList = new List<Rental_Return>();
                var fees = feeBLL.GetAll().Where(x => x.IsLate == true).ToList();

                foreach (var Return in tempList)
                {
                    foreach (var fee in fees)
                    {
                        if (fee.returnID == Return.Rental_ReturnID && fee.IsPaid == isPaid)
                            newList.Add(Return);
                    }
                }
                tempList = newList;
            }


            //-----------RETURN DAMAGES FILTERING
            if(chReturnDamages.Checked == true)
            {
                var newList = new List<Rental_Return>();
                var fees = feeBLL.GetAll().Where(x => x.IsLate == false).ToList();
                var repairs = repairBLL.GetAll().ToList();
                bool repairExist = false;

                if(rbReturnNoRepair.Checked)
                {
                    foreach (var Return in tempList.ToList())
                    {
                        bool hasFee = false;
                        foreach (var fee in fees)
                        {
                            if(Return.Rental_ReturnID == fee.returnID)
                            {
                                hasFee = true;
                                foreach (var repair in repairs.ToList())
                                {
                                    if (fee.returnID == repair.Rental_ReturnID)
                                    {
                                        repairExist = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (repairExist == false && hasFee == true)
                            newList.Add(Return);
                    }
                    tempList = newList;
                }
                if(rbReturnRepairCreated.Checked)
                {
                    foreach (var Return in tempList.ToList())
                    {
                        foreach (var repair in repairs.ToList())
                        {
                            if (Return.Rental_ReturnID == repair.Rental_ReturnID && repair.IsRepaired == false)
                                newList.Add(Return);
                        }
                    }
                    tempList = newList;
                }
                if(rbReturnRepairFinished.Checked)
                {
                    foreach (var Return in tempList.ToList())
                    {
                        foreach (var repair in repairs.ToList())
                        {
                            if (Return.Rental_ReturnID == repair.Rental_ReturnID && repair.IsRepaired == true)
                            {
                                foreach (var fee in fees)
                                {
                                    if(repair.Rental_ReturnID == fee.returnID && fee.IsPaid == false)
                                        newList.Add(Return);
                                }
                            }
                        }
                    }
                    tempList = newList;
                }
                if(rbReturnDamagePaid.Checked)
                {
                    foreach (var Return in tempList.ToList())
                    {
                        foreach (var fee in fees.ToList())
                        {
                            if (Return.Rental_ReturnID == fee.returnID && fee.IsPaid == true)
                                newList.Add(Return);
                        }
                    }
                    tempList = newList;
                }
                
            }

            dgReturns.DataSource = tempList;
            returnCurrentList = tempList;
        }

        private void sortReturns(List<Rental_Return> tempList, bool isAscending)
        {
            if (ddReturnSortBy.SelectedItem == null)
                return;

            switch (ddReturnSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Rental_ReturnID).ToList() : tempList.OrderByDescending(x => x.Rental_ReturnID).ToList();
                    break;
                case "Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Date).ToList() : tempList.OrderByDescending(x => x.Date).ToList();
                    break;
                case "Client":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.clientInfos).ToList() : tempList.OrderByDescending(x => x.clientInfos).ToList();
                    break;
                case "Vehicle":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.vehicleInfos).ToList() : tempList.OrderByDescending(x => x.vehicleInfos).ToList();
                    break;
                case "Fuel Amount":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.FuelAmount).ToList() : tempList.OrderByDescending(x => x.FuelAmount).ToList();
                    break;
                case "Mileage":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Mileage).ToList() : tempList.OrderByDescending(x => x.Mileage).ToList();
                    break;
            }
            dgReturns.DataSource = tempList;
        }


        //-----------------------SORTING------------------------
        private void ddReturnAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddReturnAZ.SelectedIndex == 0)
                sortReturns(returnCurrentList, true);
            else
                sortReturns(returnCurrentList, false);
        }

        private void ddReturnSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddReturnAZ.SelectedIndex == 0)
                sortReturns(returnCurrentList, true);
            else
                sortReturns(returnCurrentList, false);
        }



        //---------  PAGE 8 - MAINTENANCES  ---------------------------------
        //---------- GENERAL ------------------------
        public void manageMaintenanceState()
        {
            for (int row = 0; row <= dgMaintenances.Rows.Count - 1; row++)
            {
                if (dgMaintenances.Rows[row].Cells[1].Value.ToString() == "True")
                {
                    dgMaintenances.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
                }
                else if (dgMaintenances.Rows[row].Cells[1].Value.ToString() == "False")
                {
                    dgMaintenances.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
            }
        }

        private bool checkIfClosed(int rowIndex,BunifuDataGridView dg)
        {
            DataGridViewRow row = dg.Rows[rowIndex];
            if (row.Cells[1].Value.ToString() == "True")
            {
                MessageBox.Show("You cannot modify a closed transaction");
                return true;
            }
            else
                return false;
        }

        private void closeTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = dgMaintenances.CurrentRow.Index;
            DataGridViewRow row = dgMaintenances.Rows[rowIndex];
            int maintenanceID = int.Parse(row.Cells["MaintenanceID"].Value.ToString().Remove(0, 1));

            if (row.Cells[1].Value.ToString() == "True")
            {
                MessageBox.Show("You cannot modify a closed transaction");
                return ;
            }

            if (row.Cells["Costs"].Value.ToString() == "0.00" || row.Cells["ReturnDate"].Value?.ToString() == null)
                MessageBox.Show("Costs or Return Date cannot be empty");
            else
            {
                Maintenance maintenance = new Maintenance();
                maintenance.MaintenanceID = maintenanceID;
                maintenance.VehicleID = int.Parse(row.Cells["MaintenanceVehicleID"].Value.ToString());
                maintenance.IsReturned = true;
                maintenanceBLL.Modify(maintenance);
                dgMaintenances.DataSource = maintenanceBLL.GetAll();
            }
        }

        private void dgMaintenances_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex, dgMaintenances);
        }

        private void dgMaintenances_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgMaintenances.Rows[e.RowIndex];
                //---UPDATE
                if (e.ColumnIndex == dgMaintenances.ColumnCount - 4)
                {
                    if (checkIfClosed(e.RowIndex, dgMaintenances))
                        return;
                    int maintenanceID = int.Parse(row.Cells[2].Value.ToString().Remove(0, 1));
                    FrmMaintenancesCRUD frmMaintenance = new FrmMaintenancesCRUD(maintenanceID, dgMaintenances, this);
                    frmMaintenance.Show();
                }
                //----WATCH VEHICLE INFOS
                else if (e.ColumnIndex == 7)
                {
                    int vehicleID = int.Parse(row.Cells[5].Value.ToString());
                    FrmVehiclesCRUD viewVehicle = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    viewVehicle.Show();
                }
                //------DELETE
                else if (e.ColumnIndex == dgMaintenances.ColumnCount - 2)
                {
                    if (checkIfClosed(e.RowIndex, dgMaintenances))
                        return;
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int maintenanceID = int.Parse(row.Cells[2].Value.ToString().Remove(0, 1));
                        maintenanceBLL.Remove(maintenanceID);
                        BunifuMessage.show(this, "Deleted Successfully.", BunifuSnackbar.MessageTypes.Success, 800);
                        dgMaintenances.DataSource = maintenanceBLL.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgMaintenances_DataSourceChanged(object sender, EventArgs e)
        {
            manageMaintenanceState();
            lblMaintenancesTotalRecords.Text = $"Total Records: {dgMaintenances.RowCount}";
        }

        private void btnAddMaintenance_Click(object sender, EventArgs e)
        {
            FrmMaintenancesCRUD frmMaintenance = new FrmMaintenancesCRUD(dgMaintenances,this);
            frmMaintenance.Show();
        }

        private void btnPrintMaintenances_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgMaintenances);
            generateRaport(finalDataGrid, "Maintenances List");
        }

        private void maintenanceSetSelectedIndexes()
        {
            ddMaintenanceState.SelectedIndex = 0;
            ddMaintenanceAZ.SelectedIndex = 0;
            ddMaintenanceStartDay.SelectedIndex = 0;
            ddMaintenanceReturnDay.SelectedIndex = 0;
        }


        //-----------------------FILTER------------------------
        List<Maintenance> maintenanceCurrentList = new List<Maintenance>();

        private void ddMaintenanceState_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
            changeAllToName(ddMaintenanceState, "State");
        }

        private void ddMaintenanceSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
        }

        private void txtSearchMaintenance_TextChanged(object sender, EventArgs e)
        {
            filterMaintenances();
        }


        private void ddMaintenanceStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddMaintenanceStartDay, ddMaintenanceStartMonth.SelectedIndex);
            filterMaintenances();
            changeAllToName(ddMaintenanceStartMonth, "Month");
        }

        private void ddMaintenanceStartDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
            changeAllToName(ddMaintenanceStartDay, "Day");
        }

        private void ddMaintenanceStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
            changeAllToName(ddMaintenanceStartYear, "Year");
        }


        private void ddMaintenanceReturnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateDaysByMonth(ddMaintenanceReturnDay, ddMaintenanceReturnMonth.SelectedIndex);
            filterMaintenances();
            changeAllToName(ddMaintenanceReturnMonth, "Month");
        }

        private void ddMaintenanceReturnDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
            changeAllToName(ddMaintenanceReturnDay, "Day");
        }

        private void ddMaintenanceReturnYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterMaintenances();
            changeAllToName(ddMaintenanceReturnYear, "Year");
        }


        private void sliderMaintenanceCosts_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblMaintenanceCostsBySlider.Text = $"${sliderMaintenanceCosts.Value}.00";
            filterMaintenances();
        }

        private void txtSearchMaintenance_OnIconRightClick(object sender, EventArgs e)
        {
            txtSearchMaintenance.Clear();
        }


        private List<Maintenance> filterMaintenancesBySearch(List<Maintenance> tempList)
        {
            if (ddMaintenanceSearchBy.SelectedItem == null)
                return null;

            if (txtSearchMaintenance.Text.Trim() != "")
            {
                txtSearchMaintenance.RightIcon.Visible = true;

                switch (ddMaintenanceSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.MaintenanceID.ToString().StartsWith(txtSearchMaintenance.Text.ToUpper())).ToList();
                        dgMaintenances.DataSource = tempList;
                        break;
                    case "Company Name":
                        tempList = tempList.Where(x => (x.ResponsibleCompany.ToUpper()).StartsWith(txtSearchMaintenance.Text.ToUpper())).ToList();
                        dgMaintenances.DataSource = tempList;
                        break;
                    case "Description":
                        tempList = tempList.Where(x => x.Description.ToString().ToUpper().StartsWith(txtSearchMaintenance.Text.ToUpper())).ToList();
                        dgMaintenances.DataSource = tempList;
                        break;
                    case "Costs":
                        tempList = tempList.Where(x => x.Costs.ToString().StartsWith(txtSearchMaintenance.Text.ToUpper())).ToList();
                        dgMaintenances.DataSource = tempList;
                        break;
                    case "Vehicle":
                        tempList = tempList.Where(x => x.VehicleInfos.ToString().ToUpper().StartsWith(txtSearchMaintenance.Text.ToUpper())).ToList();
                        dgMaintenances.DataSource = tempList;
                        break;
                    default:
                        ddMaintenanceSearchBy.Focus();
                        break;
                }
            }
            else
            {
                txtSearchMaintenance.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterMaintenances()
        {
            var tempList = new List<Maintenance>();

            //-----------MAINTENANCE STATE FILTERING
            if (ddMaintenanceState.SelectedIndex == 0)
            {
                tempList = maintenanceBLL.GetAll();
                ddMaintenanceState.Text = "State";
            }
            else if (ddMaintenanceState.SelectedIndex == 1)
            {
                tempList = maintenanceBLL.GetAll().Where(x => x.IsReturned == false).ToList();
            }
            else if (ddMaintenanceState.SelectedIndex == 2)
            {
                tempList = maintenanceBLL.GetAll().Where(x => x.IsReturned == true).ToList();
            }

            //-----------MAINTENANCE SEARCH FILTERING
            var templistSearch = filterMaintenancesBySearch(tempList);
            if (templistSearch != null)
                tempList = templistSearch;

            //-----------MAINTENANCE START DATE FILTERING
            if (ddMaintenanceStartMonth.SelectedIndex != 0 && ddMaintenanceStartMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Month == ddMaintenanceStartMonth.SelectedIndex).ToList();
            if (ddMaintenanceStartDay.SelectedIndex != 0 && ddMaintenanceStartDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Day == ddMaintenanceStartDay.SelectedIndex).ToList();
            if (ddMaintenanceStartYear.SelectedIndex != 0 && ddMaintenanceStartYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Year == int.Parse(ddMaintenanceStartYear.SelectedItem.ToString())).ToList();

            //-----------MAINTENANCE RETURN DATE FILTERING
            if (ddMaintenanceReturnMonth.SelectedIndex != 0 && ddMaintenanceReturnMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Month == ddMaintenanceReturnMonth.SelectedIndex).ToList();
            if (ddMaintenanceReturnDay.SelectedIndex != 0 && ddMaintenanceReturnDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Day == ddMaintenanceReturnDay.SelectedIndex).ToList();
            if (ddMaintenanceReturnYear.SelectedIndex != 0 && ddMaintenanceReturnYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Year == int.Parse(ddMaintenanceReturnYear.SelectedItem.ToString())).ToList();

            //-----------MAINTENANCE COSTS FILTERING
            if (sliderMaintenanceCosts.Value != 0)
                tempList = tempList.Where(x => x.Costs >= sliderMaintenanceCosts.Value && x.Costs <= (sliderMaintenanceCosts.Value + 0.99M)).ToList();

            dgMaintenances.DataSource = tempList;
            maintenanceCurrentList = tempList;

        }

        private void sortMaintenances(List<Maintenance> tempList, bool isAscending)
        {
            if (ddMaintenanceSortBy.SelectedItem == null)
                return;

            switch (ddMaintenanceSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.MaintenanceID).ToList() : tempList.OrderByDescending(x => x.MaintenanceID).ToList();
                    break;
                case "Company Name":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ResponsibleCompany).ToList() : tempList.OrderByDescending(x => x.ResponsibleCompany).ToList();
                    break;
                case "Description":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Description).ToList() : tempList.OrderByDescending(x => x.Description).ToList();
                    break;
                case "Costs":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Costs).ToList() : tempList.OrderByDescending(x => x.Costs).ToList();
                    break;
                case "Vehicle":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.VehicleInfos).ToList() : tempList.OrderByDescending(x => x.VehicleInfos).ToList();
                    break;
                case "Start Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StartDate).ToList() : tempList.OrderByDescending(x => x.StartDate).ToList();
                    break;
                case "Return Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ReturnDate).ToList() : tempList.OrderByDescending(x => x.ReturnDate).ToList();
                    break;
            }
            dgMaintenances.DataSource = tempList;
        }


        //-----------------------SORTING------------------------
        private void ddMaintenanceSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddMaintenanceAZ.SelectedIndex == 0)
                sortMaintenances(maintenanceCurrentList, true);
            else
                sortMaintenances(maintenanceCurrentList, false);
        }

        private void ddMaintenanceAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddMaintenanceAZ.SelectedIndex == 0)
                sortMaintenances(maintenanceCurrentList, true);
            else
                sortMaintenances(maintenanceCurrentList, false);
        }



        //-------- PAGE 9 REPAIRS  ---------------------------------
        //-----------------------GENERAL------------------------
        public void manageRepairState()
        {
            for (int row = 0; row <= dgRepairs.Rows.Count - 1; row++)
            {
                if (dgRepairs.Rows[row].Cells[1].Value.ToString() == "True")
                {
                    dgRepairs.Rows[row].Cells[0].Value = Properties.Resources.greenCircle;
                }
                else if (dgRepairs.Rows[row].Cells[1].Value.ToString() == "False")
                {
                    dgRepairs.Rows[row].Cells[0].Value = Properties.Resources.redCircle;
                }
            }
        }

        private void repairSetSelectedIndexes()
        {
            ddRepairState.SelectedIndex = 0;
            ddRepairAZ.SelectedIndex = 0;
            ddRepairStartDay.SelectedIndex = 0;
            ddRepairReturnDay.SelectedIndex = 0;
        }

        private void closeTransactionRepair_Click(object sender, EventArgs e)
        {
            int rowIndex = dgRepairs.CurrentRow.Index;
            DataGridViewRow row = dgRepairs.Rows[rowIndex];

            if (row.Cells[1].Value.ToString() == "True")
            {
                MessageBox.Show("You cannot modify a closed transaction");
                return;
            }

            if (row.Cells["RepairCosts"].Value.ToString() == "0.00" || row.Cells["RepairReturnDate"].Value == null)
                MessageBox.Show("Costs or Return Date cannot be empty");
            else
            {
                int repairID = int.Parse(row.Cells[2].Value.ToString().Remove(0, 1));
                Repair repair = new Repair();
                repair.RepairID = repairID;
                repair.IsRepaired = true;
                repair.Rental_ReturnID = int.Parse(row.Cells["rental_returnID"].Value.ToString());
                repair.Costs = decimal.Parse(row.Cells["RepairCosts"].Value.ToString());
                repair.ReturnDate = DateTime.Parse(row.Cells["RepairReturnDate"].Value.ToString());
                repairBLL.Modify(repair);
                dgRepairs.DataSource = repairBLL.GetAll();
                BunifuMessage.show(this, "Successfully Closed the Transaction", BunifuSnackbar.MessageTypes.Success);
            }
        }

        private void btnAddRepair_Click(object sender, EventArgs e)
        {
            FrmRepairsCRUD frmRepair = new FrmRepairsCRUD(dgRepairs, this);
            frmRepair.Show();
        }

        private void btnPrintRepairs_Click(object sender, EventArgs e)
        {
            DataGridView finalDataGrid = CloneDataGrid(dgRepairs);
            generateRaport(finalDataGrid, "Repairs List");
        }

        private void dgRepairs_DataSourceChanged(object sender, EventArgs e)
        {
            manageRepairState();
            lblRepairsTotalRecords.Text = $"Total Records: {dgRepairs.RowCount}";
        }

        private void dgRepairs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgRepairs.ColumnCount - 4)
                {
                    DataGridViewRow row = dgRepairs.Rows[e.RowIndex];
                    if (checkIfClosed(e.RowIndex, dgRepairs))
                        return;
                    int repairID = int.Parse(row.Cells[2].Value.ToString().Remove(0, 1));
                    FrmRepairsCRUD frmRepairs = new FrmRepairsCRUD(repairID, dgRepairs, this);
                    frmRepairs.Show();
                }
                else if (e.ColumnIndex == 8)
                {
                    DataGridViewRow row = dgRepairs.Rows[e.RowIndex];
                    int vehicleID = int.Parse(row.Cells[5].Value.ToString());
                    FrmVehiclesCRUD viewVehicle = new FrmVehiclesCRUD(this, dgVehicles, vehicleID);
                    viewVehicle.Show();
                }
                else if (e.ColumnIndex == dgRepairs.ColumnCount - 2)
                {
                    if (checkIfClosed(e.RowIndex, dgRepairs))
                        return;
                    if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataGridViewRow row = dgRepairs.Rows[e.RowIndex];
                        int repairID = int.Parse(row.Cells[2].Value.ToString().Remove(0, 1));
                        repairBLL.Remove(repairID);
                        BunifuMessage.show(this, "Deleted Successfully.", BunifuSnackbar.MessageTypes.Success);
                        dgRepairs.DataSource = repairBLL.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgRepairs_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            UIGeneralHelper.makeColumnImageClickable(e.ColumnIndex, e.RowIndex, dgRepairs);
        }


        //-----------------------FILTER------------------------
        List<Repair> repairCurrentList = new List<Repair>();

        private void ddRepairState_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
            changeAllToName(ddRepairState, "State");
        }

        private void ddRepairSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
        }

        private void txtRepairSearch_TextChanged(object sender, EventArgs e)
        {
            filterRepairs();
        }


        private void ddRepairStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            repairValidateDaysByMonthStart(ddRepairStartMonth.SelectedIndex);
            filterRepairs();
            changeAllToName(ddRepairStartMonth, "Month");
        }

        private void ddRepairStartDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
            changeAllToName(ddMaintenanceStartDay, "Day");
        }

        private void ddRepairStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
            changeAllToName(ddMaintenanceStartYear, "Year");
        }


        private void ddRepairReturnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ddRepairReturnMonth.SelectedIndex;
            repairValidateDaysByMonthReturn(selectedIndex);
            filterRepairs();
            changeAllToName(ddRepairReturnMonth, "Month");
        }

        private void ddRepairReturnDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
            changeAllToName(ddRepairReturnDay, "Day");
        }

        private void ddRepairReturnYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRepairs();
            changeAllToName(ddRepairReturnYear, "Year");
        }


        private List<Repair> filterRepairsBySearch(List<Repair> tempList)
        {
            if (ddRepairSearchBy.SelectedItem == null)
                return null;

            if (txtRepairSearch.Text.Trim() != "")
            {
                txtRepairSearch.RightIcon.Visible = true;

                switch (ddRepairSearchBy.SelectedItem.ToString())
                {
                    case "ID":
                        tempList = tempList.Where(x => x.RepairID.ToString().StartsWith(txtRepairSearch.Text.ToUpper())).ToList();
                        dgRepairs.DataSource = tempList;
                        break;
                    case "Company Name":
                        tempList = tempList.Where(x => (x.ResponsibleCompany.ToUpper()).StartsWith(txtRepairSearch.Text.ToUpper())).ToList();
                        dgRepairs.DataSource = tempList;
                        break;
                    case "Description":
                        tempList = tempList.Where(x => x.Description.ToString().ToUpper().StartsWith(txtRepairSearch.Text.ToUpper())).ToList();
                        dgRepairs.DataSource = tempList;
                        break;
                    case "Costs":
                        tempList = tempList.Where(x => x.Costs.ToString().StartsWith(txtRepairSearch.Text.ToUpper())).ToList();
                        dgRepairs.DataSource = tempList;
                        break;
                    case "Vehicle":
                        tempList = tempList.Where(x => x.VehicleInfos.ToString().ToUpper().StartsWith(txtRepairSearch.Text.ToUpper())).ToList();
                        dgRepairs.DataSource = tempList;
                        break;
                    default:
                        ddRepairSearchBy.Focus();
                        break;
                }
            }
            else
            {
                txtRepairSearch.RightIcon.Visible = false;
            }
            return tempList;
        }

        private void filterRepairs()
        {
            var tempList = new List<Repair>();

            //-----------REPAIR STATE FILTERING
            if (ddRepairState.SelectedIndex == 0)
            {
                tempList = repairBLL.GetAll();
                ddRepairState.Text = "State";
            }
            else if (ddRepairState.SelectedIndex == 1)
            {
                tempList = repairBLL.GetAll().Where(x => x.IsRepaired == false).ToList();
            }
            else if (ddRepairState.SelectedIndex == 2)
            {
                tempList = repairBLL.GetAll().Where(x => x.IsRepaired == true).ToList();
            }

            //-----------REPAIR SEARCH FILTERING
            var tempListSearch = filterRepairsBySearch(tempList);
            if (tempListSearch != null)
                tempList = tempListSearch;


            //-----------REPAIR START DATE FILTERING
            if (ddRepairStartMonth.SelectedIndex != 0 && ddRepairStartMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Month == ddRepairStartMonth.SelectedIndex).ToList();
            if (ddRepairStartDay.SelectedIndex != 0 && ddRepairStartDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Day == ddRepairStartDay.SelectedIndex).ToList();
            if (ddRepairStartYear.SelectedIndex != 0 && ddRepairStartYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.StartDate.Year == int.Parse(ddRepairStartYear.SelectedItem.ToString())).ToList();

            //-----------REPAIR RETURN DATE FILTERING
            if (ddRepairReturnMonth.SelectedIndex != 0 && ddRepairReturnMonth.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Month == ddRepairReturnMonth.SelectedIndex).ToList();
            if(ddRepairReturnDay.SelectedIndex != 0 && ddRepairReturnDay.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Day == ddRepairReturnDay.SelectedIndex).ToList();
            if (ddRepairReturnYear.SelectedIndex != 0 && ddRepairReturnYear.SelectedIndex != -1)
                tempList = tempList.Where(x => x.ReturnDate.Year == int.Parse(ddRepairReturnYear.SelectedItem.ToString())).ToList();

            //-----------REPAIR COSTS FILTERING
            if (sliderRepairCosts.Value != 0)
                tempList = tempList.Where(x => x.Costs >= sliderRepairCosts.Value && x.Costs <= (sliderRepairCosts.Value + 0.99M)).ToList();

            dgRepairs.DataSource = tempList;
            repairCurrentList = tempList;

        }

        private void sortRepairs(List<Repair> tempList,bool isAscending)
        {
            if (ddRepairSortBy.SelectedItem == null)
                return;

            switch (ddRepairSortBy.SelectedItem.ToString())
            {
                case "ID":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.RepairID).ToList() : tempList.OrderByDescending(x => x.RepairID).ToList();
                    break;
                case "Company Name":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ResponsibleCompany).ToList() : tempList.OrderByDescending(x => x.ResponsibleCompany).ToList();
                    break;
                case "Description":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Description).ToList() : tempList.OrderByDescending(x => x.Description).ToList();
                    break;
                case "Costs":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.Costs).ToList() : tempList.OrderByDescending(x => x.Costs).ToList();
                    break;
                case "Vehicle":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.VehicleInfos).ToList() : tempList.OrderByDescending(x => x.VehicleInfos).ToList();
                    break;
                case "Start Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.StartDate).ToList() : tempList.OrderByDescending(x => x.StartDate).ToList();
                    break;
                case "Return Date":
                    tempList = isAscending == true ? tempList.OrderBy(x => x.ReturnDate).ToList() : tempList.OrderByDescending(x => x.ReturnDate).ToList();
                    break;
            }
            dgRepairs.DataSource = tempList;
        }


        private void repairValidateDaysByMonthReturn(int selectedIndex)
        {
            ddRepairReturnDay.Items.Clear();
            ddRepairReturnDay.Text = "Day";
            if (selectedIndex == 2)
            {
                ddRepairReturnDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 28))
                {
                    ddRepairReturnDay.Items.Add(item);
                }
            }
            else if (selectedIndex == 4 || selectedIndex == 6 || selectedIndex == 9 || selectedIndex == 11)
            {
                ddRepairReturnDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 30))
                {
                    ddRepairReturnDay.Items.Add(item);
                }
            }
            else if (selectedIndex == 0 || selectedIndex == 1 || selectedIndex == 3 || selectedIndex == 5 || selectedIndex == 7 || selectedIndex == 8 || selectedIndex == 10 || selectedIndex == 12)
            {
                ddRepairReturnDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 31))
                {
                    ddRepairReturnDay.Items.Add(item);
                }
            }
        }

        private void repairValidateDaysByMonthStart(int selectedIndex)
        {
            ddRepairStartDay.Items.Clear();
            ddRepairStartDay.Text = "Day";
            if (selectedIndex == 2)
            {
                ddRepairStartDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 28))
                {
                    ddRepairStartDay.Items.Add(item);
                }
            }
            else if (selectedIndex == 4 || selectedIndex == 6 || selectedIndex == 9 || selectedIndex == 11)
            {
                ddRepairStartDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 30))
                {
                    ddRepairStartDay.Items.Add(item);
                }
            }
            else if (selectedIndex == 0 || selectedIndex == 1 || selectedIndex == 3 || selectedIndex == 5 || selectedIndex == 7 || selectedIndex == 8 || selectedIndex == 10 || selectedIndex == 12)
            {
                ddRepairStartDay.Items.Add("All");
                foreach (var item in Enumerable.Range(1, 31))
                {
                    ddRepairStartDay.Items.Add(item);
                }
            }
        }

        private void sliderRepairCosts_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {
            lblRepairCostsBySlider.Text = $"${sliderRepairCosts.Value}.00";
            filterRepairs();
        }

        private void txtRepairSearch_OnIconRightClick(object sender, EventArgs e)
        {
            txtRepairSearch.Clear();
        }


        //-----------------------SORTING------------------------
        private void ddRepairSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRepairAZ.SelectedIndex == 0)
                sortRepairs(repairCurrentList, true);
            else
                sortRepairs(repairCurrentList, false);
        }

        private void ddRepairAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddRepairAZ.SelectedIndex == 0)
                sortRepairs(repairCurrentList, true);
            else
                sortRepairs(repairCurrentList, false);
        }



        //------------ PAGE 10 - USER ACCOUNT INFO  ------------------------
        public void initDataAccInfo()
        {
            lblAccountInfoUsername.Text = $"Username: {UserSession.CurrentUser.Username}";
            lblAccountInfoRole.Text = $"Role: {UserSession.CurrentUser.Role.Name}";

            if (UserSession.CurrentUser.LastLoginDate.ToString() != "1/1/0001 12:00:00 AM")
                lblAccountInfoLastLogin.Text = $"Last Login Date:  {UserSession.CurrentUser.LastLoginDate.ToString("d MMM HH:mm")}";
            if (UserSession.CurrentUser.LastPasswordChangeDate.ToString() != "1/1/0001 12:00:00 AM")
                lblAccountInfoPwChangedDate.Text = $"Last Password Changed Date:  {UserSession.CurrentUser.LastPasswordChangeDate.ToString("d MMM HH:mm")}";
        }



        //------------ PAGE 11 - CHANGE PASSWORD  ------------------------
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            changePassword();
        }

        private void changePassword()
        {
            string actualPassword = txtActualPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string Username = UserSession.CurrentUser.Username;

            if (actualPassword != "" && newPassword != "" && confirmPassword != "")
            {
                if (newPassword != confirmPassword)
                {
                    BunifuMessage.show(this, "Your new password and confirmation password do not match.", BunifuSnackbar.MessageTypes.Error);
                    return;
                }
                bool Result = UserBLL.ChangePassword(Username, actualPassword, newPassword);
                if (Result)
                    BunifuMessage.show(this, "Password Changed Successfully", BunifuSnackbar.MessageTypes.Success,1500);
                else
                    BunifuMessage.show(this, "An Error Has Ocurred,Please Try Again", BunifuSnackbar.MessageTypes.Error);

                txtActualPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            }
        }



        //------------ PAGE 12 - REPORTS  ------------------------

        private void btnReports_Click(object sender, EventArgs e)
        {
            bunifuPager.SetPage("Reports");
            changeLeftMenuIndicatorPosition(btnReports);
            disableNavigateButtons();
            disablePageStates();

            int test = bunifuPager.TabCount;
        }

        private void btnDailyReports_Click(object sender, EventArgs e)
        {
            int days = DateTime.DaysInMonth(dpDailyReports.Value.Year, dpDailyReports.Value.Month);
            double[] totalIncomes = new double[days];
            double[] totalExpenses = new double[days];
            int[] bookings = new int[days];
            int[] rentals = new int[days];
            int[] returns = new int[days];
            int[] maintenances = new int[days];
            int[] repairs = new int[days];

            easyHTMLReports1.Clear();
            easyHTMLReports1.AddImage(Properties.Resources.Logo2);
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString($"<h3>{dpDailyReports.Value:MMM} {dpDailyReports.Value.Year} Daily Reports</h3>");

            DataTable dt = new DataTable();
            dt.Columns.Add("Day");
            dt.Columns.Add("Reservations");
            dt.Columns.Add("Rentals");
            dt.Columns.Add("Returns");
            dt.Columns.Add("Maintenances");
            dt.Columns.Add("Repairs");
            dt.Columns.Add("Total Incomes");
            dt.Columns.Add("Total Expenses");
            dt.Columns.Add("Balance");

            for (int i = 0; i < days; i++)
            {
                DateTime startDate = new DateTime(dpDailyReports.Value.Year, dpDailyReports.Value.Month, i + 1);
                totalIncomes[i] = getDailyIncomes(startDate);
                totalExpenses[i] = getDailyExpenses(startDate);
                bookings[i] = bookingBLL.GetAll().Where(x => x.InsertDate.Date == startDate.Date).Count();
                rentals[i] = rentalBLL.GetAll().Where(x => x.InsertDate.Date == startDate.Date).Count();
                returns[i] = returnBLL.GetAll().Where(x => x.InsertDate.Date == startDate.Date).Count();
                maintenances[i] = maintenanceBLL.GetAll().Where(x => x.InsertDate.Date == startDate.Date).Count();
                repairs[i] = repairBLL.GetAll().Where(x => x.InsertDate.Date == startDate.Date).Count();

                dt.Rows.Add( startDate.ToString("dddd, dd MMMM yyyy"), bookings[i], rentals[i], returns[i], maintenances[i], repairs[i], $"${totalIncomes[i]:0.00}", $"${totalExpenses[i]:0.00}", $"${(totalIncomes[i] - totalExpenses[i]):0.00}" );
                double test1 = 0.00;
                string test = test1.ToString();
            }

            DataTable dt2 = dt.Clone();
            dt2.Columns.RemoveAt(0);
            dt2.Rows.Add(bookings.Sum(), rentals.Sum(), returns.Sum(), maintenances.Sum(), repairs.Sum(), $"${totalIncomes.Sum():0.00}", $"${totalExpenses.Sum():0.00}", $"${(totalIncomes.Sum() - totalExpenses.Sum()):0.00}");

            easyHTMLReports1.AddDataTable(dt);
            easyHTMLReports1.AddString("<h4>Summary</h4>");
            easyHTMLReports1.AddDataTable(dt2);
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void btnMonthlyReports_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddImage(Properties.Resources.Logo2);
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString($"<h4>Monthly Report for year {ddReportsYear.SelectedItem}</h4>");
            easyHTMLReports1.AddHorizontalRule();
            DataTable dt = new DataTable();
            dt.Columns.Add("Month");
            dt.Columns.Add("Reservations");
            dt.Columns.Add("Rentals");
            dt.Columns.Add("Returns");
            dt.Columns.Add("Maintenances");
            dt.Columns.Add("Repairs");
            dt.Columns.Add("Total Incomes");
            dt.Columns.Add("Total Expenses");
            dt.Columns.Add("Balance");

            double[] totalIncomes = new double[12];
            double[] totalExpenses = new double[12];
            int[] bookings = new int[12];
            int[] rentals = new int[12];
            int[] returns = new int[12];
            int[] maintenances = new int[12];
            int[] repairs = new int[12];

            for (int i = 1; i < 12; i++)
            {
                DateTime startDate = new DateTime(int.Parse(ddReportsYear.SelectedItem.ToString()), i, 01);

                bookings[i] = bookingBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).Count();
                rentals[i] = rentalBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).Count();
                returns[i] = returnBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).Count();
                maintenances[i] = maintenanceBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).Count();
                repairs[i] = repairBLL.GetAll().Where(x => x.InsertDate.Year == startDate.Year && x.InsertDate.Month == i).Count();

                totalIncomes[i] = getMonthlyIncomes(startDate,i);
                totalExpenses[i] = getMonthlyExpenses(startDate,i);
                dt.Rows.Add( startDate.ToString("MMM") ,bookings[i], rentals[i], returns[i], maintenances[i], repairs[i], $"${totalIncomes[i]:0.00}", $"${totalExpenses[i]:0.00}", $"${(totalIncomes[i] - totalExpenses[i]):0.00}");
            }

            DataTable dt2 = dt.Clone();
            dt2.Columns.RemoveAt(0);
            dt2.Rows.Add( bookings.Sum(), rentals.Sum(), returns.Sum(), maintenances.Sum(), repairs.Sum(), $"${totalIncomes.Sum():0.00}", $"${totalExpenses.Sum():0.00}", $"${(totalIncomes.Sum() - totalExpenses.Sum()):0.00}" );

            easyHTMLReports1.AddDataTable(dt);
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString($"<h5>Summary</h>");
            easyHTMLReports1.AddDataTable(dt2);
            easyHTMLReports1.ShowPrintPreviewDialog();
        }
   
    }
}
