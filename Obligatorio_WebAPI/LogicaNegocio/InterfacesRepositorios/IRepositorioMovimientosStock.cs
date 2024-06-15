using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioMovimientosStock {
        void Create(MovimientoStock obj);
        List<MovimientoStock> GetAll();
        MovimientoStock FindById(int id);
    }
}
