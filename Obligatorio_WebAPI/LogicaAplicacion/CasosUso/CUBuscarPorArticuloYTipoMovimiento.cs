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
    public class CUBuscarPorArticuloYTipoMovimiento : ICUBuscarPorArticuloYTipoMovimiento {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioParametros RepoParametros { get; set; }
        public CUBuscarPorArticuloYTipoMovimiento(IRepositorioMovimientosStock repo, IRepositorioParametros repoParametros) {
            Repo = repo;
            RepoParametros = repoParametros;
        }
        public List<MovimientoStockIndexDTO> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento, int pagina) {
            List<MovimientoStockIndexDTO> dtos = null;

            // obtener el límite de records por página establecido en Parametros
            int limitePorPagina = (int) RepoParametros.ObtenerLimitePorPagina();

            List<MovimientoStock> msEncontrados = Repo.BuscarMovimientosPorArticuloYTipo(idArticulo, tipoMovimiento, pagina, limitePorPagina);

            if (msEncontrados.Count > 0) {
                // aplicar paginado al resultado de la query
                // tdoo evaluar aplicar a nivel de repo xa no traer todos los records de la base
                //List<MovimientoStock> dtosPorPagina = msEncontrados.Skip((pagina - 1) * limitePorPagina).Take(limitePorPagina).ToList();

                dtos = msEncontrados.Select(ms => new MovimientoStockIndexDTO() {
                    Id = ms.Id,
                    Fecha = ms.Fecha,
                    Cantidad = ms.Cantidad,
                    ArticuloNombre = ms.Articulo.Nombre,
                    EmailUsuario = ms.Usuario.Email,
                    TipoMovimientoNombre = ms.TipoMovimiento.Nombre,
                    TipoMovimientoAccion = ms.TipoMovimiento.TipoAccion.ToString()
                })
                .ToList();
            }

            return dtos;
        }
    }
}
