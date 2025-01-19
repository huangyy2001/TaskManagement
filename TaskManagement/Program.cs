using TaskManagement.Interface;
using TaskManagement.Service;
using TaskManagement.Dac; // �ޤJ Dac �h���R�W�Ŷ�

var builder = WebApplication.CreateBuilder(args);

// ���U ITaskManagementDac �M TaskManagementDac
builder.Services.AddScoped<ITaskManagementDac, TaskManagementDac>();

// ���U ITaskManagementService �M TaskManagementService
builder.Services.AddScoped<ITaskManagementService, TaskManagementService>();

// ��L�A�ȵ��U
builder.Services.AddControllersWithViews();

var app = builder.Build();

// �t�m�����n��޹D
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskManagement}/{action=Index}/{id?}");

app.Run();
