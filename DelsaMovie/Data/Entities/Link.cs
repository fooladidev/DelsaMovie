namespace DelsaMovie.Data.Entities
{
    public class Link
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
        public string Encoder { get; set; }
        public string Quality { get; set; }
        public string Volume { get; set; }
        public int MovieId { get; set; }

        //NAVProps

        public Movie Movie { get; set; }
    }
}
