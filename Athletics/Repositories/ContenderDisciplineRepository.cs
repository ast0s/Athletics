using Athletics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Athletics.Repositories
{
    public class ContenderDisciplineRepository : DualPKRepositry<ContenderDiscipline, int, int>
    {
        public override DbSet<ContenderDiscipline> Models => dbContext.ContenderDisciplines;
        public List<ContenderDiscipline> GetAllWithDataByCompetitionDiscipline(CompetitionDiscipline cd)
        {
            return Models
                .Include(x => x.CompetitionDiscipline).ThenInclude(x => x.Referees).ThenInclude(x => x.Person)
                .Include(x => x.ContenderResult)
                .Include(x => x.Contender).ThenInclude(x => x.Team).ThenInclude(x => x.Coach).ThenInclude(x => x.Person)
                .Include(x => x.Contender).ThenInclude(x => x.Athlete).ThenInclude(x => x.Person)
                .Where(x => x.CompetitionDiscipline == cd)
                .ToList();
        }
    }
}
