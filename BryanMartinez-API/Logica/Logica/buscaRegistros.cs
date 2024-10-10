using Datos;
using Logica.interfaz;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class buscaRegistros : ISucursal
    {
        public Registros_Response consultaRegistros(string id, DateTime fecha)
        {
            conexion con = new conexion();
            Registros_Response respuesta = con.consultaRegistros(id, fecha);
            return respuesta;
        }
    }
}
