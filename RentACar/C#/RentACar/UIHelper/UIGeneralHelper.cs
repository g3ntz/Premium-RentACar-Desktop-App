using Bunifu.UI.WinForms;
using RentACar.BO.Entities;
using System.Drawing;
using System.Windows.Forms;
using RentACar.Properties;
using System.Collections.Generic;
using RentACar.App_Folder;

namespace RentACar.UIHelper
{
    public static class UIGeneralHelper
    {
        public static void makeColumnImageClickable(int columnIndex, int rowIndex,  BunifuDataGridView dataGrid)
        {
            if ((columnIndex == dataGrid.ColumnCount - 4 || columnIndex == dataGrid.ColumnCount - 2) && rowIndex != -1)
                dataGrid.Cursor = Cursors.Hand;
            else
                dataGrid.Cursor = Cursors.Default;
        }

        public static void makeColumnImageClickable2(int e, BunifuDataGridView dataGrid)
        {
            if (e == dataGrid.ColumnCount - 3 || e == dataGrid.ColumnCount - 5 || e == dataGrid.ColumnCount - 7)
                dataGrid.Cursor = Cursors.Hand;
            else
                dataGrid.Cursor = Cursors.Default;
        }

        public static void makeColumnImageClickable3(int e,int rowIndex, BunifuDataGridView dataGrid)
        {
            if (e == dataGrid.ColumnCount - 3 && rowIndex != -1)
                dataGrid.Cursor = Cursors.Hand;
            else
                dataGrid.Cursor = Cursors.Default;
        }

        public static void disableDataGridSelectionColor(BunifuDataGridView datagrid)
        {
            datagrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        }

        public static void disableColumnResizing(BunifuDataGridView datagrid)
        {
            datagrid.Columns[datagrid.ColumnCount - 1].Resizable = DataGridViewTriState.False;
            datagrid.Columns[datagrid.ColumnCount - 2].Resizable = DataGridViewTriState.False;
            datagrid.Columns[datagrid.ColumnCount - 3].Resizable = DataGridViewTriState.False;
            datagrid.Columns[datagrid.ColumnCount - 4].Resizable = DataGridViewTriState.False;
        }

        public static void customizeDataGrid(BunifuDataGridView datagrid)
        {
            disableDataGridSelectionColor(datagrid);
            disableColumnResizing(datagrid);
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public static void isSavedSuccessfully(bool result, Form parentForm, Form actualForm, string text = "Successfully Saved.")
        {
            if (result != true)
                BunifuMessage.show(actualForm, "Something went wrong.", BunifuSnackbar.MessageTypes.Error);
            else
            {
                BunifuMessage.show(parentForm, text , BunifuSnackbar.MessageTypes.Success,700);
                actualForm.Close();
            }
        }
    }
}
