using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;


namespace ARTEC.DAL
{
    public class DALCategoria
    {

        /// <summary>
        /// Traer todas las categorías que sean Hardware
        /// </summary>
        /// <returns></returns>
        public List<Categoria> CategoriaTraerTodosHard()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodosHard"))
                {
                    List<Categoria> unasCategorias = new List<Categoria>();
                    unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                    return unasCategorias;
                }
            }
            catch (Exception es)
            {
                throw;
            }
           
        }


        public List<Categoria> CategoriaTraerTodosSoft()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodosSoft"))
            {
                List<Categoria> unasCategorias = new List<Categoria>();
                unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                return unasCategorias;
            }
        }


        public List<Categoria> CategoriaTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerTodos"))
            {
                List<Categoria> unasCategorias = new List<Categoria>();
                unasCategorias = FRAMEWORK.Persistencia.Mapeador.Mapear<Categoria>(ds);
                return unasCategorias;
            }
        }



          public static Categoria MapearCategoriaUno(DataSet ds)
        {
            Categoria ResCategoria = new Categoria();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ResCategoria.IdCategoria = (int)row["IdCategoria"];
                    ResCategoria.DescripCategoria = row["DescripCategoria"].ToString();
                }
                return ResCategoria;
            }
            catch (Exception es)
            {

                throw;
            }
        }



          public bool CategoriaCrear(Categoria nuevaCategoria)
          {
              SqlParameter[] parametersCatCrear = new SqlParameter[]
			{
                new SqlParameter("@DescripCategoria", nuevaCategoria.DescripCategoria),
                new SqlParameter("@IdTipoBien", nuevaCategoria.unTipoBien.IdTipoBien)
			};

              try
              {
                  FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                  FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                  var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "CategoriaCrear", parametersCatCrear);
                  int IdCatRes = Decimal.ToInt32(Resultado);
                  nuevaCategoria.IdCategoria = IdCatRes;

                  if (nuevaCategoria.LosProveedores != null && nuevaCategoria.LosProveedores.Count > 0)
                  {
                      foreach (Proveedor unProv in nuevaCategoria.LosProveedores)
                      {
                          SqlParameter[] parametersProv = new SqlParameter[]
			            {
                            new SqlParameter("@IdCategoria", nuevaCategoria.IdCategoria),
                            new SqlParameter("@IdProveedor", unProv.IdProveedor)
			            };

                          FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CategoriaProvAsociar", parametersProv);
                      }
                  }
                 
                  FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                  return true;
              }
              catch (Exception es)
              {
                  FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                  throw;
              }
              finally
              {
                  if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                      FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
              }
          }

          public Categoria CategoriaBuscar(string NomCategoria)
          {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NomCategoria", NomCategoria)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaBuscar", parameters))
                {
                    Categoria unaCat = new Categoria();
                    unaCat = FRAMEWORK.Persistencia.Mapeador.MapearUno<Categoria>(ds);
                    return unaCat;
                }
            }
            catch (Exception es)
            {
                throw;
            }
          }



          public List<Proveedor> CategoriaTraerProveedores(int IdCategoria)
          {
              SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdCategoria", IdCategoria)
            };

              try
              {
                  using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "CategoriaTraerProveedores", parameters))
                  {
                      List<Proveedor> ListaProv = new List<Proveedor>();
                      ListaProv = FRAMEWORK.Persistencia.Mapeador.Mapear<Proveedor>(ds);
                      return ListaProv;
                  }
              }
              catch (Exception es)
              {
                  throw;
              }
          }

          public bool CategoriaModificar(Categoria unaCategoria, List<Proveedor> ProvQuitarMod, List<Proveedor> ProvAgregarMod)
          {
              SqlParameter[] parametersCatModif = new SqlParameter[]
			{
                new SqlParameter("@DescripCategoria", unaCategoria.DescripCategoria),
                new SqlParameter("@IdTipoBien", unaCategoria.unTipoBien.IdTipoBien),
                new SqlParameter("@IdCategoria", unaCategoria.IdCategoria)
			};

              try
              {
                  FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                  FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                  FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CategoriaModificar", parametersCatModif);


                  if (ProvQuitarMod.Count > 0)
                  {
                      foreach (Proveedor unProv in ProvQuitarMod)
                      {
                          SqlParameter[] parametersProvQuitar = new SqlParameter[]
			            {
                            new SqlParameter("@IdCategoria", unaCategoria.IdCategoria),
                            new SqlParameter("@IdProveedor", unProv.IdProveedor)
			            };

                          FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CategoriaProvDesasociar", parametersProvQuitar);
                      }
                  }

                  if (ProvAgregarMod.Count > 0)
                  {
                      foreach (Proveedor unProv in ProvAgregarMod)
                      {
                          SqlParameter[] parametersProvAgregar = new SqlParameter[]
			            {
                            new SqlParameter("@IdCategoria", unaCategoria.IdCategoria),
                            new SqlParameter("@IdProveedor", unProv.IdProveedor)
			            };

                          FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "CategoriaProvAsociar", parametersProvAgregar);
                      }
                  }
                  FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                  return true;
              }
              catch (Exception es)
              {
                  FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                  throw;
              }
              finally
              {
                  if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                      FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
              }
          }
    }
}
