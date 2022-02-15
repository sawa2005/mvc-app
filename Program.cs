var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();
builder.Services.AddDistributedMemoryCache();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Start}/{id?}"
);

app.Run();
