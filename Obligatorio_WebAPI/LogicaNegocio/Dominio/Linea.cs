using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Linea {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int UnidadesSolicitadas { get; set; }
        public int PreciodUnitario { get; set; }
    }
}
