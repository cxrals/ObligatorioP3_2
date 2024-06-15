using DataTransferObjects;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options => {
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICUAlta<Articulo>, CUAltaArticulo>();
builder.Services.AddScoped<ICUBaja<Articulo>, CUBajaArticulo>();
builder.Services.AddScoped<ICUListado<Articulo>, CUListadoArticulos>();
builder.Services.AddScoped<ICUModificar<Articulo>, CUModificarArticulo>();
builder.Services.AddScoped<ICUBuscarPorId<Articulo>, CUBuscarPorIdArticulo>();

builder.Services.AddScoped<ICUAlta<Usuario>, CUAltaUsuario>();
builder.Services.AddScoped<ICUBaja<Usuario>, CUBajaUsuario>();
builder.Services.AddScoped<ICUListado<Usuario>, CUListadoUsuarios>();
builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();
builder.Services.AddScoped<ICUBuscarPorId<Usuario>, CUBuscarPorIdUsuario>();
builder.Services.AddScoped<ICUAutenticarUsuario, CUAutenticarUsuario>();

builder.Services.AddScoped<ICUListado<ClienteDTO>, CUListadoClientes>();
builder.Services.AddScoped<ICUBuscarPorRazonSocial, CUBuscarPorRazonSocial>();
builder.Services.AddScoped<ICUBuscarClientesPorMontoPedido, CUBuscarClientesPorMontoPedido>();

builder.Services.AddScoped<ICUAlta<PedidoDTO>, CUAltaPedido>();
builder.Services.AddScoped<ICUBuscarPorFechaPedido, CUBuscarPorFechaPedido>();
builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();
builder.Services.AddScoped<ICUBuscarPorId<PedidoDTO>, CUBuscarPorIdPedido>();
builder.Services.AddScoped<ICUModificar<PedidoDTO>, CUAgregarArticuloEnPedido>();
builder.Services.AddScoped<ICUListado<Pedido>, CUListadoPedidos>();
builder.Services.AddScoped<ICUListado<PedidoNoEntregadoDTO>, CUListadoPedidosPendientes>();

builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
builder.Services.AddScoped<IRepositorioLineas, RepositorioLineas>();
builder.Services.AddScoped<IRepositorioParametros, RepositorioParametros>();

string conStr = builder.Configuration.GetConnectionString("Caro-Zenbook");
builder.Services.AddDbContext<ObligatorioContext>(options => options.UseSqlServer(conStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
