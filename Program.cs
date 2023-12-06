using App.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the Razor
builder.Services.AddRazorPages();


builder.Services.Configure<RazorViewEngineOptions>((option) => {
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> ten Action
    // {1} -> ten controller
    // {2} -> ten area
    // RazorViewEngine.ViewExtension === .cshtml --> tên đuôi của action
    option.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension); // tìm kiếm và xác định vị trí các file view trong ứng dụng ASP.NET MVC.
});



// builder.Services.AddSingleton<ProductService>();
// builder.Services.AddSingleton<ProductService, ProductService>();
// builder.Services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));

// builder.Services.AddSingleton --> chỉ tạo ra 1 đối tượng dịch vụ
// builder.Services.AddTransient --> mỗi lần truy vấn lấy ra dịch vụ thì nó sẽ tạo 1 đối tượng mới
// builder.Services.AddScoped --> mỗi phiên lấy dịch vụ sẽ lấy 1 đối tượng mới đó ra


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // xác định danh tính
app.UseAuthorization(); // xác định quyền truy cập

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
