using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.ENTIDADES.Servicios;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.DAL.Servicios
{
    public static class DALServicioIdioma
    {
        public static List<Idioma> IdiomaTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "IdiomaTraerTodos"))
                {
                    List<Idioma> unaLista = new List<Idioma>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Idioma>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static void EtiquetasTraerTodosPorIdioma(int elIdioma)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdioma)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "EtiquetasTraerTodosPorIdioma", parameters))
                {
                    //_EtiquetasCompartidas = FRAMEWORK.Persistencia.Mapeador.Mapear<Etiqueta>(ds);
                    Idioma._EtiquetasCompartidas = MapearIdiomaEtiquetas(ds);

                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private static List<Etiqueta> MapearIdiomaEtiquetas(DataSet ds)
        {
            List<Etiqueta> ResEtiquetas = new List<Etiqueta>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Etiqueta unaEtiqueta = new Etiqueta();

                    unaEtiqueta.NombreControl = row["NombreControl"].ToString();
                    unaEtiqueta.Texto = row["Texto"].ToString();

                    ResEtiquetas.Add(unaEtiqueta);
                }
                return ResEtiquetas;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static void IdiomaUsuarioActualModificar()
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdiomaUsuarioActual", Idioma.unIdiomaActual),
                new SqlParameter("@IdUsuario", FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.IdUsuario)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "IdiomaUsuarioActualModificar", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }


        public static void IdiomaActualizarIdiomaDefault(int elIdIdioma, bool Valor)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdIdioma", elIdIdioma),
                new SqlParameter("@ElIdiomaDefault", Valor)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "IdiomaActualizarIdiomaDefault", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            finally
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }


    }
}
