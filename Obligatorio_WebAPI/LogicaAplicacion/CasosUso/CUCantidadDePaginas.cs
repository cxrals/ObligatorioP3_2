using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUCantidadDePaginas : ICUCantidadDePaginas {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioParametros RepoParametros { get; set; }
        public CUCantidadDePaginas(IRepositorioMovimientosStock repo, IRepositorioParametros repoParametros) {
            Repo = repo;
            RepoParametros = repoParametros;
        }

        public double ObtenerCantidadDePaginas(int idArticulo, string tipoMovimiento) {
            // obtener el límite de records por página establecido en Parametros
            int limitePorPagina = (int)RepoParametros.ObtenerLimitePorPagina();

            // obtener cantidad de records que devolvio la consulta
            int totalQuery = Repo.CantidadDeMovimientos(idArticulo, tipoMovimiento);

            return Math.Ceiling( (double) totalQuery / (double) limitePorPagina);
        }

        public double ObtenerCantidadDePaginas(string desde, string hasta) {
            // obtener el límite de records por página establecido en Parametros
            int limitePorPagina = (int)RepoParametros.ObtenerLimitePorPagina();

            // convertir a fechas
            DateTime fechaDesde = DateTime.Parse(desde);
            DateTime fechaHasta = DateTime.Parse(hasta);

            // obtener cantidad de records que devolvio la consulta
            int totalQuery = Repo.CantidadDeMovimientos(fechaDesde, fechaHasta);

            return Math.Ceiling((double)totalQuery / (double)limitePorPagina);
        }
    }
}
