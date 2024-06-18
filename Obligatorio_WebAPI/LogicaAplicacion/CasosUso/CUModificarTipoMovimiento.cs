using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using System.Security.Cryptography;

namespace LogicaAplicacion.CasosUso {
    public class CUModificarTipoMovimiento : ICUModificar<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }
        public IRepositorioMovimientosStock RepoMovStock { get; set; }

        public CUModificarTipoMovimiento(IRepositorioTiposMovimientos repo, IRepositorioMovimientosStock repoMovStock) {
            Repo = repo;
            RepoMovStock = repoMovStock;

        }
        public void Modificar(TipoMovimientoDTO obj) {
            TipoMovimiento aModificar = Repo.FindById(obj.Id);

            //chequear que el tipo no este siendo usado en ningun movimiento
            if (!RepoMovStock.TieneTipoMovimiento(aModificar.Id)) {
                aModificar.Nombre = obj.Nombre;

                Repo.Update(aModificar);
            } else {
                throw new DatosInvalidosException("El tipo de movimiento no puede ser modificado porque tiene un Movimiento de Stock asociado.");
            }

        }
    }
}