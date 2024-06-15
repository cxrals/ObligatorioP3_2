using DataTransferObjects;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioMovimientosStock : IRepositorioMovimientosStock {
        public ObligatorioContext Contexto { get; private set; }

        public RepositorioMovimientosStock(ObligatorioContext ctx) {
            Contexto = ctx;
        }
        public void Create(MovimientoStock obj) {
            obj.EsValido();
            Contexto.Entry(obj.Articulo).State = EntityState.Unchanged;
            Contexto.MovimientosStock.Add(obj);
            Contexto.SaveChanges();
        }

        public MovimientoStock FindById(int id) {
            return Contexto.MovimientosStock.Find(id);
        }

        public List<MovimientoStock> GetAll() {
            return Contexto.MovimientosStock
            .Include(ms => ms.Articulo)
            .Include(ms => ms.TipoMovimiento)
            .Include(ms => ms.Usuario)
            .ToList();
        }

        public List<MovimientoStock> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento) {
            // todo incluir fields de tipoMov
            return Contexto.MovimientosStock
                .Where(ms => ms.Articulo.Id == idArticulo 
                    && ms.TipoMovimiento.Nombre == tipoMovimiento)
                .Include(ms => ms.TipoMovimiento)
                .OrderByDescending(ms => ms.Fecha)
                .ThenBy(ms => ms.Cantidad)
                .ToList();
        }

        public List<Articulo> BuscarArticulosConMovimientosPorFecha(DateTime desde, DateTime hasta) {
            return Contexto.MovimientosStock
                .Where(ms => ms.Fecha >= desde && ms.Fecha <= hasta)
                .Select(ms => ms.Articulo)
                .ToList();
        }

        public List<MovimientoStock> ObtenerCantidadPorAnioYTipo() {
            return Contexto.MovimientosStock
            //TODO
            //.GroupBy(ms => new { Anio = ms.Fecha.Year })
            //.Select(grupo => {
            //    new MovimientoCantidadPorAnioYTipoDTO() {
            //        Anio = grupo.Key.Anio,
            //        Cantidad = grupo.Sum(ms => ms.Cantidad)
            //    };
            //})
            .ToList();
        }

  
    }
}
