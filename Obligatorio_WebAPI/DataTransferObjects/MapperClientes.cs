using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MapperClientes {
        public static List<ClienteDTO> ToListDto(List<Cliente> clientes) {
            return clientes.Select(c => new ClienteDTO() {
                Id = c.Id,
                RazonSocial = c.RazonSocial,
                Rut = c.Rut,
                DistanciaHastaDeposito = c.DistanciaHastaDeposito,
                Direccion = c.Direccion.Calle.Valor + " " + c.Direccion.NumeroPuerta.Valor + ", " + c.Direccion.Ciudad.Valor
            })
            .ToList();
        }
    }
}
