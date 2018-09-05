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
    public class DALAsignacion
    {

        public int AsignacionCrear(Asignacion unaAsig)
        {
            DALEstadoInventario GestorEstadoInventario = new DALEstadoInventario();

            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@Fecha", unaAsig.Fecha),
                new SqlParameter("@IdDependencia", unaAsig.unaDependencia.IdDependencia)
			};

            try
            {

                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsignacionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                foreach (AsigDetalle item in unaAsig.unosAsigDetalles)
                {

                    SqlParameter[] parametersAsigDetalles = new SqlParameter[]
			        {
                        new SqlParameter("@IdAsigDetalle", item.IdAsigDetalle),
                        new SqlParameter("@IdAsignacion", IDDevuelto),
                        new SqlParameter("@IdInventario", item.unInventario.IdInventario),
                        new SqlParameter("@IdSolicitudDetalle", item.SolicDetalleAsoc.IdSolicitudDetalle),
                        new SqlParameter("@IdSolicitud", item.SolicDetalleAsoc.IdSolicitud)
                        //VER TEMA DE HARD SOFT POR LO DEL AGENTE
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "AsigDetalleCrear", parametersAsigDetalles);
                    
                    //Actualizar Estado Inventario
                    GestorEstadoInventario.InventarioEstadoUpdate(item.unInventario.IdInventario);

                    //PRUEBA DE PONER ESTO EN BLLAsignacion; SI ANDA QUITAR
                    //DALInventario GestorInventario = new DALInventario();
                    //if (item.SolicDetalleAsoc.Cantidad == GestorInventario.InventarioEntregadoPorSolicDetalle(item.SolicDetalleAsoc.IdSolicitudDetalle, item.SolicDetalleAsoc.IdSolicitud))
                    //{
                    //    DALSolicDetalle GestorSolicDetalle = new DALSolicDetalle();
                    //    //EN ESTE METODO CIERRO LA CONEXION A LA BD Y DPS EN LA SEGUNDA VUELTA DEL FOR EACH PINCHA PORQ ESTA CERRADA LA BD
                    //    GestorSolicDetalle.SolicDetalleUpdateEstado(item.SolicDetalleAsoc.IdSolicitud, item.SolicDetalleAsoc.IdSolicitudDetalle, (int)EstadoSolicDetalle.EnumEstadoSolicDetalle.Entregado);
                    //}

                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                return IDDevuelto;
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


        public List<Asignacion> AsignacionBuscar(string IdAsignacion, string NombreDependencia, string IdSolicitud)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(IdAsignacion))
                parameters.Add(new SqlParameter("@IdAsignacion", Int32.Parse(IdAsignacion)));
            if (!string.IsNullOrEmpty(NombreDependencia))
                parameters.Add(new SqlParameter("@NombreDependencia", NombreDependencia));
            if (!string.IsNullOrEmpty(IdSolicitud))
                parameters.Add(new SqlParameter("@IdSolicitud", Int32.Parse(IdSolicitud)));
     

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AsignacionBuscar", parameters.ToArray()))
                {
                    List<Asignacion> unaLis = new List<Asignacion>();
                    unaLis = MapearUnasAsignaciones(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<Asignacion> MapearUnasAsignaciones(DataSet ds)
        {
            List<Asignacion> unasAsignaciones = new List<Asignacion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Asignacion ResAsignacion = new Asignacion();
                    ResAsignacion.IdAsignacion = (int)row["IdAsignacion"];
                    ResAsignacion.Fecha = DateTime.Parse(row["Fecha"].ToString());
                    ResAsignacion.unaDependencia = new Dependencia();
                    ResAsignacion.unaDependencia.IdDependencia = (int)row["IdDependencia"];
                    ResAsignacion.unaDependencia.NombreDependencia = row["NombreDependencia"].ToString();
                    ResAsignacion.unosAsigDetalles = new List<AsigDetalle>();
                    AsigDetalle unAsigDet = new AsigDetalle();
                    unAsigDet.SolicDetalleAsoc = new SolicDetalle();
                    unAsigDet.SolicDetalleAsoc.IdSolicitud = (int)row["IdSolicitud"];
                    ResAsignacion.unosAsigDetalles.Add(unAsigDet);

                    unasAsignaciones.Add(ResAsignacion);
                }
                return unasAsignaciones;
            }

            catch (Exception es)
            {
                throw;
            }
        }




        public List<Inventario> AsignacionTraerBienesAsignados(int IdAsignacion)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdAsignacion", IdAsignacion)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AsignacionTraerBienesAsignados", parameters))
                {
                    List<Inventario> unaLis = new List<Inventario>();
                    unaLis = MapearInventario(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        private List<Inventario> MapearInventario(DataSet ds)
        {
            List<Inventario> ResInventarios = new List<Inventario>();
            Inventario uno;

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    int IdTipoAUX = (int)row["IdTipoBien"];
                    if (IdTipoAUX == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        uno = new XInventarioHard();
                    }
                    else
                    {
                        uno = new XInventarioSoft();
                    }
                    uno.IdInventario = (int)row["IdInventario"];
                    uno.IdBienEspecif = (int)row["IdBien"];
                    uno.unTipoBien = (int)row["IdTipoBien"];
                    //if (uno.TipoBien == (int)TipoBien.EnumTipoBien.Soft)
                    //{
                    //    (uno as XInventarioSoft).SerialMaster = row["SerialMaster"].ToString();
                    //}
                    //uno.unEstado = new EstadoInventario();
                    //uno.unEstado.IdEstadoInventario = (int)row["IdEstadoInventario"];
                    uno.SerieKey = row["SerieKey"].ToString();
                    //uno.PartidaDetalleAsoc = new PartidaDetalle();
                    //uno.PartidaDetalleAsoc.IdPartida = (int)row["IdPartida"];
                    //uno.PartidaDetalleAsoc.UIDPartidaDetalle = (int)row["UIDPartidaDetalle"];
                    //if (uno.TipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    //{
                    //    (uno as XInventarioHard).unDeposito = new Deposito();
                    //    (uno as XInventarioHard).unDeposito.IdDeposito = (int)row["IdDeposito"];
                    //}
                    //uno.unaAdquisicion = new Adquisicion();
                    //uno.unaAdquisicion.IdAdquisicion = (int)row["IdAdquisicion"];
                    uno.deBien = new Hardware();
                    uno.deBien.DescripBien = row["DescripCategoria"].ToString(); ;

                    ResInventarios.Add(uno);
                }

            }
            catch (Exception es)
            {
                throw;
            }
            return ResInventarios;
        }



    }
}
