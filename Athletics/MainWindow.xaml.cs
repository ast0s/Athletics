using Athletics.Views;
using System.Windows;

namespace Athletics
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CompetitionsView cv = new CompetitionsView();

            cv.Show();
            Hide();
            cv.Closed += (e, args) => Close();
        }
    }
}
