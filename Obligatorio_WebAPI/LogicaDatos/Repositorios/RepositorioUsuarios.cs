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
    public class RepositorioUsuarios : IRepositorioUsuarios {
        public ObligatorioContext Contexto { get; set; }
        public RepositorioUsuarios(ObligatorioContext ctx) { 
            Contexto = ctx;
        }
        public void Create(Usuario obj) {
            obj.EsValido();
            if (!Contexto.Usuarios.Any(u => u.Email.ToLower() == obj.Email.ToLower())) {
                Contexto.Usuarios.Add(obj);
                Contexto.SaveChanges();
            } else {
                throw new DuplicadoException("Ya existe un usuario registrado con ese email.");
            }
        }

        public void Delete(int id) {
            Usuario aBorrar = FindById(id);
            if (aBorrar != null) {
                Contexto.Usuarios.Remove(aBorrar);
                Contexto.SaveChanges();
            } else {
                throw new RegistroNoExisteException("El usuario no existe");
            }
        }

        public void Update(Usuario obj) {
            obj.EsValido();
            if (!Contexto.Usuarios.Any(u => u.Email.ToLower() == obj.Email.ToLower())) {
                Contexto.Usuarios.Update(obj);
                Contexto.SaveChanges();
            } else {
                throw new DuplicadoException("Ya existe un usuario registrado con ese email.");
            }
        }

        public Usuario BuscarPorEmail(string email) {
            return Contexto.Usuarios.Where(u => u.Email.ToLower() == email.ToLower()).SingleOrDefault();
        }

        public Usuario BuscarPorEmail(string email, string password) {
            return Contexto.Usuarios.Where(u => u.Email.ToLower() == email.ToLower() && u.Contraseña == password).SingleOrDefault();
        }

        public List<Usuario> GetAll() {
            return Contexto.Usuarios.ToList();
        }

        public Usuario FindById(int id) {
            return Contexto.Usuarios.Find(id);
        }
    }
}
