using Athletics.Models;
using Athletics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Athletics.Views
{
    public partial class CompetitionDisciplinesView : Window
    {
        private List<string> referees;
        private List<string> disciplines;
        private List<string> categories;
        public CompetitionDisciplinesView(Competition competition)
        {
            InitializeComponent();
            CompetitionDisciplineRepository competitionDisciplineRepository = new CompetitionDisciplineRepository();
            ShowList.ItemsSource = competitionDisciplineRepository.GetAllWithDataByCompetition(competition);

            DisciplineRepository disciplineRepository = new DisciplineRepository();
            disciplines = disciplineRepository.GetAll().Select(item => item.Name).ToList();
            discipline__combo_box.ItemsSource = disciplines;

            RequirementRepository requirementRepository = new RequirementRepository();
            categories = requirementRepository.GetAll().Select(item => item.ToString()).ToList();
            category__combo_box.ItemsSource = categories;

            RefereeRepository refereeRepository = new RefereeRepository();
            referees = refereeRepository.GetAllWithPerson().Select(item => item.Person.GetShortInfo()).ToList();
            referee__combo_box.ItemsSource = referees;
        }
        private void See_Results_Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitionDiscipline cd = (sender as Button).DataContext as CompetitionDiscipline;
            CompetitionDisciplineResultsView cdrv = new CompetitionDisciplineResultsView(cd);

            cdrv.Show();
        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            //Competition competition = (sender as Button).DataContext as Competition;
            //using (AthleticsDbContext dbContext = new AthleticsDbContext())
            //{
            //    dbContext.Competitions.Update(competition);
            //    dbContext.SaveChanges();
            //}
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitionDiscipline competitionDiscipline = (sender as Button).DataContext as CompetitionDiscipline;
            CompetitionDisciplineRepository cdr = new CompetitionDisciplineRepository();
            cdr.Remove(competitionDiscipline);
            ShowList.ItemsSource = cdr.GetAll();
        }
        private void competition_referee__data_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = referees;

            CompetitionDiscipline competitionDiscipline = comboBox.DataContext as CompetitionDiscipline;
            var referee = competitionDiscipline.Referees.FirstOrDefault();
            int index = referee == null ? 0 : referees.IndexOf(referee.Person.GetShortInfo());
            comboBox.SelectedIndex = index;
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            CompetitionDisciplineRepository cdr = new CompetitionDisciplineRepository();

            try
            {
                cdr.Add(new CompetitionDiscipline
                {
                    Discipline = new Discipline()
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowList.ItemsSource = cdr.GetAll();
            }
        }
    }
}