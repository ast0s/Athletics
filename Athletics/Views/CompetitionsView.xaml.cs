using Athletics.Database;
using Athletics.Models;
using Athletics.Models.Enums;
using Athletics.Repositories;
using Athletics.Utils;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Athletics.Views
{
    public partial class CompetitionsView : Window
    {
        public CompetitionsView()
        {
            InitializeComponent();
            CompetitionRepository cr = new CompetitionRepository();
            ShowList.ItemsSource = cr.GetAll();

            status__combo_box.ItemsSource = Enum.GetValues(typeof(StatusType)).Cast<StatusType>();
        }

        private void See_Protocol_Button_Click(object sender, RoutedEventArgs e)
        {
            Competition competition = (sender as Button).DataContext as Competition;
            CompetitionDisciplinesView cdv = new CompetitionDisciplinesView(competition);

            cdv.Show();
        }
        private void competition_status__data_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = Enum.GetValues(typeof(StatusType)).Cast<StatusType>();

            Competition competition = comboBox.DataContext as Competition;
            comboBox.SelectedIndex = (int)competition.StatusType;
        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Competition competition = (sender as Button).DataContext as Competition;

            CompetitionRepository cr = new CompetitionRepository();
            try
            {
                competition.StatusType = (StatusType)ShowList.GetDynamicPropertyValueFromComboBox(0, "competition_status__data");
                competition.Name = ShowList.GetDynamicPropertyValueFromTextBox(1, "competition_name__data");
                competition.Location = ShowList.GetDynamicPropertyValueFromTextBox(2, "competition_location__data");
                competition.Country = ShowList.GetDynamicPropertyValueFromTextBox(3, "competition_country__data");
                competition.BegginingDate = DateTime.Parse(ShowList.GetDynamicPropertyValueFromTextBox(4, "competition_beggining__data"));
                competition.EndingDate = DateTime.Parse(ShowList.GetDynamicPropertyValueFromTextBox(5, "competition_ending__data"));

                cr.Update(competition);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowList.ItemsSource = cr.GetAll();
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Competition competition = (sender as Button).DataContext as Competition;
            CompetitionRepository cr = new CompetitionRepository();
            cr.Remove(competition);
            ShowList.ItemsSource = cr.GetAll();
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitionRepository cr = new CompetitionRepository();

            try
            {
                cr.Add(new Competition
                {
                    Status = status__combo_box.Text,
                    Name = competition_name__txt_box.Text,
                    Location = competition_location__txt_box.Text,
                    Country = competition_country__txt_box.Text,
                    BegginingDate = new DateTime(int.Parse(beggining_year__txt_box.Text), int.Parse(beggining_month__txt_box.Text), int.Parse(beggining_day__txt_box.Text), int.Parse(beggining_hour__txt_box.Text), int.Parse(beggining_minute__txt_box.Text), 0),
                    EndingDate = new DateTime(int.Parse(ending_year__txt_box.Text), int.Parse(ending_month__txt_box.Text), int.Parse(ending_day__txt_box.Text), int.Parse(ending_hour__txt_box.Text), int.Parse(ending_minute__txt_box.Text), 0)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowList.ItemsSource = cr.GetAll();
            }
        }
    }
}
