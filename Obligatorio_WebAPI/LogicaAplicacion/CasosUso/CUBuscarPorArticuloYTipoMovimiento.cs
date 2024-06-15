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
        public CUBuscarPorArticuloYTipoMovimiento(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }
        public List<MovimientoStockDTO> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento) {
            List<MovimientoStockDTO> dtos = new List<MovimientoStockDTO>();
            List<MovimientoStock> msEncontrados = Repo.BuscarMovimientosPorArticuloYTipo(idArticulo, tipoMovimiento);

            if (msEncontrados.Count > 0) {
            //TODO agregar mas field de tipo mmov
                dtos = msEncontrados.Select(ms => new MovimientoStockDTO() {
                    Id = ms.Id,
                    Fecha = ms.Fecha,
                    Cantidad = ms.Cantidad,
                    TipoMovimientoId = ms.TipoMovimiento.Id
                })
                .ToList();
            }

            return dtos;
        }
    }
}
