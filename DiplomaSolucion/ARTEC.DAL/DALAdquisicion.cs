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
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@FechaAdq", unaAdquisicion.FechaAdq),
                new SqlParameter("@FechaCompra ", unaAdquisicion.FechaCompra),
                new SqlParameter("@NroFactura", unaAdquisicion.NroFactura),
                new SqlParameter("@MontoCompra", unaAdquisicion.MontoCompra),
                new SqlParameter("@IdTipoAdquisicion", unaAdquisicion.IdTipoAdquisicion),
                //REVISAR LOS DOS
                new SqlParameter("@IdRendicion", 1),
                new SqlParameter("@IdProveedor", 1)
			};

            //REVISAR
            return 11;
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

            


    }
}
