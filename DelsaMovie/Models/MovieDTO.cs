using System.ComponentModel.DataAnnotations;

namespace DelsaMovie.Models
{
    public class CreateMovieDTO
    {
        [Required]
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Country { get; set; }
        public string Summary { get; set; }
        public string ImdbLink { get; set; }
    }
    public class MovieDTO :CreateMovieDTO
    {
        public int Id { get; set; }
        public IList<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public IList<LinkDTO> Links { get; set; } = new List<LinkDTO>();

    }
    
}
