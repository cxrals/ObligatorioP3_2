using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso {
    public class CUAltaTipoMovimiento : ICUAlta<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo { get; set; }

        public CUAltaTipoMovimiento(IRepositorioTiposMovimientos repo) {
            Repo = repo;
        }
        public void Alta(TipoMovimientoDTO obj) {
            TipoMovimiento nuevo = new TipoMovimiento();
            nuevo.Id = obj.Id;
            nuevo.Nombre = obj.Nombre;

            Repo.Create(nuevo);
            obj.Id = nuevo.Id;
        }
    }
}