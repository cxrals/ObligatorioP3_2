using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
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
        public IRepositorioParametros RepoParametros { get; set; }
        public CUAltaMovimientoStock(
            IRepositorioMovimientosStock repo, 
            IRepositorioArticulos repoArticulos, 
            IRepositorioTiposMovimientos repoTiposMovimientos, 
            IRepositorioUsuarios repoUsuarios,
            IRepositorioParametros repoParametros
        ) {
            Repo = repo;
            RepoArticulos = repoArticulos;
            RepoTiposMovimientos = repoTiposMovimientos;
            RepoUsuarios = repoUsuarios;
            RepoParametros = repoParametros;
        }

        public void Alta(MovimientoStockDTO obj) {
            MovimientoStock nuevoMovimiento = new MovimientoStock();

            // obtener el límite de cantidad 
            int limiteCantidad = (int) RepoParametros.ObtenerLimiteTopeDeMovimientos();

            // chequear que cantidaad < parametro
            if (obj.Cantidad <= limiteCantidad) {
                Articulo articulo = RepoArticulos.FindById(obj.ArticuloId);
                TipoMovimiento tm = RepoTiposMovimientos.FindById(obj.TipoMovimientoId);
                Usuario u = RepoUsuarios.BuscarPorEmail(obj.EmailUsuario);

                nuevoMovimiento.Articulo = articulo;
                nuevoMovimiento.TipoMovimiento = tm;
                nuevoMovimiento.Usuario = u;
                nuevoMovimiento.Cantidad = obj.Cantidad;

                Repo.Create(nuevoMovimiento);
                obj.Id = nuevoMovimiento.Id;
            } else {
                throw new DatosInvalidosException("La cantidad debe ser menor o igual a " + limiteCantidad);
            }
        }

    }
}
