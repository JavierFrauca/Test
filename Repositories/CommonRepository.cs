
using Microsoft.EntityFrameworkCore;
using TEST.Data;

namespace TEST.Repositories
{
    public abstract class CommonRepository<T>(MiData dbContext) : ICommonRepository<T> where T : class
    {
        private readonly DbContext _dbContext = dbContext;

        public async Task<List<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public async Task<T> GetById(int id)
        {
            var response = await _dbContext.Set<T>().FindAsync(id);
            response ??= Activator.CreateInstance<T>();
            return response;
        }

        public async Task<T> Add(T datos)
        {
            await _dbContext.Set<T>().AddAsync(datos);
            await _dbContext.SaveChangesAsync();
            return datos;
        }
        public void Delete(T datos)=>_dbContext.Set<T>().Remove(datos);
        public void Update(T datos)
        {
            _dbContext.Set<T>().Attach(datos);
            _dbContext.Entry(datos).State = EntityState.Modified;
        }
        public async Task Save()=> await _dbContext.SaveChangesAsync();
    }
}
