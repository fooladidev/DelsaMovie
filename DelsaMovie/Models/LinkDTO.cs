using System.ComponentModel.DataAnnotations;

namespace DelsaMovie.Models
{
    public class CreateLinkDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public string Encoder { get; set; }
        public string Quality { get; set; }
        [Required]
        public string Volume { get; set; }
        [Required]
        public int MovieId { get; set; }
    }

    public class LinkDTO:CreateLinkDTO
    {
        public int Id { get; set; }
        public MovieDTO Movie { get; set; } 

    }
}
