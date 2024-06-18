using Microsoft.Extensions.Options;
using MultiShop.RapiApiWebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RapidApiSettings>(builder.Configuration.GetSection(nameof(RapidApiSettings)));

builder.Services.AddScoped<IRapidApiSettings>(sp =>
{
    var service = sp.GetRequiredService<IOptions<RapidApiSettings>>();
    return service.Value;
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
