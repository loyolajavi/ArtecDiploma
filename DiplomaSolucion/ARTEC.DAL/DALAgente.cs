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

        public int AgenteCrear(Agente NuevoAgente, int IdDep)
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
                return IDDevuelto;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                //VER: Guardar en bitacora de eventos
                return 0;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }
    }
}
