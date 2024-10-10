using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.interfaz
{
    public interface ISucursal
    {
        Registros_Response consultaRegistros(string id, DateTime fecha);
    }
}
