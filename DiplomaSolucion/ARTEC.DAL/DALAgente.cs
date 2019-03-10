using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.DAL
{
    public class DALAgente
    {

        public static List<Agente> MapearAgentes(DataSet ds)
        {
            List<Agente> ResAgentes = new List<Agente>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Agente unAgente = new Agente();

                       unAgente.IdAgente = (int)row["IdAgente"];
                        unAgente.NombreAgente = row["NombreAgente"].ToString();
                        unAgente.ApellidoAgente = row["ApellidoAgente"].ToString();
                    
                    //unAgente.unaDependencia = 
                    //unAgente.unCargo = 
                    ResAgentes.Add(unAgente);
                }
                return ResAgentes;
            }
            catch (Exception es)
            {
                //VER:Excepciones
                throw;
            }
        }


        public List<Agente> AgentesTraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AgentesTraerTodos"))
            {
                List<Agente> unaLista = new List<Agente>();
                unaLista = MapearAgentes(ds);
                return unaLista;
            }
        }

        public void AgenteCrear(Agente NuevoAgente, int IdDep)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@NombreAgente", NuevoAgente.NombreAgente),
                new SqlParameter("@ApellidoAgente", NuevoAgente.ApellidoAgente)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AgenteCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);


                    SqlParameter[] parametersRelDepAgenteCargo = new SqlParameter[]
			        {
                        new SqlParameter("@IdAgente", IDDevuelto),
                        new SqlParameter("@IdDependencia", IdDep),
                        new SqlParameter("@IdCargo", NuevoAgente.unCargo.IdCargo)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RelDepAgenteCargoCrear", parametersRelDepAgenteCargo);
                
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
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

        public Agente AgenteBuscar(string ApellidoAgente)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ApellidoAgente", ApellidoAgente)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AgenteBuscar", parameters))
                {
                    Agente unAg = new Agente();
                    unAg = FRAMEWORK.Persistencia.Mapeador.MapearUno<Agente>(ds);
                    return unAg;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public List<Dependencia> AgenteTraerDependencias(int IdAgente)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdAgente", IdAgente)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AgenteTraerDependencias", parameters))
                {
                    List<Dependencia> unasDep = new List<Dependencia>();
                    unasDep = FRAMEWORK.Persistencia.Mapeador.Mapear<Dependencia>(ds);
                    return unasDep;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public Cargo AgenteTraerCargoPorDep(Dependencia unaDependencia, int IdAgente)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdDependencia", unaDependencia.IdDependencia),
                new SqlParameter("@IdAgente", IdAgente),
                new SqlParameter("@IdIdioma", Idioma.unIdiomaActual)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AgenteTraerCargoPorDep", parameters))
                {
                    Cargo unCargo = new Cargo();
                    unCargo = FRAMEWORK.Persistencia.Mapeador.MapearUno<Cargo>(ds);
                    return unCargo;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public void AgenteModificar(Agente unAgente)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdAgente", unAgente.IdAgente),
                new SqlParameter("@NombreAgente", unAgente.NombreAgente),
                new SqlParameter("@ApellidoAgente", unAgente.ApellidoAgente)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "AgenteModificar", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
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
