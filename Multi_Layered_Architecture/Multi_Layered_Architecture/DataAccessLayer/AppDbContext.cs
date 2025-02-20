using Microsoft.EntityFrameworkCore;
using Multi_Layered_Architecture.CoreLayer;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Multi_Layered_Architecture.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<MoviesSeries> MoviesSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa quan hệ giữa Movie và MovieSeriesTag
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId }); // Khóa chính là tổ hợp của MovieSeriesId và TagId

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.MovieSeries) // Mối quan hệ với MoviesSeries
                .WithMany(ms => ms.MovieSeriesTags) // Một MoviesSeries có nhiều MovieSeriesTags
                .HasForeignKey(mst => mst.MovieSeriesId); // Khóa ngoại

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag) // Mối quan hệ với Tag
                .WithMany(t => t.MovieSeriesTags) // Một Tag có nhiều MovieSeriesTags
                .HasForeignKey(mst => mst.TagId); // Khóa ngoại

            // Định nghĩa quan hệ giữa User và Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User) // Mối quan hệ với User
                .WithMany(u => u.Reviews) // Một User có nhiều Reviews
                .HasForeignKey(r => r.user_id); // Khóa ngoại

            // Định nghĩa quan hệ giữa User và Rating
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User) // Mối quan hệ với User
                .WithMany(u => u.Ratings) // Một User có nhiều Ratings
                .HasForeignKey(r => r.user_id); // Khóa ngoại

            // Định nghĩa quan hệ giữa MovieSeries và Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MovieSeries) // Mối quan hệ với MoviesSeries
                .WithMany(ms => ms.Reviews) // Một MoviesSeries có nhiều Reviews
                .HasForeignKey(r => r.MovieSeriesId); // Khóa ngoại

            // Định nghĩa quan hệ giữa MovieSeries và Rating
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.MovieSeries) // Mối quan hệ với MoviesSeries
                .WithMany(ms => ms.Ratings) // Một MoviesSeries có nhiều Ratings
                .HasForeignKey(r => r.movie_series_id); // Khóa ngoại
        }
    }
}
