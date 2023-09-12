using Athletics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Athletics.Repositories
{
    public class RefereeRepository : MonoPKRepositry<Referee, int>
    {
        public override DbSet<Referee> Models => dbContext.Referees;
        public List<Referee> GetAllWithPerson()
        {
            return Models.Include(item => item.Person).ToList();
        }
    }
}
