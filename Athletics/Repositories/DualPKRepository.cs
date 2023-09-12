using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletics.Repositories
{
    public abstract class DualPKRepositry<T, KEY1, KEY2> : Repository<T> where T : class
    {
        public T? GetById(KEY1 id1, KEY2 id2)
        {
            return Models.Find(id1, id2);
        }
    }
}
