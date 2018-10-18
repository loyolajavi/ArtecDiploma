using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.FRAMEWORK;

namespace ARTEC.FRAMEWORK.Servicios
{
    public class ServicioBackup
    {

        public static bool Respaldar(string Nombre, string Destino, string Obser)
        {

            
            Destino = Destino + "\\" + Nombre + ".bak";

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Nombre", Nombre),
                new SqlParameter("@Destino", Destino),
                new SqlParameter("@Obser", Obser)
			};

            try
            {
                if (!ServicioPermisos.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Backup BD" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "BaseDatosRespaldar", parameters);
                return true;
            }
            catch (Exception es)
            {
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }




        public static bool Restaurar(string Nombre, string Ubicacion)
        {
            try
            {
                if (!ServicioPermisos.BuscarPermiso(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.Permisos, new string[] { "Restore BD" }))
                    throw new InvalidOperationException("No posee los permisos suficientes");
                string stringPararProcesos = "DECLARE @ProcessId varchar(4) " + Environment.NewLine + "DECLARE CurrentProcesses SCROLL CURSOR FOR" + Environment.NewLine + 
                                "select spid from sysprocesses where dbid = (select dbid from sysdatabases where name = 'Artec' ) order by spid " + Environment.NewLine + 
                                "FOR READ ONLY" + Environment.NewLine + "OPEN CurrentProcesses" + Environment.NewLine + "FETCH NEXT FROM CurrentProcesses INTO @ProcessId" + 
                                Environment.NewLine + "WHILE @@FETCH_STATUS <> -1" + Environment.NewLine + "BEGIN" + Environment.NewLine + "	Exec ('KILL ' +  @ProcessId)" + 
                                Environment.NewLine + "	FETCH NEXT FROM CurrentProcesses INTO @ProcessId" + Environment.NewLine + "                    End" + Environment.NewLine + 
                                "CLOSE CurrentProcesses" + Environment.NewLine + "DeAllocate CurrentProcesses";

                string stringRestaurar = "RESTORE DATABASE " + Nombre + " FROM DISK = '" + Ubicacion + "' WITH REPLACE, RECOVERY";

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciarParaRestauracion();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.Text, stringPararProcesos);
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.Text, stringRestaurar);
                return true;
            }
            catch (Exception es)
            {
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
