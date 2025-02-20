using Multi_Layered_Architecture.ServiceLayer;
namespace Multi_Layered_Architecture.CoreLayer
{
    public class Rating
    {
        public int RatingId { get; set; } // Khóa chính
        public int UserId { get; set; } // Khóa ngoại liên kết đến User
        public int MovieSeriesId { get; set; } // Khóa ngoại liên kết đến MoviesSeries
        public decimal RatingValue { get; set; } // Giá trị đánh giá (0-10)

        // Liên kết đến User
        public User User { get; set; }

        // Liên kết đến MoviesSeries
        public MoviesSeries MovieSeries { get; set; }
    }
}
