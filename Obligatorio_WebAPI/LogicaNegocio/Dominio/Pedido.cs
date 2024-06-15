using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public abstract class Pedido : IValidar {
        private DateOnly _fecha = DateOnly.FromDateTime(DateTime.Now);
        public static decimal _iva;

        public int Id { get; set; }
        public DateOnly Fecha { get { return _fecha; } set { _fecha = value; } }
        public DateOnly FechaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public decimal Total { get; set; }
        public decimal Iva { get { return _iva; } set { _iva = value; } }
        public decimal Recargo { get; set; }
        public string Estado { get; set; } // Pendiente, Entregado, Anulado

        public virtual void EsValido() {
            if (Lineas.Count == 0) {
                throw new DatosInvalidosException("El pedido debe contener al menos un artículo");
            }
        }

        public abstract void CalcularRecargo(decimal a, decimal b);
    }
}
