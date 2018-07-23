using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using System.Data;
using System.Data.SqlClient;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioDV
    {
        public static long DVCalcularDVH(object unObjeto)
        {
            string TipoObj;
            string ClaveStr;
            string ClaveHash;

            try
            {
                TipoObj = unObjeto.GetType().Name;
                //Usuario
                if (TipoObj == "Usuario")
                {
                    Usuario unUsuario = unObjeto as Usuario;
                    ClaveStr = unUsuario.IdUsuario.ToString() + unUsuario.NombreUsuario + unUsuario.Pass + unUsuario.IdiomaUsuarioActual.ToString() +
                               unUsuario.Nombre + unUsuario.Apellido + unUsuario.Mail + unUsuario.Activo.ToString();
                    ClaveHash = ServicioSecurizacion.AplicarHash(ClaveStr);

                    long Acum = 0;
                    foreach (char letra in ClaveHash)
                    {

                        Acum += (long)letra;
                    }
                    
                    return Acum;
                }
                //Solicitud
                if (TipoObj == "Solicitud")
                {
                    Solicitud unaSolicitud = unObjeto as Solicitud;
                    ClaveStr = unaSolicitud.IdSolicitud.ToString() + unaSolicitud.FechaInicio.ToString() + unaSolicitud.FechaFin.ToString() +
                               unaSolicitud.laDependencia.IdDependencia.ToString() + unaSolicitud.UnaPrioridad.IdPrioridad.ToString() + unaSolicitud.UnEstado.IdEstadoSolicitud.ToString() +
                               unaSolicitud.Asignado.IdUsuario.ToString() + unaSolicitud.AgenteResp.IdAgente.ToString();
                    ClaveHash = ServicioSecurizacion.AplicarHash(ClaveStr);

                    long Acum = 0;
                    foreach (char letra in ClaveHash)
                    {
                        Acum += (long)letra;
                    }

                    return Acum;
                }
                return 0;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public static bool DVActualizarDVH(int IdFila, long Acum, string NomTabla, string NomColumnaWhere)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", NomTabla),
                new SqlParameter("@IdFila", IdFila),
                new SqlParameter("@ValorAcum", Acum),
                new SqlParameter("@NomColumna", NomColumnaWhere)
            };

            try
            {
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DVActualizarDVH", parameters);
                if (FilasAfectadas > 0)
                {
                    if(DVActualizarDVV(NomTabla))
                        return true;
                }
                return false;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
        }


        public static bool DVActualizarDVV(string NomTabla)
        {
            List<long> unaListaDVH = new List<long>();


            try
            {
                unaListaDVH = DVCalcularDVV(NomTabla);
                if (unaListaDVH.Count() == 0)
                    return false;
                long Acum = 0;
                foreach (long unDVH in unaListaDVH)
                {
                    Acum += unDVH;
                }

                SqlParameter[] parametersDVV = new SqlParameter[]
                {
                    new SqlParameter("@NombreTabla", NomTabla),
                    new SqlParameter("@ValorAcum", Acum)
                };

                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DVActualizarDVV", parametersDVV);
                if (FilasAfectadas > 0)
                    return true;
                return false;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<long> DVCalcularDVV(string NomTabla)
        {
            
            SqlParameter[] parametersSumaDVH = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", NomTabla)
            };


            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSetPrueba(CommandType.StoredProcedure, "DVTraerDVHSuma", parametersSumaDVH))
                {
                    List<long> unaListaDVH = new List<long>();
                    unaListaDVH = MapearDVHs(ds);
                    return unaListaDVH;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<long> MapearDVHs(DataSet ds)
        {
            List<long> resDVHs = new List<long>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    long unDVH = new long();
                    unDVH = (long)row["DVH"];
                    resDVHs.Add(unDVH);
                }
                return resDVHs;
            }
            catch (Exception es)
            {
                throw;
            }
        }



    }
}
