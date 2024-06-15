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
    public class CUListadoClientes : ICUListado<ClienteDTO> {
        public IRepositorioClientes Repo { get; set; }

        public CUListadoClientes(IRepositorioClientes repo) {
            Repo = repo;
        }
        public List<ClienteDTO> ObtenerListado() {
            List<Cliente> clientes = Repo.GetAll();
            List<ClienteDTO> clientesDTO = MapperClientes.ToListDto(clientes);
            return clientesDTO;
        }
    }
}
