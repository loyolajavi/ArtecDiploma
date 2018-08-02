using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using System.Data.SqlClient;

namespace ARTEC.DAL
{
    //public class DALBien
    //{

    //    public int BienTraerIdPorDescripMarcaModelo(Bien unBien, int Tipo)
    //    {

    //        SqlParameter[] parameters = new SqlParameter[]
    //        {
    //            new SqlParameter("@IdCategoria", unBien.unaCategoria.IdCategoria),
    //            new SqlParameter("@IdTipoBien", Tipo),
    //            new SqlParameter("@IdMarca", unBien.unaMarca.IdMarca),
    //            new SqlParameter("@IdModelo", unBien.unModelo.IdModeloVersion)
    //        };

    //        int ResIdBien = (int)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "BienTraerIdPorDescripMarcaModelo", parameters);
    //        return ResIdBien;
    //    }

    //}
}
