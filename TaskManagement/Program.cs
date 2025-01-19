using TaskManagement.Interface;
using TaskManagement.Service;
using TaskManagement.Dac; // 引入 Dac 層的命名空間

var builder = WebApplication.CreateBuilder(args);

// 註冊 ITaskManagementDac 和 TaskManagementDac
builder.Services.AddScoped<ITaskManagementDac, TaskManagementDac>();

// 註冊 ITaskManagementService 和 TaskManagementService
builder.Services.AddScoped<ITaskManagementService, TaskManagementService>();

// 其他服務註冊
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 配置中介軟體管道
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskManagement}/{action=Index}/{id?}");

app.Run();
