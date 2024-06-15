using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorIdTipoMovimiento : ICUBuscarPorId<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }
        public CUBuscarPorIdTipoMovimiento(IRepositorioTiposMovimientos repo) {
            Repo = repo;
        }
        public TipoMovimientoDTO BuscarPorId(int id) {
            TipoMovimientoDTO dto = new TipoMovimientoDTO();
            TipoMovimiento tmEncontrado = Repo.FindById(id);

            if (tmEncontrado != null) {
                dto.Id = tmEncontrado.Id;
                dto.Nombre = tmEncontrado.Nombre;
            } else {
                throw new RegistroNoExisteException("El tipo de movimiento no existe");
            }

            return dto;
        }
    }
}