namespace Multi_Layered_Architecture.CoreLayer
{
    public class User
    {
        public int UserId { get; set; } // Khóa chính
        public string Username { get; set; } // Tên hiển thị của người dùng
        public string Email { get; set; } // Địa chỉ email của người dùng
        public DateTime CreatedAt { get; set; } // Ngày tạo tài khoản
  

        // Danh sách đánh giá của người dùng
        public ICollection<Review> Reviews { get; set; }

        // Danh sách đánh giá của người dùng
        public ICollection<Rating> Ratings { get; set; }
    }
}
