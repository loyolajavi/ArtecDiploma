using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.FRAMEWORK;
using ARTEC.FRAMEWORK.Servicios;
using ARTEC.ENTIDADES.Servicios;

namespace ARTEC.DAL
{
    public class DALUsuario
    {

        public List<Usuario> UsuarioTraerTodos()
        {
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerTodos"))
                {
                    List<Usuario> unaLista = new List<Usuario>();
                    unaLista = FRAMEWORK.Persistencia.Mapeador.Mapear<Usuario>(ds);
                    return unaLista;
                }
            }
            catch (Exception es)
            {
                throw;
            }

        }


        public bool UsuarioTraerPorLogin(string NomUs, string PassHash)
        {

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Us", NomUs),
                new SqlParameter("@Pass", PassHash)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerPorLogin", parameters))
                {
                    FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado = FRAMEWORK.Persistencia.Mapeador.MapearUno<Usuario>(ds);
                    if (!string.IsNullOrEmpty(FRAMEWORK.Servicios.ServicioLogin.GetLoginUnico().UsuarioLogueado.NombreUsuario))
                    {
                        return true;
                    }
                }
            }
            catch (Exception es)
            {
                    //System.Windows.Forms.MessageBox.Show("Log de excepción en BD");
                    //System.Windows.Forms.MessageBox.Show(es.StackTrace);
                    throw;
            }
            return false;

        }



        public List<IFamPat> UsuarioTraerPermisos(int IdUsuario)
        {

            List<IFamPat> unosPermisos = new List<IFamPat>();

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario)
			};
            SqlParameter[] parameters2 = new SqlParameter[]
			{
                new SqlParameter("@IdUsuario", IdUsuario)
			};

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerFamilias", parameters))
                {
                    IFamPat SubPermiso;
                    List<IFamPat> unasFamilias = new List<IFamPat>();
                    unasFamilias = MapearFamilias(ds);

                    //foreach (IFamPat unaFamilia in unasFamilias)
                    //{
                    //    //SubPermiso = FamiliaTraerSubPermisos(unaFamilia.IdIFamPat);
                    //    unosPermisos.Add(SubPermiso);
                    //}


                    if (unasFamilias != null && unasFamilias.Count() > 0)
                        unosPermisos.AddRange(unasFamilias);
                }

                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "UsuarioTraerPatentes", parameters2))
                {
                    List<IFamPat> unasPatentes = new List<IFamPat>();
                    unasPatentes = MapearPatentes(ds);
                    if (unosPermisos != null && unosPermisos.Count() > 0)
                        unosPermisos.AddRange(unasPatentes);
                }

                return unosPermisos;
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<IFamPat> MapearFamilias(DataSet ds)
        {
            List<IFamPat> ResElementosFamPat = new List<IFamPat>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IFamPat unaFamilia = new Familia();
                    unaFamilia.IdIFamPat = (int)row["IdFamilia"];
                    unaFamilia.NombreIFamPat = row["NombreFamilia"].ToString();
                    ResElementosFamPat.Add(unaFamilia);
                }
                return ResElementosFamPat;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static List<IFamPat> MapearPatentes(DataSet ds)
        {
            List<IFamPat> ResElementosFamPat = new List<IFamPat>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    IFamPat unaPatente = new Patente();
                    unaPatente.IdIFamPat = (int)row["IdPatente"];
                    unaPatente.NombreIFamPat = row["NombrePatente"].ToString();
                    ResElementosFamPat.Add(unaPatente);
                }
                return ResElementosFamPat;
            }
            catch (Exception es)
            {
                throw;
            }
        }


    }
}
