using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaMovimientoStock : ICUAlta<MovimientoStockDTO> {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioArticulos RepoArticulos { get; set; }
        public IRepositorioUsuarios RepoUsuarios { get; set; }
        public IRepositorioTiposMovimientos RepoTiposMovimientos { get; set; }
        public CUAltaMovimientoStock(IRepositorioMovimientosStock repo, IRepositorioArticulos repoArticulos, IRepositorioTiposMovimientos repoTiposMovimientos, IRepositorioUsuarios repoUsuarios) {
            Repo = repo;
            RepoArticulos = repoArticulos;
            RepoTiposMovimientos = repoTiposMovimientos;
            RepoUsuarios = repoUsuarios;
        }

        public void Alta(MovimientoStockDTO obj) {
            MovimientoStock nuevoMovimiento = new MovimientoStock();

            Articulo articulo = RepoArticulos.FindById(obj.ArticuloId);
            TipoMovimiento tm = RepoTiposMovimientos.FindById(obj.TipoMovimientoId);
            Usuario u = RepoUsuarios.BuscarPorEmail(obj.EmailUsuario);

            nuevoMovimiento.Articulo = articulo;
            nuevoMovimiento.TipoMovimiento = tm;
            nuevoMovimiento.Usuario = u;
            nuevoMovimiento.Cantidad = obj.Cantidad;

            // chequear que cantidaad < parametro
            // else tirar DatosInvalidosEx

            Repo.Create(nuevoMovimiento);
            obj.Id = nuevoMovimiento.Id;

        }

        // el usuario puede elegir otros o deberia guardarse el logueado?
    }
}
