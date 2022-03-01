namespace Laboratory2.Repositories
{
    public interface IRepository<T>
    {
        void AddOrUpdate(T t);

        void Delete(T t);

        void DeleteAt(int id);

        void DeleteAll();
    }
}