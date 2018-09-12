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
    public class DALAdquisicion
    {

        public int AdquisicionCrear(Adquisicion unaAdquisicion)
        {
            SqlParameter[] parametersAdq = new SqlParameter[]
			{
                new SqlParameter("@FechaAdq", unaAdquisicion.FechaAdq),
                new SqlParameter("@FechaCompra", unaAdquisicion.FechaCompra),
                new SqlParameter("@NroFactura", unaAdquisicion.NroFactura),
                new SqlParameter("@MontoCompra", unaAdquisicion.MontoCompra),
                new SqlParameter("@IdProveedor", unaAdquisicion.ProveedorAdquisicion.IdProveedor)
			};

            try
            {
                //SAQUE LO DE TRANSACCIOENS PORQUE LO HAGO EN LA BLL de Adquisición TODO LO QUE IMPLICA CREAR LA ADQUISICION Y LOS INVENTARIOS
                //FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                //FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AdquisicionCrear", parametersAdq);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
            }
            catch (Exception es)
            {
                //FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                throw;
            }
            //finally
            //{
            //    //FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            //}


        }

        public void ComenzarAdquisicion()
        {
            FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
            FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
        }

        public void ConfirmarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
        }
            

        public void CancelarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
        }

        public void TerminarAdquisicion(){
            FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
        }





        public List<Adquisicion> AdquisicionBuscar(string IdAdquisicion, string IdPartida, string NombreDependencia, DateTime? unaFecha, DateTime? unaFechaCompra, string NroFactura, string IdSolicitud)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(IdAdquisicion))
                parameters.Add(new SqlParameter("@IdAdquisicion", Int32.Parse(IdAdquisicion)));
            if (!string.IsNullOrEmpty(IdPartida))
                parameters.Add(new SqlParameter("@IdPartida", Int32.Parse(IdPartida)));
            if (!string.IsNullOrEmpty(NombreDependencia))
                parameters.Add(new SqlParameter("@NombreDependencia", NombreDependencia));
            if (unaFecha != DateTime.MinValue)
                parameters.Add(new SqlParameter("@unaFecha", unaFecha));
            if (unaFechaCompra != DateTime.MinValue)
                parameters.Add(new SqlParameter("@unaFechaCompra", unaFechaCompra));
            if (!string.IsNullOrEmpty(NroFactura))
                parameters.Add(new SqlParameter("@NroFactura", NroFactura));
            if (!string.IsNullOrEmpty(IdSolicitud))
                parameters.Add(new SqlParameter("@IdSolicitud", Int32.Parse(IdSolicitud)));
            
            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AdquisicionBuscar", parameters.ToArray()))
                {
                    List<Adquisicion> unaLis = new List<Adquisicion>();
                    unaLis = MapearUnasAdquisiciones(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public static List<Adquisicion> MapearUnasAdquisiciones(DataSet ds)
        {
            List<Adquisicion> unasAdquisiciones = new List<Adquisicion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Adquisicion ResAdquisicion = new Adquisicion();
                    ResAdquisicion.IdAdquisicion = (int)row["IdAdquisicion"];
                    ResAdquisicion.FechaAdq = DateTime.Parse(row["FechaAdq"].ToString());
                    ResAdquisicion.FechaCompra = DateTime.Parse(row["FechaCompra"].ToString());
                    ResAdquisicion.NroFactura = row["NroFactura"].ToString();
                    ResAdquisicion.MontoCompra = (decimal)row["MontoCompra"];
                    ResAdquisicion.ProveedorAdquisicion = new Proveedor();
                    ResAdquisicion.ProveedorAdquisicion.IdProveedor = (int)row["IdProveedor"];
                    ResAdquisicion.ProveedorAdquisicion.AliasProv = row["AliasProv"].ToString();
                    ResAdquisicion.unaDependencia = new Dependencia();
                    ResAdquisicion.unaDependencia.IdDependencia = (int)row["IdDependencia"];
                    ResAdquisicion.unaDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    ResAdquisicion.unIdPartida = (int)row["IdPartida"];
                    ResAdquisicion.unIdSolicitud = (int)row["IdSolicitud"];

                    unasAdquisiciones.Add(ResAdquisicion);
                }
                return unasAdquisiciones;
            }

            catch (Exception es)
            {
                throw;
            }
        }
    }
}
