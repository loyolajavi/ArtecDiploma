using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARTEC.ENTIDADES;
using ARTEC.DAL;

namespace ARTEC.BLL
{
    public class BLLAgente
    {

        DALAgente GestorAgente = new DALAgente();

        //public List<Agente> AgenteTraerTodos()
        //{
        //    return GestorAgente.AgenteTraerTodos();
        //}


        public List<Agente> AgentesTraerTodos()
        {
            return GestorAgente.AgentesTraerTodos();
        }

        public int AgenteCrear(Agente NuevoAgente, int IdDep)
        {
            try
            {
                int IdAgenteNuevo = GestorAgente.AgenteCrear(NuevoAgente, IdDep);
                if (IdAgenteNuevo > 0)
                    return IdAgenteNuevo;
                return 0;
            }
            catch (Exception es)
            {
                throw;
            }
           

        }
    }
}