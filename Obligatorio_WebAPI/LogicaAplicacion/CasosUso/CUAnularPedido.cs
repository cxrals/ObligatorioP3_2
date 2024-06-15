using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAnularPedido : ICUAnularPedido {
        public IRepositorioPedidos Repo { get; set; }
        public CUAnularPedido(IRepositorioPedidos repo) {
            Repo = repo;
        }
        public void Anular(int id) {
            Repo.AnularPedido(id);
        }
    }
}
