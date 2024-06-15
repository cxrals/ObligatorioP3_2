using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioClientes : IRepositorioClientes {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioClientes(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public List<Cliente> BuscarPorRazonSocial(string nombre) {
            return Contexto.Clientes.Where(c => c.RazonSocial.Contains(nombre)).ToList();
        }

        public void Create(Cliente obj) {
            obj.EsValido();
            Contexto.Clientes.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id) {
            Cliente aBorrar = FindById(id);
            if (aBorrar != null) {
                Contexto.Clientes.Remove(aBorrar);
                Contexto.SaveChanges();
            } else {
                throw new RegistroNoExisteException("El cliente no existe");
            }
        }

        public Cliente FindById(int id) {
            return Contexto.Clientes.Find(id);
        }

        public List<Cliente> GetAll() {
            return Contexto.Clientes.ToList();
        }

        public void Update(Cliente obj) {
            obj.EsValido();
            Contexto.Clientes.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
