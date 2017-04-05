﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLCategoria
    {

        DALCategoria GestorCategoria = new DALCategoria();

        public List<Categoria> CategoriaTraerTodosHard()
        {
            return GestorCategoria.CategoriaTraerTodosHard();
        }

        public List<Categoria> CategoriaTraerTodosSoft()
        {
            return GestorCategoria.CategoriaTraerTodosSoft();
        }

        public List<Categoria> CategoriaTraerTodos()
        {
            return GestorCategoria.CategoriaTraerTodos();
        }


        public List<DTOCategoria> CategoriaTraerTodosPru()
        {
            return GestorCategoria.CategoriaTraerTodosPru();
        }

    }
}
