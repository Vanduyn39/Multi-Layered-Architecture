using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Multi_Layered_Architecture;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 🔹 Đăng ký AppDbContext với SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 🔹 Thêm Controllers
builder.Services.AddControllers();

var app = builder.Build();

// 🔹 Chạy migration tự động
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Nếu chưa có database, sẽ tự tạo
}

// 🔹 Cấu hình Middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 🔹 Chạy ứng dụng
app.Run();
