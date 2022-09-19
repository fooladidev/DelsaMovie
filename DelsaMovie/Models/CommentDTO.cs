using System.ComponentModel.DataAnnotations;

namespace DelsaMovie.Models
{
    public class CreateCommentDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
    public class CommentDTO : CreateCommentDTO
    {
        public int Id { get; set; }
        public UserDTO? User { get; set; }
        
        public MovieDTO Movie { get; set; }
        

    }
}
