namespace DelsaMovie.Data.Entities
{


    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Country { get; set; }
        public string Summary { get; set; }
        public string ImdbLink { get; set; }

        //NAVProps
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Link> Links { get; set; } = new List<Link>();



    }
}
