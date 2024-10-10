using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class NuevoLogica
    {
        conexionApi conexion = new conexionApi();

        public bool NuevoDato(string id, DateTime fecha)
        {
            bool respuesta = conexion.nuevoRegistro(id, fecha);
            if (respuesta) return true;
            
            return false;
        }
    }
}
