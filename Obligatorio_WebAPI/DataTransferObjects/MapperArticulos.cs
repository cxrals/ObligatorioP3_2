using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects {
    public class MapperArticulos {
        public static List<ArticuloDTO> ToListDto(List<Articulo> articulos) {
            return articulos.Select(a => new ArticuloDTO() {
                Id = a.Id,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion
            })
            .ToList();
        }
    }
}
