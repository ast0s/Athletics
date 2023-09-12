namespace Athletics.Repositories
{
    public abstract class MonoPKRepositry<T, KEY> : Repository<T> where T : class
    {
        public T? GetById(KEY id)
        {
            return Models.Find(id);
        }
    }
}
