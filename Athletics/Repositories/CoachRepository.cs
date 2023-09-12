using Athletics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Athletics.Repositories
{
    public class CoachRepository : MonoPKRepositry<Coach, int>
    {
        public override DbSet<Coach> Models => dbContext.Coaches;
        public List<Coach> GetAllWithPerson()
        {
            return Models.Include(item => item.Person).ToList();
        }
    }
}
