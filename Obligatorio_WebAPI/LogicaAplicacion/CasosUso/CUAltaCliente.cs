using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaCliente : ICUAlta<Cliente> {
        public IRepositorioClientes Repo { get; set; }
        public CUAltaCliente(IRepositorioClientes repo) {
            Repo = repo;
        }
        public void Alta(Cliente obj) {
            Repo.Create(obj);
        }
    }
}
