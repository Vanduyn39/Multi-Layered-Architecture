namespace Multi_Layered_Architecture.CoreLayer
{
    public class MoviesSeries
    {
        public int MovieSeriesId { get; set; } // Khóa chính
        public string Title { get; set; } // Tiêu đề phim/series
        public string Genre { get; set; } // Thể loại
        public DateTime ReleaseDate { get; set; } // Ngày phát hành
        public string Description { get; set; } // Mô tả

        // Danh sách đánh giá liên kết với phim/series
        public ICollection<Rating> Ratings { get; set; } // Liên kết đến Rating
        public ICollection<Review> Reviews { get; set; } // Liên kết đến Review
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; } // Liên kết đến MovieSeriesTag
    }
}
