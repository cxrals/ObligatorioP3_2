using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUCantidadDePaginas {
        public double ObtenerCantidadDePaginas(int idArticulo, string tipoMovimiento);
        public double ObtenerCantidadDePaginas(string desde, string hasta);
    }
}
