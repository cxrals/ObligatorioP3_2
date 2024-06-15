﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorio<T> {
        void Create(T obj);
        void Delete(int id);
        void Update(T obj);
        List<T> GetAll();
        T FindById(int id);
    }
}
