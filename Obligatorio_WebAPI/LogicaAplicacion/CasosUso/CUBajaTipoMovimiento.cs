using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso {
    public class CUBajaTipoMovimiento : ICUBaja<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }
        public IRepositorioMovimientosStock RepoMovStock { get; set; }
        
        public CUBajaTipoMovimiento(IRepositorioTiposMovimientos repo, IRepositorioMovimientosStock repoMovStock) {
            Repo = repo;
            RepoMovStock = repoMovStock;
        }

        public void Baja(int id) {
            //chequear que el tipo no este siendo usado en ningun movimiento
            if (!RepoMovStock.TieneTipoMovimiento(id)) {
                Repo.Delete(id);
            } else {
                throw new DatosInvalidosException("El tipo de movimiento no puede ser eliminado porque tiene un Movimiento de Stock asociado.");
            }
        }
    }
}