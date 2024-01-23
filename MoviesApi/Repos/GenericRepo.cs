using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.Repos
{
    public class GenericRepo<T> : IGnericREPOSITORY<T> where T :class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task  addAsync(T entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<T>> GetAllTasksAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int ID)
        { 
         return  await dbContext.Set<T>().FindAsync(ID);
        }

        public  void UpdateAsync(T entity)
        {
          
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
            
        }
        public void Delete(T entity)
        {
            
            dbContext.Remove(entity);
            dbContext.SaveChanges();

        }
    }


}
