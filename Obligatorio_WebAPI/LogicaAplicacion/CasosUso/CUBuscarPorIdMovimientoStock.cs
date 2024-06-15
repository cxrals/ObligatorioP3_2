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
    public class CUBuscarPorIdMovimientoStock : ICUBuscarPorId<MovimientoStockDTO> {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUBuscarPorIdMovimientoStock(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }

        public MovimientoStockDTO BuscarPorId(int id) {
            MovimientoStockDTO dto = new MovimientoStockDTO();
            MovimientoStock msEncontrado = Repo.FindById(id);

            if (msEncontrado != null) {
                dto.Id = msEncontrado.Id;
                dto.Fecha = msEncontrado.Fecha;
            } else {
                throw new RegistroNoExisteException("El tipo de movimiento no existe");
            }

            return dto;
        }
    }
}
