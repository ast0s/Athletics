using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class TeamRepository : MonoPKRepositry<Team, int>
    {
        public override DbSet<Team> Models => dbContext.Teams;
    }
}
