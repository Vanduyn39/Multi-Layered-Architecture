using Multi_Layered_Architecture.ServiceLayer;
using System.ComponentModel.DataAnnotations;
namespace Multi_Layered_Architecture.CoreLayer
{
    public class Rating
    {
        [Key]
        public int rating_id { get; set; } // Khóa chính
        public int user_id { get; set; } // Khóa ngoại liên kết đến User
        public int movie_series_id { get; set; } // Khóa ngoại liên kết đến MoviesSeries
        public decimal rating { get; set; } // Giá trị đánh giá (0-10)

        // Liên kết đến User
        public User User { get; set; }

        // Liên kết đến MoviesSeries
        public MoviesSeries MovieSeries { get; set; }
    }
}
