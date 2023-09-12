using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class AthleteRecordsRepository : MonoPKRepositry<AthleteRecord, int>
    {
        public override DbSet<AthleteRecord> Models => dbContext.AthletesRecords;
    }
}
