using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;
using MVC_2022.Models;
using MVC_2022.Repositories;
using MVC_2022.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("LanchesMac") ??
    throw new InvalidOperationException("Connection string 'LanchesMac' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrando o serviço dos repositórios : Injeção de Dependência
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepositorio>();

// Registro a interface IHttpContextAcessor()
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Registrando o serviço do carrinho de compra 
builder.Services.AddScoped(SP => CarrinhoCompra.GetCarrinho(SP));

// Habilitando os MiddleWares:
// Ativar o uso do cache em memória através da interface IMemoryCache():
builder.Services.AddMemoryCache();
// Invocando o método AddSession():
builder.Services.AddSession();

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

// Ativando os Middleswares 'builder.Services.AddMemoryCache();' e 'builder.Services.AddSession();':
app.UseSession();

// Rotas são definidas aqui:

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "test",
        pattern: "testename",
        defaults: new { controller = "teste", Action = "Index" }
        );

    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{action=Index}/{id?}",
        defaults: new { controller = "admin" }
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
