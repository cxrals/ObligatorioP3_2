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
    public class CUListadoMovimientosStock : ICUListado<MovimientoStockIndexDTO> {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUListadoMovimientosStock(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }
        public List<MovimientoStockIndexDTO> ObtenerListado() {
            List<MovimientoStockIndexDTO> dtos = new List<MovimientoStockIndexDTO>();
            List<MovimientoStock> tmEncontrados = Repo.GetAll();

            if (tmEncontrados.Count > 0) {
                dtos = tmEncontrados.Select(ms => new MovimientoStockIndexDTO() {
                    Id = ms.Id,
                    Fecha = ms.Fecha,
                    Cantidad = ms.Cantidad,
                    ArticuloNombre = ms.Articulo.Nombre,
                    EmailUsuario = ms.Usuario.Email,
                    TipoMovimientoNombre = ms.TipoMovimiento.Nombre,
                })
                .ToList();
            }
            return dtos;
        }
    }
}
