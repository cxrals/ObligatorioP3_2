using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUBuscarPorFechaMovimiento {
        List<ArticuloDTO> BuscarPorFecha(DateTime desde, DateTime hasta);
    }
}
