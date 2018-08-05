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
    public class DALDependencia
    {


        public List<Dependencia> TraerTodos()
        {
            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerTodos"))
            {
                List<Dependencia> unaLista = new List<Dependencia>();
                unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Dependencia>(ds);

                foreach (Dependencia Dep in unaLista)
                {
                    DALTipoDependencia GestorTipoDep = new DALTipoDependencia();
                    Dep.unTipoDep = GestorTipoDep.TipoDependenciaTraerPorDependencia(Dep.IdDependencia);
                }


                return unaLista;
            }
        }


        public List<Agente> TraerAgentesDependencia(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia),
                new SqlParameter("@IdIdioma", Idioma.unIdiomaActual)
			};


            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerAgentesPorIdDependencia", parameters))
            {
                List<Agente> unaLista = new List<Agente>();
                //unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Agente>(ds); ANTIGUO
                unaLista = MapearAgentes(ds);
                return unaLista;
            }
        }



        public static List<Agente> MapearAgentes(DataSet ds)
        {
            List<Agente> Res = new List<Agente>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Agente unAgente = new Agente();

                    unAgente.IdAgente = (int)row["IdAgente"];
                    unAgente.NombreAgente = row["NombreAgente"].ToString();
                    unAgente.ApellidoAgente = row["ApellidoAgente"].ToString();
                    unAgente.unCargo = new Cargo();
                    unAgente.unCargo.IdCargo = (int)row["IdCargo"];
                    unAgente.unCargo.DescripCargo = row["DescripCargo"].ToString();


                    Res.Add(unAgente);
                }
                return Res;
            }
            catch (Exception es)
            {
                throw;
                //MANEJAR EXC
            }
        }



        public List<Agente> TraerAgentesResp(int idDependencia)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDependencia", idDependencia),
                new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)

			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerAgentesResp", parameters))
            {
                List<Agente> unaLista = new List<Agente>();
                //unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Agente>(ds); ANTIGUO
                unaLista = MapearAgentes(ds);
                return unaLista;
            }
        }


        public List<Dependencia> DependenciaTraerNombrePorIDSolicitud(int IdSolicitud)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSolicitud", IdSolicitud)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaTraerNombrePorIDSolicitud", parameters))
            {
                List<Dependencia> unaDep = MapeadorPunteroDependencia(ds);
                if (unaDep.Count > 0)
                    return unaDep;
                else
                    unaDep = null;
                return unaDep;
            }
        }


        private List<Dependencia> MapeadorPunteroDependencia(DataSet ds)
        {

            List<Dependencia> LisLocalDep = new List<Dependencia>();

            //switch (ds.Tables[0].Rows[0].ItemArray.Count())
            //{
            //    case 1:
            //        LisLocalDep = MapearDependenciaNombre(ds);
            //        break;
            //    case 2:
            //        System.Windows.Forms.MessageBox.Show("Hay dos");
            //        break;
            //    case 3:
            //        System.Windows.Forms.MessageBox.Show("Hay tres");
            //        break;
            //}
            //return LisLocalDep;
            try
            {


                switch (ds.Tables[0].Rows[0].ItemArray.Count())
                {
                    case 1:
                        return MapearDependenciaNombre(ds);
                    case 2:
                        System.Windows.Forms.MessageBox.Show("Hay dos");
                        break;
                    case 3:
                        System.Windows.Forms.MessageBox.Show("Hay tres");
                        break;
                }
                return new List<Dependencia>();
            }
            catch (Exception)
            {
                //VER: AGREGAR MANEJO
                throw;
            }

        }



        private List<Dependencia> MapearDependenciaNombre(DataSet ds)
        {
            List<Dependencia> ListaDependencia = new List<Dependencia>();

            try
            {
                Dependencia unaDep = new Dependencia();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    unaDep.NombreDependencia = row["NombreDependencia"].ToString();
                    //foreach (DataColumn item in row.Table.Columns)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(item.ColumnName);
                    //}
                    ListaDependencia.Add(unaDep);
                }
                return ListaDependencia;
            }
            catch (Exception es)
            {
                throw;
                //MANEJAR EXC
            }
        }




        public List<TipoDependencia> TipoDepTraerTodos()
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIdioma", ENTIDADES.Servicios.Idioma.unIdiomaActual)
			};

            using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "TipoDepTraerTodos", parameters))
            {
                List<TipoDependencia> unaLista = new List<TipoDependencia>();
                unaLista = MapearTipoDep(ds);
                return unaLista;
            }
        }

        private List<TipoDependencia> MapearTipoDep(DataSet ds)
        {
            List<TipoDependencia> Res = new List<TipoDependencia>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    TipoDependencia unTipoDep = new TipoDependencia();

                    unTipoDep.IdTipoDependencia = (int)row["IdTipoDependencia"];
                    unTipoDep.DescripTipoDependencia = row["DescripTipoDependencia"].ToString();
                    Res.Add(unTipoDep);
                }
                return Res;
            }
            catch (Exception es)
            {
                throw;
                //MANEJAR EXC
            }
        }



        public void DependenciaModifTipoDep(int IdDep, TipoDependencia TipoDep)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdDependencia", IdDep),
                new SqlParameter("@IdTipoDependencia", TipoDep.IdTipoDependencia)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DependenciaModifTipoDep", parameters);
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

        public void DependenciaAgenteAgregar(List<Agente> AgentesNuevos, int IdDep)
        {
            foreach (Agente unAgente in AgentesNuevos)
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@IdAgente", unAgente.IdAgente),
                    new SqlParameter("@IdCargo", unAgente.unCargo.IdCargo),
                    new SqlParameter("@IdDependencia", IdDep)
			    };
                try
                {
                    FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                    FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DependenciaAgenteAgregar", parameters);
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


        public void DependenciaModifNombre(string NombreDep, int IdDep)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdDependencia", IdDep),
                new SqlParameter("@NombreDependencia", NombreDep)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DependenciaModifNombre", parameters);
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

        public void DependenciaAgentesQuitarLista(List<int> AgentesAQuitar, int IdDep)
        {
            foreach (int unAgenteID in AgentesAQuitar)
            {
                SqlParameter[] parameters = new SqlParameter[]
			    {
                    new SqlParameter("@IdAgente", unAgenteID),
                    new SqlParameter("@IdDependencia", IdDep)
			    };
                try
                {
                    FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                    FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DependenciaAgentesQuitarLista", parameters);
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

        public Dependencia DependenciaBuscar(string NomDependencia)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NomDependencia", NomDependencia)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "DependenciaBuscar", parameters))
                {
                    Dependencia unaDep = new Dependencia();
                    unaDep = FRAMEWORK.Persistencia.Mapeador.MapearUno<Dependencia>(ds);
                    return unaDep;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public bool DependenciaCrear(Dependencia nuevaDependencia)
        {
            SqlParameter[] parametersDepCrear = new SqlParameter[]
			{
                new SqlParameter("@NombreDependencia", nuevaDependencia.NombreDependencia),
                new SqlParameter("@IdTipoDependencia", nuevaDependencia.unTipoDep.IdTipoDependencia)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "DependenciaCrear", parametersDepCrear);
                int IdDepRes = Decimal.ToInt32(Resultado);
                nuevaDependencia.IdDependencia = IdDepRes;

                if (nuevaDependencia.unosAgentes != null && nuevaDependencia.unosAgentes.Count > 0)
                {
                    foreach (Agente unAgente in nuevaDependencia.unosAgentes)
                    {
                        SqlParameter[] parametersAgente = new SqlParameter[]
			            {
                            new SqlParameter("@IdAgente", unAgente.IdAgente),
                            new SqlParameter("@IdCargo", unAgente.unCargo.IdCargo),
                            new SqlParameter("@IdDependencia", nuevaDependencia.IdDependencia)
			            };

                        FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "DependenciaAgenteAgregar", parametersAgente);
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
