using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class ContenderRepository : MonoPKRepositry<Contender, int>
    {
        public override DbSet<Contender> Models => dbContext.Contenders;
    }
}
