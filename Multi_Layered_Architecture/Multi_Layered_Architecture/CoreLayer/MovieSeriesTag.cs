using Multi_Layered_Architecture.ServiceLayer;
namespace Multi_Layered_Architecture.CoreLayer
{
    public class MovieSeriesTag
    {
        public int MovieSeriesId { get; set; } // Khóa ngoại liên kết đến MoviesSeries
        public int TagId { get; set; } // Khóa ngoại liên kết đến Tag

        // Liên kết đến MoviesSeries
        public MoviesSeries MovieSeries { get; set; }

        // Liên kết đến Tag
        public Tag Tag { get; set; }
    }
}
