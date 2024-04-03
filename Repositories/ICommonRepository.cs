namespace TEST.Repositories
{
    public interface ICommonRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T datos);
        void Delete(T datos);
        void Update(T datos);
        Task Save();
    }
}
