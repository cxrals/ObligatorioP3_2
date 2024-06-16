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
        public List<MovimientoStockIndexDTO> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento) {
            List<MovimientoStockIndexDTO> dtos = null;
            List<MovimientoStock> msEncontrados = Repo.BuscarMovimientosPorArticuloYTipo(idArticulo, tipoMovimiento);

            if (msEncontrados.Count > 0) {
                dtos = new List<MovimientoStockIndexDTO>();
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
