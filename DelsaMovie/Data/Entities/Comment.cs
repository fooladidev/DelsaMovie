namespace DelsaMovie.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool IsConfirmed { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        //NAVProps
        public User? User { get; set; }
        public Movie Movie { get; set; }
        

    }
}
