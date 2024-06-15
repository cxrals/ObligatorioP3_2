using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso {
    public class CUModificarTipoMovimiento : ICUModificar<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }

        public CUModificarTipoMovimiento(IRepositorioTiposMovimientos repo) {
            Repo = repo;
        }
        public void Modificar(TipoMovimientoDTO obj) {
            TipoMovimiento aModificar = Repo.FindById(obj.Id);
            aModificar.Nombre = obj.Nombre;

            Repo.Update(aModificar);

        }
    }
}