using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarPorRazonSocial : ICUBuscarPorRazonSocial {
        public IRepositorioClientes Repo { get; set; }
        public CUBuscarPorRazonSocial(IRepositorioClientes repo) {
            Repo = repo;
        }
        public List<ClienteDTO> BuscarPorRazonSocial(string nombre) {
            List<Cliente> clientes = Repo.BuscarPorRazonSocial(nombre);
            List<ClienteDTO> clientesDTO = MapperClientes.ToListDto(clientes);
            return clientesDTO;
        }
    }
}
