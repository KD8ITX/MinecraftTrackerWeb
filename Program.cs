using MinecraftTrackerWeb;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add services to the container.
// Add MVC Controllers along with Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient();
builder.Services.AddScoped<MinecraftTrackerAppClient>();

var app = builder.Build();

var baseUrl = builder.Configuration["AppSettings:BaseUrl"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map MVC controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages routes
app.MapRazorPages();

app.Run();
