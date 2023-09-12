using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class AthleteRepository : MonoPKRepositry<Athlete, int>
    {
        public override DbSet<Athlete> Models => dbContext.Athletes;
    }
}
