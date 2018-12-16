using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace ARTEC.FRAMEWORK.Servicios
{
    public class ManejoArchivos
    {

        public static void CopiarArchivo(string Origen, string Destino)
        {
            try
            {
                // Copiar el archivo si existe lo sobreescribe
                if(File.Exists(Destino))
                {
                    File.Delete(Destino);
                }
                File.Copy(Origen, Destino, true);

            }
            catch (Exception ex)
            {
                throw;
            }

        }



        /// <summary>
        /// Valida si la extesión del adjunto es correcta
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool ValidarAdjunto(string RutaCompletaArchivo)
        {
            string ext = Path.GetExtension(RutaCompletaArchivo).ToLower();
            if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp") || (ext == ".pdf") || (ext == ".txt"))
            {
                return true;
            }
            return false;
        }

        public static string obtenerRutaAdjuntos()
        {
            
            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                string laRuta = (string)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "obtenerRutaAdjuntos");
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return laRuta;
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


        //public static void RegistrarAdjunto(int IdSolicitud, string unAdjuntoRutaCompleta, string unAdjuntoNombre)
        //{
            

        //    try
        //    {
        //        string NombreConExtension;
        //        string ext = Path.GetExtension(unAdjuntoRutaCompleta).ToLower();
        //        NombreConExtension = unAdjuntoNombre + "." + ext;

        //        SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@Nombre", unAdjuntoNombre)
        //        };

        //        FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
        //        var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RegistrarAdjunto", parameters);
        //        int IDDevuelto = Decimal.ToInt32(Resultado);
        //        SqlParameter[] parametersSolicAdj = new SqlParameter[]
        //        {
        //            new SqlParameter("@IdSolicitud", IdSolicitud),
        //            new SqlParameter("@IdAdjunto", IDDevuelto)
        //        };
        //        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AdjuntoSolicitud", parametersSolicAdj);
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
        //    }
        //    catch (Exception es)
        //    {
        //        FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
        //        throw;
        //    }
        //    finally
        //    {
        //        if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
        //            FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
        //    }

        //}



    }
}
