using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Multi_Layered_Architecture.DataAccessLayer;
using Multi_Layered_Architecture.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình dịch vụ
// Thêm DbContext với SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm các dịch vụ cho các repository và service
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

// Thêm dịch vụ cho điều khiển API
builder.Services.AddControllers().AddNewtonsoftJson(); // Nếu cần sử dụng Newtonsoft.Json

var app = builder.Build();

// Cấu hình middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hiển thị lỗi trong môi trường phát triển
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Xử lý lỗi trong môi trường sản xuất
    app.UseHsts(); // Bảo mật HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Chuyển hướng HTTP sang HTTPS
app.UseStaticFiles(); // Sử dụng các file tĩnh

app.UseRouting(); // Sử dụng routing

app.UseAuthorization(); // Sử dụng xác thực

// Định nghĩa các endpoint cho các controller
app.MapControllers();

app.Urls.Add("http://localhost:3000");

// Chạy ứng dụng
app.Run();
