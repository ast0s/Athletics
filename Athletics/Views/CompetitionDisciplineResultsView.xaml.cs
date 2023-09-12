using Athletics.Database;
using Athletics.Models;
using Athletics.Repositories;
using Athletics.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows;
using System.Windows.Controls;

namespace Athletics.Views
{
    public partial class CompetitionDisciplineResultsView : Window
    {
        private List<Coach> coaches;
        private CompetitionDiscipline cd; 
        public CompetitionDisciplineResultsView(CompetitionDiscipline cd)
        {
            InitializeComponent();
            this.cd = cd;

            ContenderDisciplineRepository cdr = new ContenderDisciplineRepository();
            ShowList.ItemsSource = cdr.GetAllWithDataByCompetitionDiscipline(cd);

            CoachRepository cr = new CoachRepository();
            coaches = cr.GetAllWithPerson();
            contender_coach__combo_box.ItemsSource = coaches.Select(item => item.Person.GetShortInfo());
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
            ContenderDiscipline contenderDiscipline = (sender as Button).DataContext as ContenderDiscipline;
            ContenderDisciplineRepository cdr = new ContenderDisciplineRepository();
            cdr.Remove(contenderDiscipline);
            ShowList.ItemsSource = cdr.GetAllWithDataByCompetitionDiscipline(cd);
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ContenderDisciplineRepository cdr = new ContenderDisciplineRepository();
            try
            {
                using (AthleticsDbContext dbContext = new AthleticsDbContext())
                {
                    var dbTransaction = dbContext.Database.BeginTransaction();
                    var newPerson = new Person()
                    {
                        Name = contender_name__txt_box.Text,
                        Surname = contender_surname__txt_box.Text,
                        Middlename = contender_middlename__txt_box.Text,
                        Sex = contender_sex__txt_box.Text,
                        BirthDate = new DateTime(int.Parse(birthdate_year__txt_box.Text), int.Parse(birthdate_month__txt_box.Text), int.Parse(birthdate_day__txt_box.Text)),
                        Country = contender_country__txt_box.Text,
                        Athlete = new Athlete()
                    };
                    dbContext.Persons.Add(newPerson);
                    dbContext.SaveChanges();

                    var newTeam = new Team
                    {
                        CoachId = coaches[contender_coach__combo_box.SelectedIndex].Id,
                        Name = contender_team__txt_box.Text
                    };

                    dbContext.Teams.Add(newTeam);
                    dbContext.SaveChanges();

                    var newConteder = new Contender
                    {
                        Athlete = newPerson.Athlete,
                        Team = newTeam
                    };

                    dbContext.Contenders.Add(newConteder);
                    dbContext.SaveChanges();

                    ContenderResult newContederResult = new ContenderResult
                    {
                        Score = int.Parse(contender_score__txt_box.Text),
                        IsVerified = true,
                    };

                    dbContext.ContenderResults.Add(newContederResult);
                    dbContext.SaveChanges();

                    var contenderDiscipline = new ContenderDiscipline
                    {
                        CompetitionDisciplineId = cd.Id,
                        Contender = newConteder,
                        ContenderResult = newContederResult,
                    };

                    dbContext.ContenderDisciplines.Add(contenderDiscipline);

                    dbContext.SaveChanges();
                    dbTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ShowList.ItemsSource = cdr.GetAllWithDataByCompetitionDiscipline(cd);
            }
        }
    }
}
