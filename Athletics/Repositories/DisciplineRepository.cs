using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class DisciplineRepository : MonoPKRepositry<Discipline, int>
    {
        public override DbSet<Discipline> Models => dbContext.Disciplines;
    }
}
