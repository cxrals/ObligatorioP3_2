using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUListadoPedidos : ICUListado<Pedido> {
        public IRepositorioPedidos Repo { get; set; }

        public CUListadoPedidos(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public List<Pedido> ObtenerListado() {
            return Repo.GetAll();
        }
    }
}
