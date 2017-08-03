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
            }
            return ResRendicion;
        }





    }
}
