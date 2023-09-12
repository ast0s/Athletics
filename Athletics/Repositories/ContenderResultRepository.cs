using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class ContenderResultRepository : MonoPKRepositry<ContenderResult, int>
    {
        public override DbSet<ContenderResult> Models => dbContext.ContenderResults;
    }
}
