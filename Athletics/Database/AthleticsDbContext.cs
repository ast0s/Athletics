using Athletics.Models;
using Athletics.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Athletics.Database
{
    public class AthleticsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<AthleteRecord> AthletesRecords { get; set; }
        public DbSet<Contender> Contenders { get; set; }
        public DbSet<ContenderResult> ContenderResults { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamResult> TeamsResults { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<CompetitionDiscipline> CompetitionDisciplines { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<ContenderDiscipline> ContenderDisciplines { get; set; }
        public DbSet<Requirement> Requirements { get; set; }

        public AthleticsDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            //DataInit();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=228248N;Server=localhost;Port=5432;Database=athletics_db;Integrated Security=true;Pooling=true;");
        }

        private static AthleticsDbContext? instance;
        public static AthleticsDbContext GetInstance()
        {
            if (instance == null)
            {
                instance = new AthleticsDbContext();
            }

            return instance;
        }


        private void DataInit()
        {
            var person_1 = new Person()
            {
                Name = "Matt",
                Surname = "Damon",
                Middlename = "Paige",
                Sex = "Male",
                BirthDate = new DateTime(1970, 10, 8),
                Country = "US",
                Athlete = new Athlete()
            };
            Persons.Add(person_1);

            var contender_1 = new Contender()
            {
                Athlete = person_1.Athlete
            };
            Contenders.Add(contender_1);

            var person_2 = new Person()
            {
                Name = "Keanu",
                Surname = "Reeves",
                Middlename = "Charles",
                Sex = "Male",
                BirthDate = new DateTime(1964, 09, 02),
                Country = "Canada",
                Athlete = new Athlete()
            };
            Persons.Add(person_2);

            var contender_2 = new Contender()
            {
                Athlete = person_2.Athlete
            };
            Contenders.Add(contender_2);

            var person_3 = new Person()
            {
                Name = "Ryan",
                Surname = "Gosling",
                Middlename = "Thomas",
                Sex = "Male",
                BirthDate = new DateTime(1980, 11, 12),
                Country = "Canada",
                Athlete = new Athlete()
            };
            Persons.Add(person_3);

            var contender_3 = new Contender()
            {
                Athlete = person_3.Athlete
            };
            Contenders.Add(contender_3);

            var person_4 = new Person()
            {
                Name = "Emily",
                Surname = "Stone",
                Middlename = "Jean",
                Sex = "Female",
                BirthDate = new DateTime(1988, 10, 06),
                Country = "US",
                Athlete = new Athlete()
            };
            Persons.Add(person_4);

            var contender_4 = new Contender()
            {
                Athlete = person_4.Athlete
            };
            Contenders.Add(contender_4);

            var person_5 = new Person()
            {
                Name = "Margot",
                Surname = "Robbie",
                Middlename = "Elise",
                Sex = "Female",
                BirthDate = new DateTime(1990, 07, 02),
                Country = "Australia",
                Athlete = new Athlete()
            };
            Persons.Add(person_5);

            var contender_5 = new Contender()
            {
                Athlete = person_5.Athlete
            };
            Contenders.Add(contender_5);

            var person_6 = new Person()
            {
                Name = "Ryan",
                Surname = "Reynolds",
                Middlename = "Rodney",
                Sex = "Male",
                BirthDate = new DateTime(1976, 10, 23),
                Country = "Canada",
                Coach = new Coach()
            };
            Persons.Add(person_6);

            var person_7 = new Person()
            {
                Name = "Scarlett",
                Surname = "Johansson",
                Middlename = "Ingrid",
                Sex = "Female",
                BirthDate = new DateTime(1984, 10, 22),
                Country = "US",
                Coach = new Coach()
            };
            Persons.Add(person_7);

            var person_8 = new Person()
            {
                Name = "Jennifer",
                Surname = "Lawrence",
                Middlename = "Shrader",
                Sex = "Female",
                BirthDate = new DateTime(1990, 08, 15),
                Country = "US",
                Referee = new Referee()
            };
            Persons.Add(person_8);

            var person_9 = new Person()
            {
                Name = "Benedict",
                Surname = "Cumberbatch",
                Middlename = "Timothy  Carlton",
                Sex = "Male",
                BirthDate = new DateTime(1976, 07, 19),
                Country = "UK",
                Referee = new Referee()
            };
            Persons.Add(person_9);




            var team_1 = new Team()
            {
                Coach = person_6.Coach,
                Contenders = new List<Contender>() { contender_1, contender_4, contender_3 },
                Name = "Team 1"
            };
            Teams.Add(team_1);

            var team_2 = new Team()
            {
                Coach = person_7.Coach,
                Contenders = new List<Contender>() { contender_2, contender_5 },
                Name = "Team 2"
            };
            Teams.Add(team_2);




            var competition_1 = new Competition()
            {
                StatusType = StatusType.Conducted,
                Name = "Competition 1",
                Location = "Cherkasy",
                Country = "Ukraine",
                BegginingDate = new DateTime(2023, 1, 1, 8, 0, 0),
                EndingDate = new DateTime(2023, 1, 2, 16, 0, 0)
            };
            Competitions.Add(competition_1);

            var competition_2 = new Competition()
            {
                StatusType = StatusType.Ended,
                Name = "Competition 2",
                Location = "Kyiv",
                Country = "Ukraine",
                BegginingDate = new DateTime(2023, 1, 3, 8, 0, 0),
                EndingDate = new DateTime(2023, 1, 4, 16, 0, 0)
            };
            Competitions.Add(competition_2);




            var discipline_1 = new Discipline()
            {
                Name = "Running 60m",
            };
            Disciplines.Add(discipline_1);

            var discipline_2 = new Discipline()
            {
                Name = "Pole vault",
            };
            Disciplines.Add(discipline_2);

            var discipline_3 = new Discipline()
            {
                Name = "Long jump",
            };
            Disciplines.Add(discipline_3);

            var discipline_4 = new Discipline()
            {
                Name = "Running 400m",
            };
            Disciplines.Add(discipline_4);




            var requirement_1 = new Requirement()
            {
                Sex = "Male",
                MinAge = 18,
                MaxAge = 30
            };
            Requirements.Add(requirement_1);

            var requirement_2 = new Requirement()
            {
                Sex = "Female",
                MinAge = 18,
                MaxAge = 30,
            };
            Requirements.Add(requirement_2);




            var competitionDiscipline_1 = new CompetitionDiscipline()
            {
                Discipline = discipline_1,
                Competition = competition_1,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_1, ContenderResult = new ContenderResult () { Score = 14, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_2, ContenderResult = new ContenderResult () { Score = 16, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_3, ContenderResult = new ContenderResult () { Score = 15, IsVerified = true } }
                },
                Requirements = new List<Requirement>() { requirement_1 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_1);

            var competitionDiscipline_2 = new CompetitionDiscipline()
            {
                Discipline = discipline_2,
                Competition = competition_1,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_1, ContenderResult = new ContenderResult () { Score = 14, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_2, ContenderResult = new ContenderResult () { Score = 15, IsVerified = true } },
                },
                Requirements = new List<Requirement>() { requirement_1 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_2);

            var competitionDiscipline_3 = new CompetitionDiscipline()
            {
                Discipline = discipline_3,
                Competition = competition_1,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_4, ContenderResult = new ContenderResult () { Score = 16, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_5, ContenderResult = new ContenderResult () { Score = 17, IsVerified = true } }
                },
                Requirements = new List<Requirement>() { requirement_2 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_3);

            var competitionDiscipline_4 = new CompetitionDiscipline()
            {
                Discipline = discipline_4,
                Competition = competition_1,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_5, ContenderResult = new ContenderResult () { Score = 12, IsVerified = false } },
                },
                Requirements = new List<Requirement>() { requirement_2 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_4);

            var competitionDiscipline_5 = new CompetitionDiscipline()
            {
                Discipline = discipline_1,
                Competition = competition_2,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_4, ContenderResult = new ContenderResult () { Score = 14, IsVerified = true } },
                },
                Requirements = new List<Requirement>() { requirement_2 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_5);

            var competitionDiscipline_6 = new CompetitionDiscipline()
            {
                Discipline = discipline_2,
                Competition = competition_2,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_4, ContenderResult = new ContenderResult () { Score = 17, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_5, ContenderResult = new ContenderResult () { Score = 13, IsVerified = true } },
                },
                Requirements = new List<Requirement>() { requirement_2 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_6);

            var competitionDiscipline_7 = new CompetitionDiscipline()
            {
                Discipline = discipline_3,
                Competition = competition_2,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_1, ContenderResult = new ContenderResult () { Score = 16, IsVerified = true } },
                    new ContenderDiscipline() { Contender = contender_3, ContenderResult = new ContenderResult () { Score = 17, IsVerified = true } }
                },
                Requirements = new List<Requirement>() { requirement_1 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_7);

            var competitionDiscipline_8 = new CompetitionDiscipline()
            {
                Discipline = discipline_4,
                Competition = competition_2,
                ContenderDisciplines = new List<ContenderDiscipline>()
                {
                    new ContenderDiscipline() { Contender = contender_2, ContenderResult = new ContenderResult () { Score = 12, IsVerified = false } },
                    new ContenderDiscipline() { Contender = contender_3, ContenderResult = new ContenderResult () { Score = 18, IsVerified = true } }
                },
                Requirements = new List<Requirement>() { requirement_1 }
            };
            CompetitionDisciplines.Add(competitionDiscipline_8);

            SaveChanges();
        }
    }
}
