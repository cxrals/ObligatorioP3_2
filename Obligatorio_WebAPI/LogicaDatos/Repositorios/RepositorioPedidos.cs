using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDatos.Repositorios {
    public class RepositorioPedidos : IRepositorioPedidos {
        public ObligatorioContext Contexto { get; set; }

        public RepositorioPedidos(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(Pedido obj) {
            obj.EsValido();
            Contexto.Entry(obj.Cliente).State = EntityState.Unchanged;
            Contexto.Pedidos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            //throw new NotImplementedException();
        }

        public Pedido FindById(int id) {
            return Contexto.Pedidos.Include(p => p.Lineas).FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> GetAll() {
            return Contexto.Pedidos.ToList();
        }

        public void Update(Pedido obj) {
            obj.EsValido();
            //Contexto.Entry(obj.Cliente).State = EntityState.Unchanged;
            Contexto.Pedidos.Update(obj);
            Contexto.SaveChanges();
        }

        public void AnularPedido(int id) {
            Pedido aAnular = FindById(id);
            if (aAnular != null) {
                aAnular.Estado = "Anulado";
                Contexto.Pedidos.Update(aAnular);
                Contexto.SaveChanges();
            } else {
                throw new RegistroNoExisteException("El pedido no existe");
            }
        }

        public List<Pedido> BuscarPorFechaDeEmision(DateOnly fecha) {
            return Contexto.Pedidos.Where(p => p.Fecha == fecha && p.Estado == "Pendiente").Include(p => p.Cliente).ToList();
        }

        public List<Pedido> OrdenarPedidosAnuladosPorFechaDesc() {
            return Contexto.Pedidos.Where(p => p.Estado == "Anulado").Include(p => p.Cliente).OrderByDescending(p => p.Fecha).ToList();
        }

        public List<Pedido> ListarPedidosPendientes() {
            return Contexto.Pedidos.Where(p => p.Estado == "Pendiente").Include(p => p.Cliente).ToList();
        }

        public List<Cliente> BuscarClientes(decimal monto) {
            return Contexto.Pedidos.Where(p => p.Total >= monto).Select(p => p.Cliente).Distinct().ToList();
        }
    }
}
// https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-inheritance-with-the-entity-framework-in-an-asp-net-mvc-application