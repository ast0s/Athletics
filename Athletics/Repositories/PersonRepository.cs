using Athletics.Models;
using Microsoft.EntityFrameworkCore;

namespace Athletics.Repositories
{
    public class PersonRepository : MonoPKRepositry<Person, int>
    {
        public override DbSet<Person> Models => dbContext.Persons;
    }
}
