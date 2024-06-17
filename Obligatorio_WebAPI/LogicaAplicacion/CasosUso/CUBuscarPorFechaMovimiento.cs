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
    public class CUBuscarPorFechaMovimiento : ICUBuscarPorFechaMovimiento {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioParametros RepoParametros { get; set; }
        public CUBuscarPorFechaMovimiento(IRepositorioMovimientosStock repo, IRepositorioParametros repoParametros) {
            Repo = repo;
            RepoParametros = repoParametros;
        }

        public List<ArticuloDTO> BuscarPorFecha(DateTime desde, DateTime hasta, int pagina) {
            List<ArticuloDTO> dtos = null;

            // obtener el límite de records por página establecido en Parametros
            int limitePorPagina = (int)RepoParametros.ObtenerLimitePorPagina();

            List<Articulo> articulosEncontrados = Repo.BuscarArticulosConMovimientosPorFecha(desde, hasta, pagina, limitePorPagina);
            
            if (articulosEncontrados.Count > 0) {
                dtos = MapperArticulos.ToListDto(articulosEncontrados);
            }

            return dtos;
        }
    }
}
