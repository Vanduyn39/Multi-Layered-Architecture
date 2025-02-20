namespace Multi_Layered_Architecture.CoreLayer
{
    public class Tag
    {
        public int TagId { get; set; } // Khóa chính
        public string TagName { get; set; } // Tên thẻ (ví dụ: "Hành Động", "Hài Hước")

        // Danh sách các phim/series liên kết với thẻ này
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
