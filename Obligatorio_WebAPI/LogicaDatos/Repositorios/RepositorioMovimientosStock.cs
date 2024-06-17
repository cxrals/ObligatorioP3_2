using DataTransferObjects;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public List<MovimientoStock> BuscarMovimientosPorArticuloYTipo(int idArticulo, string tipoMovimiento, int pagina, int limitePorPagina) {
            return Contexto.MovimientosStock
                .Where(ms => ms.Articulo.Id == idArticulo 
                    && ms.TipoMovimiento.Nombre == tipoMovimiento)
                .Include(ms => ms.TipoMovimiento)
                .Include(ms => ms.Articulo)
                .Include(ms => ms.Usuario)
                .OrderByDescending(ms => ms.Fecha)
                .ThenBy(ms => ms.Cantidad)
                .Skip((pagina - 1) * limitePorPagina)
                .Take(limitePorPagina)
                .ToList();
        }

        public List<Articulo> BuscarArticulosConMovimientosPorFecha(DateTime desde, DateTime hasta, int pagina, int limitePorPagina) {
            return Contexto.MovimientosStock
                .Where(ms => ms.Fecha >= desde && ms.Fecha <= hasta)
                .Select(ms => ms.Articulo)
                .Skip((pagina - 1) * limitePorPagina)
                .Take(limitePorPagina)
                .ToList();
        }

        public string ObtenerCantidadPorAnioYTipo() {
            List<MovimientoCantidadPorAnioYTipoDTO> consulta = new List<MovimientoCantidadPorAnioYTipoDTO>();

            consulta = Contexto.MovimientosStock
            .GroupBy(ms => new { Anio = ms.Fecha.Year, ms.TipoMovimiento.Nombre })
            .Select(grupo => new MovimientoCantidadPorAnioYTipoDTO {
                Anio = grupo.Key.Anio,
                TipoMovimiento = grupo.Key.Nombre,
                Cantidad = grupo.Sum(g => g.Cantidad)
            })
            .ToList();

            return JsonConvert.SerializeObject(consulta);
        }

        public int CantidadDeMovimientos(int idArticulo, string tipoMovimiento) {
            return Contexto.MovimientosStock
            .Where(ms => ms.Articulo.Id == idArticulo
                    && ms.TipoMovimiento.Nombre == tipoMovimiento)
            .Count();
        }

        public int CantidadDeMovimientos(DateTime desde, DateTime hasta) {
            return Contexto.MovimientosStock
            .Where(ms => ms.Fecha >= desde && ms.Fecha <= hasta)
            .Count();
        }
    }
}
