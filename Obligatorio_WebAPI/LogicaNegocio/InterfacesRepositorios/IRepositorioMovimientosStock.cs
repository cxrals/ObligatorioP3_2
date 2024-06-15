using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioMovimientosStock {
        List<MovimientoStock> GetAll();
        void Create(MovimientoStock obj);
        MovimientoStock FindById(int id);
        List<MovimientoStock> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento);
        List<MovimientoStock> ObtenerCantidadPorAnioYTipo();
        List<Articulo> BuscarArticulosConMovimientosPorFecha(DateTime desde, DateTime hasta);

    }
}
