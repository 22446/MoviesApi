namespace MoviesApi.Repos
{
    public interface IGnericREPOSITORY<T> where T : class
    {

        public Task<IEnumerable<T>> GetAllTasksAsync();
        public Task<T> GetById(int ID);

        Task addAsync(T entity);
        void UpdateAsync(T entity);
        void Delete(T entity);
    }
}
