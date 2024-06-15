using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso {
    public class CUBajaTipoMovimiento : ICUBaja<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }

        public CUBajaTipoMovimiento(IRepositorioTiposMovimientos repo) {
            Repo = repo;
        }

        public void Baja(int id) {
            Repo.Delete(id);
        }
    }
}