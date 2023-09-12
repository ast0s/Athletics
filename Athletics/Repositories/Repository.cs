using Athletics.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Athletics.Repositories
{
    public abstract class Repository<T> where T : class
    {
        public abstract DbSet<T> Models { get; }
        protected AthleticsDbContext dbContext = AthleticsDbContext.GetInstance();
        public void Add(T model) 
        { 
            dbContext.Add(model);
            dbContext.SaveChanges();
        }
        public void Remove(T model) 
        {
            dbContext.Remove(model);
            dbContext.SaveChanges();
        }
        public void Update(T model) 
        {
            dbContext.Update(model);
            dbContext.SaveChanges();
        }
        public List<T> GetAll()
        {
            return Models.ToList();
        }
    }
}
