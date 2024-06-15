using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoTiposMovimientos : ICUListado<TipoMovimientoDTO> {
        public IRepositorioTiposMovimientos Repo {  get; set; }

        public CUListadoTiposMovimientos(IRepositorioTiposMovimientos repo) {
            Repo = repo;
        }
        public List<TipoMovimientoDTO> ObtenerListado() {
            List<TipoMovimientoDTO> dtos = new List<TipoMovimientoDTO>();
            List<TipoMovimiento> tmEncontrados = Repo.GetAll();
            if (tmEncontrados.Count > 0) {

                dtos = tmEncontrados.Select(t => new TipoMovimientoDTO() {
                    Id = t.Id,
                    Nombre = t.Nombre
                })
                .ToList();
            }
            return dtos;
        }
    }
}