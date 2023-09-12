using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class RequirementRepository : MonoPKRepositry<Requirement, int>
    {
        public override DbSet<Requirement> Models => dbContext.Requirements;
    }
}
