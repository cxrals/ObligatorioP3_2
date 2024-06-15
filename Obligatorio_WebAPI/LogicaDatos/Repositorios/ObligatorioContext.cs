using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDatos.Repositorios {
    public class ObligatorioContext : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoExpress> PedidoExpress { get; set; }
        public DbSet<PedidoComun> PedidoComun { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }


        public ObligatorioContext(DbContextOptions options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Articulo>().ToTable("Articulos");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Linea>().ToTable("Lineas");
            modelBuilder.Entity<Parametro>().ToTable("Parametros");
            modelBuilder.Entity<TipoMovimiento>().ToTable("TiposDeMovimientos");
            modelBuilder.Entity<MovimientoStock>().ToTable("MovimientosDeStock");

            modelBuilder.Entity<Cliente>().OwnsOne(
                c => c.Direccion, d => {
                    d.OwnsOne(c => c.Calle);
                    d.OwnsOne(n => n.NumeroPuerta);
                    d.OwnsOne(ci => ci.Ciudad);
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(
            //    "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ObligatorioP3; Integrated Security=SSPI;TrustServerCertificate=True"
            //);
        }
    }

}
