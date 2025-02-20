namespace Multi_Layered_Architecture.CoreLayer
{
    public class Review
    {
        public int Id { get; set; }
        //public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
        public MoviesSeries MovieSeries { get; set; }
        public User User { get; set; }
        public int MovieSeriesId { get; set; }
    }

}
