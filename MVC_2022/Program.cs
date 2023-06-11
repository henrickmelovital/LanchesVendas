using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;
using MVC_2022.Repositories;
using MVC_2022.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("LanchesMac") ??
    throw new InvalidOperationException("Connection string 'LanchesMac' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrando o servi�o dos reposit�rios : Inje��o de Depend�ncia
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepositorio>();

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
