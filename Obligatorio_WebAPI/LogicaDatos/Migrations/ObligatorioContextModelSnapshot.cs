﻿// <auto-generated />
using System;
using LogicaDatos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaDatos.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    partial class ObligatorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.Dominio.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoProveedor")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoProveedor")
                        .IsUnique();

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Articulos", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DistanciaHastaDeposito")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("Rut")
                        .IsUnique()
                        .HasFilter("[Rut] IS NOT NULL");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Linea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PreciodUnitario")
                        .HasColumnType("int");

                    b.Property<int>("UnidadesSolicitadas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Lineas", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.MovimientoStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("TipoMovimientoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("TipoMovimientoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("MovimientosDeStock", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Parametros", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaEntrega")
                        .HasColumnType("date");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Recargo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pedido");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.TipoMovimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TipoAccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("TiposDeMovimientos", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContraseniaEncriptada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoComun", b =>
                {
                    b.HasBaseType("LogicaNegocio.Dominio.Pedido");

                    b.Property<int>("PlazoEstipulado")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PedidoComun");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoExpress", b =>
                {
                    b.HasBaseType("LogicaNegocio.Dominio.Pedido");

                    b.Property<int>("PlazoEstipulado")
                        .HasColumnType("int");

                    b.ToTable("Pedidos", t =>
                        {
                            t.Property("PlazoEstipulado")
                                .HasColumnName("PedidoExpress_PlazoEstipulado");
                        });

                    b.HasDiscriminator().HasValue("PedidoExpress");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Cliente", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .HasColumnType("int");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");

                            b1.OwnsOne("LogicaNegocio.ValueObjects.Calle", "Calle", b2 =>
                                {
                                    b2.Property<int>("DireccionId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Valor")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("DireccionId");

                                    b2.ToTable("Clientes");

                                    b2.WithOwner()
                                        .HasForeignKey("DireccionId");
                                });

                            b1.OwnsOne("LogicaNegocio.ValueObjects.Ciudad", "Ciudad", b2 =>
                                {
                                    b2.Property<int>("DireccionId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Valor")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("DireccionId");

                                    b2.ToTable("Clientes");

                                    b2.WithOwner()
                                        .HasForeignKey("DireccionId");
                                });

                            b1.OwnsOne("LogicaNegocio.ValueObjects.NumeroPuerta", "NumeroPuerta", b2 =>
                                {
                                    b2.Property<int>("DireccionId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Valor")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("DireccionId");

                                    b2.ToTable("Clientes");

                                    b2.WithOwner()
                                        .HasForeignKey("DireccionId");
                                });

                            b1.Navigation("Calle")
                                .IsRequired();

                            b1.Navigation("Ciudad")
                                .IsRequired();

                            b1.Navigation("NumeroPuerta")
                                .IsRequired();
                        });

                    b.Navigation("Direccion")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Linea", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Pedido", null)
                        .WithMany("Lineas")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Articulo");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.MovimientoStock", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.TipoMovimiento", "TipoMovimiento")
                        .WithMany()
                        .HasForeignKey("TipoMovimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("TipoMovimiento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.Navigation("Lineas");
                });
#pragma warning restore 612, 618
        }
    }
}
