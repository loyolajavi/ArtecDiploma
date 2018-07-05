using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARTEC.ENTIDADES.Servicios
{
    public interface IFamPat
    {

        int IdIFamPat { get; set; }
        string NombreIFamPat { get; set; }

        void Agregar(IFamPat ElementoFamPat);
        void Quitar(IFamPat ElementoFamPat);

        int CantHijos { get; }

    }
}
