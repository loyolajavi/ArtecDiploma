using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.BLL.Servicios
{
    public abstract class IObservable
    {
        private static List<IObservador> _Observadores = new List<IObservador>();

        public static void AgregarObservador(IObservador unObservador)
        {
            _Observadores.Add(unObservador);
        }

        public static void QuitarObservador(IObservador unObservador)
        {
            _Observadores.Remove(unObservador);
        }

        public static void ActualizarEstadoObservadores()
        {
            foreach (IObservador unObservador in _Observadores)
            {
                unObservador.Traducirme();
            }
        }

    }
}
