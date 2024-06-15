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
    public class CUOrdenarArticulosAsc : ICUOrdenarArticulosAsc {

        public IRepositorioArticulos Repo { get; set; }
        public CUOrdenarArticulosAsc(IRepositorioArticulos repo) {
            Repo = repo;
        }

        // Listado con todos los artículos ordenados alfabéticamente en forma ascendente
        public List<ArticuloDTO> OrdenarPorNombreAsc() {
            List<ArticuloDTO> dtos = new List<ArticuloDTO>();
            List<Articulo> articulosOrdenados = Repo.OrdenarArticulosAsc();
            if (articulosOrdenados.Count > 0) {
                dtos = MapperArticulos.ToListDto(articulosOrdenados);
            }
            return dtos;
        }
    }
}
