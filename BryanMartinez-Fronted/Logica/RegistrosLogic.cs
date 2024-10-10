using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class RegistrosLogic
    {
        conexionApi conexion = new conexionApi();

        public List<ListResults_Response> ListaRegistros(string ids)
        {
            List<ListResults_Response> respuesta = conexion.ListaRegistros(ids);
            return respuesta;
        }
    }
}
