using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string MovieName { get; set; }
        public string Title { get; set; }
        public int  Rate{ get; set; }
        public string StoryLine { get; set; }
        public string Poster { get; set; }
        [ForeignKey("genras")]
        public int GenraId { get; set; }
        
        public Genras genras { get; set; }
    }
}
