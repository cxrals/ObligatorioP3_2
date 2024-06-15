using LogicaNegocio.Dominio;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioTiposMovimientos : IRepositorioTiposMovimientos {
        public ObligatorioContext Contexto { get; private set; }

        public RepositorioTiposMovimientos(ObligatorioContext ctx) {
            Contexto = ctx;
        }

        public void Create(TipoMovimiento obj) {
            if (!Contexto.TiposMovimientos.Any(t => t.Nombre.ToLower() == obj.Nombre.ToLower())) {
                Contexto.TiposMovimientos.Add(obj);
                Contexto.SaveChanges();
            } else {
                throw new DuplicadoException("Ya existe un tipo de movimiento con ese nombre.");
            }
        }

        public void Delete(int id) {
            //todo agregar chequeo de que el tipo no este siendo usado en ningun movimiento
            TipoMovimiento aBorrar = FindById(id);
            if (aBorrar != null) {
                Contexto.TiposMovimientos.Remove(aBorrar);
                Contexto.SaveChanges();
            } else {
                throw new RegistroNoExisteException("El tipo de movimiento no existe");
            }
        }

        public TipoMovimiento FindById(int id) {
            return Contexto.TiposMovimientos.Find(id);
        }

        public List<TipoMovimiento> GetAll() {
            return Contexto.TiposMovimientos.ToList();
        }

        public void Update(TipoMovimiento obj) {
            //todo agregar chequeo de que el tipo no este siendo usado en ningun movimiento
            obj.EsValido();
            TipoMovimiento tm = Contexto.TiposMovimientos.Where(t => t.Nombre.ToLower() == obj.Nombre.ToLower()).SingleOrDefault();

            if (tm != null) {
                if(tm.Id == obj.Id) {
                    throw new DuplicadoException("Ya existe un tipo de movimiento con ese nombre.");
                } else {
                    Contexto.Entry(tm).State = EntityState.Detached;
                }
            }

            Contexto.TiposMovimientos.Update(obj);
            Contexto.SaveChanges();
        }
    }
}
