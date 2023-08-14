using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_2022.Context;
using MVC_2022.Models;
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

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Configurando os padrões para validar uma senha:
builder.Services.Configure<IdentityOptions>(options =>
{
    // Configurações padrão do Identity
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Registrando o servi�o dos reposit�rios : Inje��o de Depend�ncia
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepositorio>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

// Registro a interface IHttpContextAcessor()
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Registrando o servi�o do carrinho de compra 
builder.Services.AddScoped(SP => CarrinhoCompra.GetCarrinho(SP));

// Habilitando os MiddleWares:
// Ativar o uso do cache em mem�ria atrav�s da interface IMemoryCache():
builder.Services.AddMemoryCache();
// Invocando o m�todo AddSession():
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

app.UseAuthentication();
app.UseAuthorization();

// Ativando os Middleswares 'builder.Services.AddMemoryCache();' e 'builder.Services.AddSession();':
app.UseSession();

// Rotas s�o definidas aqui:

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
        name: "CategoriaFiltro",
        pattern: "Lanche/{action}/{categoria?}",
        defaults: new { Controller = "Lanche", Action = "List" }
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
});

app.Run();
