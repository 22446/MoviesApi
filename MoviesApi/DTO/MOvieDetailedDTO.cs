using MoviesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.DTO
{
    public class MOvieDetailedDTO
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Title { get; set; }
        public int Rate { get; set; }
        public string StoryLine { get; set; }
        public string Poster { get; set; }
        public IFormFile formFile { get; set; }
        public int GenraId { get; set; }
        public string GenraName { get; set; }

    }
}
