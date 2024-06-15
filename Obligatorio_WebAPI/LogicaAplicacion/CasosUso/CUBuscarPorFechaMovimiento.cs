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
        public CUBuscarPorFechaMovimiento(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }

        public List<ArticuloDTO> BuscarPorFecha(DateTime desde, DateTime hasta) {
            List<ArticuloDTO> dtos = new List<ArticuloDTO>();
            List<Articulo> articulosEncontrados = Repo.BuscarArticulosConMovimientosPorFecha(desde, hasta);
            
            if (articulosEncontrados.Count > 0) {
                dtos = MapperArticulos.ToListDto(articulosEncontrados);
            }

            return dtos;
        }
    }
}
