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
    public class CUResumenMovimientos : ICUResumenMovimientos {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUResumenMovimientos(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }
        public List<MovimientoStockDTO> ObtenerResumen() {
            List<MovimientoStockDTO> dtos = new List<MovimientoStockDTO>();
            List<MovimientoStock> msEncontrados = Repo.ObtenerCantidadPorAnioYTipo();

            if (msEncontrados.Count > 0) {
                //TODO cambiar a otro dto
                dtos = msEncontrados.Select(ms => new MovimientoStockDTO() {
                    Id = ms.Id,
                    Fecha = ms.Fecha,
                    Cantidad = ms.Cantidad
                })
                .ToList();
            }

            return dtos;
        }
    }
}
