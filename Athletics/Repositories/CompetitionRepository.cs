using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class CompetitionRepository : MonoPKRepositry<Competition, int>
    {
        public override DbSet<Competition> Models => dbContext.Competitions;
    }
}
