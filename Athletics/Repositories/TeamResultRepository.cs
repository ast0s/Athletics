using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class TeamResultRepository : DualPKRepositry<TeamResult, int, int>
    {
        public override DbSet<TeamResult> Models => dbContext.TeamsResults;
    }
}
