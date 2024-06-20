using DataTransferObjects;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUResumenMovimientos : ICUResumenMovimientos {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUResumenMovimientos(IRepositorioMovimientosStock repo) {
            Repo = repo;
        }
        public List<MovimientoCantidadPorAnioYTipoDTO> ObtenerResumen() {
            List<MovimientoCantidadPorAnioYTipoDTO> dtos = new List<MovimientoCantidadPorAnioYTipoDTO>();
            string msSerialized = Repo.ObtenerCantidadPorAnioYTipo();
            List<MovimientoCantidadPorAnioYTipoDTO> msEncontrados = JsonConvert.DeserializeObject<List<MovimientoCantidadPorAnioYTipoDTO>>(msSerialized);

            if (msEncontrados.Count > 0) {
                dtos = msEncontrados.Select(ms => new MovimientoCantidadPorAnioYTipoDTO() {
                    Anio = ms.Anio,
                    Cantidad = ms.Cantidad,
                    TipoMovimiento = ms.TipoMovimiento
                })
                .ToList();
            } else {
                throw new RegistroNoExisteException("No existen registros");
            }

            return dtos;
        }
    }
}
// https://www.gerbenvanadrichem.com/software-development/understanding-the-linq-nested-grouping-example/
