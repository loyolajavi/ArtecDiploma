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
            string resultadoBuilder;
            string ClaveHashDVV;

            try
            {
                unaListaDVH = DVCalcularDVV(NomTabla);
                if (unaListaDVH.Count() == 0)
                    return false;
                //long Acum = 0;

                StringBuilder builder = new StringBuilder();
                foreach (long unDVH in unaListaDVH)
                {
                    builder.Append(unDVH).Append(";");
                    //Acum += unDVH;
                }

                resultadoBuilder = builder.ToString();
                ClaveHashDVV = ServicioSecurizacion.AplicarHash(resultadoBuilder);

                SqlParameter[] parametersDVV = new SqlParameter[]
                {
                    new SqlParameter("@NombreTabla", NomTabla),
                    //new SqlParameter("@ValorAcum", Acum)
                    new SqlParameter("@ClaveDVV", ClaveHashDVV)
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



        public static List<bool> DVVerificarIntegridadBD()
        {

            string resultadoBuilder;
            string ClaveHashDVV;
            List<bool> ValoresTrue = new List<bool>();

            try
            {
                //Usuario
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerTodosDatosCompletos"))
                {
                    List<Usuario> unaListaUsuarios = new List<Usuario>();
                    unaListaUsuarios = MapearUsuarios(ds);
                    List<long> LisDVHs = new List<long>();

                    foreach (Usuario unUs in unaListaUsuarios)
	                {

                        LisDVHs.Add(DVCalcularDVH(unUs));
	                }
                    
                    StringBuilder builder = new StringBuilder();
                    foreach (long unDVH in LisDVHs)
                    {
                        builder.Append(unDVH).Append(";");
                    }

                    resultadoBuilder = builder.ToString();
                    ClaveHashDVV = ServicioSecurizacion.AplicarHash(resultadoBuilder);

                    string ClaveHashDVVBD = DVTraerDVV("Usuario");

                    if (string.Equals(ClaveHashDVV, ClaveHashDVVBD))
                        ValoresTrue.Add(true);
                    else
                        ValoresTrue.Add(false);
                }
                //Solicitud
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "SolicitudTraerDatosDVV"))
                {
                    List<Solicitud> unaListaSolicitudes = new List<Solicitud>();
                    unaListaSolicitudes = MapearSolicitudes(ds);
                    List<long> LisDVHs = new List<long>();

                    foreach (Solicitud unaSolic in unaListaSolicitudes)
                    {

                        LisDVHs.Add(DVCalcularDVH(unaSolic));
                    }

                    StringBuilder builder = new StringBuilder();
                    foreach (long unDVH in LisDVHs)
                    {
                        builder.Append(unDVH).Append(";");
                    }

                    resultadoBuilder = builder.ToString();
                    ClaveHashDVV = ServicioSecurizacion.AplicarHash(resultadoBuilder);

                    string ClaveHashDVVBD = DVTraerDVV("Solicitud");

                    if (string.Equals(ClaveHashDVV, ClaveHashDVVBD))
                        ValoresTrue.Add(true);
                    else
                        ValoresTrue.Add(false);
                }
                return ValoresTrue;
            }
            catch (Exception es)
            {
                throw;
            }

        }


        private static List<Usuario> MapearUsuarios(DataSet ds)
        {
            List<Usuario> ResLisUsuarios = new List<Usuario>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Usuario unUsuario = new Usuario();
                    unUsuario.IdUsuario = (int)row["IdUsuario"];
                    unUsuario.NombreUsuario = row["NombreUsuario"].ToString();
                    unUsuario.Nombre = row["Nombre"].ToString();
                    unUsuario.Apellido = row["Apellido"].ToString();
                    unUsuario.Pass = row["Pass"].ToString();
                    unUsuario.Mail = row["Mail"].ToString();
                    unUsuario.IdiomaUsuarioActual = (int)row["IdiomaUsuarioActual"];
                    unUsuario.Activo = (int)row["Activo"];
                    unUsuario.DVH = (long)row["DVH"];

                    ResLisUsuarios.Add(unUsuario);
                }
                return ResLisUsuarios;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        private static List<Solicitud> MapearSolicitudes(DataSet ds)
        {
            List<Solicitud> ResLisSolicitudes = new List<Solicitud>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Solicitud unaSolic = new Solicitud();
                    unaSolic.IdSolicitud = (int)row["IdSolicitud"];
                    if (row["FechaFin"].ToString() != "")
                    {
                        unaSolic.FechaFin = DateTime.Parse(row["FechaFin"].ToString());
                    }
                    unaSolic.FechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                    unaSolic.laDependencia = new Dependencia();
                    unaSolic.laDependencia.IdDependencia = (int)row["IdDependencia"];
                    unaSolic.UnaPrioridad = new Prioridad();
                    unaSolic.UnaPrioridad.IdPrioridad = (int)row["IdPrioridad"];
                    unaSolic.UnEstado = new EstadoSolicitud();
                    unaSolic.UnEstado.IdEstadoSolicitud = (int)row["IdEstado"];
                    unaSolic.Asignado = new Usuario();
                    unaSolic.Asignado.IdUsuario = (int)row["IdUsuario"];
                    unaSolic.AgenteResp = new Agente();
                    unaSolic.AgenteResp.IdAgente = (row["IdAgente"].ToString() != "") ? (int)row["IdAgente"] : (int?)null;

                    ResLisSolicitudes.Add(unaSolic);
                }
                return ResLisSolicitudes;
            }
            catch (Exception es)
            {
                throw;
            }
        }



        public static string DVTraerDVV(string NomTabla)
        {
            SqlParameter[] parametersTraerDVV = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", NomTabla)
            };


            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                string ResDVV = FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "DVTraerDVV", parametersTraerDVV).ToString();
                return ResDVV;
            }
            catch (Exception es)
            {
                throw;
            }

        }


    }
}
