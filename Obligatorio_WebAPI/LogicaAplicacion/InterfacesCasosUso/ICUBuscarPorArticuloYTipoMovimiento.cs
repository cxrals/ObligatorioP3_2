using DataTransferObjects;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUBuscarPorArticuloYTipoMovimiento {
        List<MovimientoStockIndexDTO> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento);
    }
}
