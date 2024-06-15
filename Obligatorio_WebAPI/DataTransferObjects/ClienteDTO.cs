using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class ClienteDTO {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public int? DistanciaHastaDeposito { get; set; }
    }
}
