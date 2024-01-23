using MoviesApi.Models;

namespace MoviesApi.Repos
{
    public interface IMoviesInterface
    {
        public Task<IEnumerable<Movie>> GetAllMovies();
     

    }


}
