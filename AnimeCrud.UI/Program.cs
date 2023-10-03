using Microsoft.EntityFrameworkCore;
using AnimeCrud.DAL.DataContext;
using AnimeCrud.DAL.Repositorio;
using AnimeCrud.EN;
using AnimeCrud.BL.ServiceBL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AnimeBdContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<AnimeBd>, AnimeRepository>();
builder.Services.AddScoped<IAnimeService, AnimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
