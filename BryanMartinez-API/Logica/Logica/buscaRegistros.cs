using Datos;
using Logica.interfaz;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica
{
    public class buscaRegistros : ISucursal
    {
        public Registros_Response NuevoDato(string id, DateTime fecha)
        {
            conexion con = new conexion();
            Registros_Response respuesta = con.NuevoDato(id, fecha);
            return respuesta;
        }

        public List<Registros_Response> ObtenerDatos(string request)
        {
            conexion con = new conexion();
            List<Registros_Response> datos = new List<Registros_Response>();
            DataTable dt = con.ObtenerDatos(request);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Registros_Response conjuntoDatos = new Registros_Response
                    {
                        id = (int)item["id"],
                        date = (DateTime)item["fecha"],
                        name = item["nombre"].ToString(),
                        sales = (decimal)item["sales"],
                        expenses = (decimal)item["expenses"],
                        utility = (decimal)item["utility"],
                    };
                    datos.Add(conjuntoDatos);
                }
            }
            return datos;
        }
    }
}
