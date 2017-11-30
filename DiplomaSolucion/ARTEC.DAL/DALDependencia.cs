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
				new SqlParameter("@IdDependencia", idDependencia)
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
				new SqlParameter("@IdDependencia", idDependencia)
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



    }
}
