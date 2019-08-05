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
    public class DALRendicion
    {

        public Rendicion AdquisicionesConBienesPorIdPartida(int NroPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", NroPartida)
            };

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "AdquisicionesConBienesPorIdPartida", parameters))
                {
                    Rendicion unaRendicion = new Rendicion();
                    unaRendicion = MapearRendicion(ds);
                    return unaRendicion;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }



        public int RendicionTraerIdRendPorIdPartida(int IdPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdPartida", IdPartida)
            };

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int? Res = (int?)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RendicionTraerIdRendPorIdPartida", parameters);
                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (Res != null)
                    return (int)Res;
                return 0;
            }
            catch (Exception es)
            {
                FRAMEWORK.Persistencia.MotorBD.TransaccionCancelar();
                return -1;
                throw;
            }
            finally
            {
                if (FRAMEWORK.Persistencia.MotorBD.ConexionGetEstado())
                    FRAMEWORK.Persistencia.MotorBD.ConexionFinalizar();
            }
        }



        public int RendicionCrear(Rendicion unaRendicion, Partida unaPartida)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaRen", unaRendicion.FechaRen),
                new SqlParameter("@IdPartida", unaRendicion.unaPartida.IdPartida),
                new SqlParameter("@MontoGasto", unaRendicion.MontoGasto)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                var Resultado = (decimal)FRAMEWORK.Persistencia.MotorBD.EjecutarScalar(CommandType.StoredProcedure, "RendicionCrear", parameters);
                int IDDevuelto = Decimal.ToInt32(Resultado);

                //Colocar en estado Rendida a todos los detalles
                foreach (PartidaDetalle unaParDet in unaPartida.unasPartidasDetalles)
                {
                    SqlParameter[] parametersDetSolicRendido = new SqlParameter[]
			        {
                        new SqlParameter("@UIDSolicDetalle", unaParDet.SolicDetalleAsociado.UIDSolicDetalle),
                        new SqlParameter("@NuevoEstado", EstadoSolicDetalle.EnumEstadoSolicDetalle.Rendido)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetallePorUIDUpdateEstado", parametersDetSolicRendido);
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



        public void RendicionModificar(Rendicion unaRendicion)
        {
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@IdRendicion", unaRendicion.IdRendicion),
                new SqlParameter("@FechaRen", unaRendicion.FechaRen),
                new SqlParameter("@IdPartida", unaRendicion.unaPartida.IdPartida),
                new SqlParameter("@MontoGasto", unaRendicion.MontoGasto)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RendicionModificar", parameters);
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



        public static Rendicion MapearRendicion(DataSet ds)
        {
            Rendicion ResRendicion = new Rendicion();
            Bien unBien;

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Adquisicion unaAdq = new Adquisicion();
                    unaAdq.IdAdquisicion = (int)row["IdAdquisicion"];
                    unaAdq.NroFactura = row["NroFactura"].ToString();

                    TipoBien unTipoBienAux = new TipoBien();
                    DALTipoBien GestorTipoBien = new DALTipoBien();
                    unTipoBienAux = GestorTipoBien.TipoBienTraerTipoBienPorIdCategoria((int)row["IdCategoria"]);
                    if (unTipoBienAux.IdTipoBien == (int)TipoBien.EnumTipoBien.Hard)
                    {
                        unBien = new Hardware();
                        unBien.unInventarioAlta = new XInventarioHard();
                    }
                    else
                    {
                        unBien = new Software();
                        unBien.unInventarioAlta = new XInventarioSoft();
                    }
                    unBien.unaCategoria = new Categoria();
                    unBien.unaCategoria.DescripCategoria = row["DescripCategoria"].ToString();
                    unBien.unInventarioAlta.SerieKey = row["SerieKey"].ToString();
                    unBien.unInventarioAlta.Costo = (decimal)row["Costo"];
                    
                    unaAdq.BienesInventarioAsociados.Add(unBien);

                    ResRendicion.unasAdquisiciones.Add(unaAdq);
                }
            }

            catch (Exception es)
            {
                throw;
            }
            return ResRendicion;
        }






        public List<Rendicion> RendicionBuscar(string IdRendicion, string IdPartida, string IdSolicitud, string NombreDependencia)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(IdRendicion))
                parameters.Add(new SqlParameter("@IdRendicion", Int32.Parse(IdRendicion)));
            if (!string.IsNullOrEmpty(IdPartida))
                parameters.Add(new SqlParameter("@IdPartida", Int32.Parse(IdPartida)));
            if (!string.IsNullOrEmpty(IdSolicitud))
                parameters.Add(new SqlParameter("@IdSolicitud", Int32.Parse(IdSolicitud)));
            if (!string.IsNullOrEmpty(NombreDependencia))
                parameters.Add(new SqlParameter("@NombreDependencia", NombreDependencia));

            try
            {
                using (DataSet ds = FRAMEWORK.Persistencia.MotorBD.EjecutarDataSet(CommandType.StoredProcedure, "RendicionBuscar", parameters.ToArray()))
                {
                    List<Rendicion> unaLis = new List<Rendicion>();
                    unaLis = MapearUnasRendiciones(ds);
                    return unaLis;
                }
            }
            catch (Exception es)
            {
                throw;
            }
        }


        public static List<Rendicion> MapearUnasRendiciones(DataSet ds)
        {
            List<Rendicion> unasRendiciones = new List<Rendicion>();

            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Rendicion ResRendicion = new Rendicion();
                    ResRendicion.IdRendicion = (int)row["IdRendicion"];
                    ResRendicion.unaPartida = new Partida();
                    ResRendicion.unaPartida.IdPartida = (int)row["IdPartida"];
                    ResRendicion.MontoGasto = (decimal)row["MontoGasto"];
                    ResRendicion.FechaRen = DateTime.Parse(row["FechaRen"].ToString());

                    unasRendiciones.Add(ResRendicion);
                }
                return unasRendiciones;
            }

            catch (Exception es)
            {
                throw;
            }
        }




        public void RendicionEliminar(int IdRendicion, Partida unaPartida)
        {
            SqlParameter[] parametersRenEliminar = new SqlParameter[]
			{
                new SqlParameter("@IdRendicion", IdRendicion)
			};

            try
            {
                FRAMEWORK.Persistencia.MotorBD.ConexionIniciar();
                FRAMEWORK.Persistencia.MotorBD.TransaccionIniciar();
                int FilasAfectadas = FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "RendicionEliminar", parametersRenEliminar);

                //Colocar en estado Adquirido a todos los detalles (Revierte el estado)
                foreach (PartidaDetalle unaParDet in unaPartida.unasPartidasDetalles)
                {
                    SqlParameter[] parametersDetSolicRendido = new SqlParameter[]
			        {
                        new SqlParameter("@UIDSolicDetalle", unaParDet.SolicDetalleAsociado.UIDSolicDetalle),
                        new SqlParameter("@NuevoEstado", EstadoSolicDetalle.EnumEstadoSolicDetalle.Adquirido)
			        };

                    FRAMEWORK.Persistencia.MotorBD.EjecutarNonQuery(CommandType.StoredProcedure, "SolicDetallePorUIDUpdateEstado", parametersDetSolicRendido);
                }

                FRAMEWORK.Persistencia.MotorBD.TransaccionAceptar();
                if (FilasAfectadas == 0)
                    throw new Exception();
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
