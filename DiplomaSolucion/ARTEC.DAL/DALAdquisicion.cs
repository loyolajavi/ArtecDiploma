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

        public void AdquisicionCrear(Adquisicion unaAdquisicion)
        {

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
