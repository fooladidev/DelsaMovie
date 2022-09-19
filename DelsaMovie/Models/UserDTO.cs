using System.ComponentModel.DataAnnotations;

namespace DelsaMovie.Models
{
    public class CreateUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserDTO : CreateUserDTO
    {
        public int Id { get; set; }
        public IList<CommentDTO> Comments { get; set; } = new List<CommentDTO>();


    }
}
