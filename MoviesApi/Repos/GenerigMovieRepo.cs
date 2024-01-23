using Microsoft.EntityFrameworkCore;
using MoviesApi.DTO;
using MoviesApi.Models;
using System.Runtime.InteropServices;

namespace MoviesApi.Repos
{
    public class GenerigMovieRepo : IMoviesInterface
    {
        private readonly ApplicationDbContext dbContext;

        public GenerigMovieRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async  Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await dbContext.movies.Include(m=>m.genras).ToListAsync();

        }

        
    }
}
