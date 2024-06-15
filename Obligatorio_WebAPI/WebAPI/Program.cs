using DataTransferObjects;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICUOrdenarArticulosAsc, CUOrdenarArticulosAsc>();
            builder.Services.AddScoped<ICUOrdenarPedidosAnuladosDesc, CUOrdenarPedidosAnuladosDesc>();

            builder.Services.AddScoped<ICUAlta<TipoMovimientoDTO>, CUAltaTipoMovimiento>();
            builder.Services.AddScoped<ICUBaja<TipoMovimientoDTO>, CUBajaTipoMovimiento>();
            builder.Services.AddScoped<ICUListado<TipoMovimientoDTO>, CUListadoTiposMovimientos>();
            builder.Services.AddScoped<ICUModificar<TipoMovimientoDTO>, CUModificarTipoMovimiento>();
            builder.Services.AddScoped<ICUBuscarPorId<TipoMovimientoDTO>, CUBuscarPorIdTipoMovimiento>();

            builder.Services.AddScoped<ICUAlta<MovimientoStockDTO>, CUAltaMovimientoStock>();
            builder.Services.AddScoped<ICUListado<MovimientoStockIndexDTO>, CUListadoMovimientosStock>();
            builder.Services.AddScoped<ICUBuscarPorId<MovimientoStockDTO>, CUBuscarPorIdMovimientoStock>();
            builder.Services.AddScoped<ICUBuscarPorFechaMovimiento, CUBuscarPorFechaMovimiento>();
            builder.Services.AddScoped<ICUBuscarPorArticuloYTipoMovimiento, CUBuscarPorArticuloYTipoMovimiento>();
            builder.Services.AddScoped<ICUResumenMovimientos, CUResumenMovimientos>();
            
            builder.Services.AddScoped<ICUAutenticarUsuario, CUAutenticarUsuario>();

            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioTiposMovimientos, RepositorioTiposMovimientos>();
            builder.Services.AddScoped<IRepositorioMovimientosStock, RepositorioMovimientosStock>();

            string conStr = builder.Configuration.GetConnectionString("Caro-Zenbook");
            builder.Services.AddDbContext<ObligatorioContext>(options => options.UseSqlServer(conStr));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuraciòn autenticaciòn 
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";
            builder.Services.AddAuthentication(aut => {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut => {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
