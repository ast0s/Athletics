using Athletics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Athletics.Repositories
{
    public class CompetitionDisciplineRepository : MonoPKRepositry<CompetitionDiscipline, int>
    {
        public override DbSet<CompetitionDiscipline> Models => dbContext.CompetitionDisciplines;
        public List<CompetitionDiscipline> GetAllWithDataByCompetition(Competition competition)
        {
            return Models
                .Include(x => x.Requirements)
                .Include(x => x.Referees).ThenInclude(x => x.Person)
                .Include(x => x.Discipline)
                .Include(x => x.Competition)
                .Where(x => x.Competition == competition)
                .ToList();
        }
    }
}
