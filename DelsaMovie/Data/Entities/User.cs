using DelsaMovie.Data.RichClasses;

namespace DelsaMovie.Data.Entities
{
    public class User : Person
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Navigation Properties
        public IList<Comment> Comments { get; set; } = new List<Comment>();




    }
}
