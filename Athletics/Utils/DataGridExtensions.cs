using System.Windows.Controls;

namespace Athletics.Utils
{
    public static class DataGridExtensions
    {
        public static string GetDynamicPropertyValueFromTextBox(this DataGrid datagrid, int columnindex, string txtboxname)
        {
            ContentPresenter myCp = datagrid.Columns[columnindex].GetCellContent(datagrid.SelectedItem) as ContentPresenter;
            var myTemplate = myCp.ContentTemplate;
            TextBox txtbox = myTemplate.FindName(txtboxname, myCp) as TextBox;
            return txtbox.Text;
        }
        public static int GetDynamicPropertyValueFromComboBox(this DataGrid datagrid, int columnindex, string txtboxname)
        {
            ContentPresenter myCp = datagrid.Columns[columnindex].GetCellContent(datagrid.SelectedItem) as ContentPresenter;
            var myTemplate = myCp.ContentTemplate;
            ComboBox combobox = myTemplate.FindName(txtboxname, myCp) as ComboBox;
            return combobox.SelectedIndex;
        }
    }
}
