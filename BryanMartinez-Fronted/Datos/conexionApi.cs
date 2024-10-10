using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class conexionApi
    {
        public bool nuevoRegistro(string id, DateTime fecha)
        {
            Registrar_Response lista = new Registrar_Response();
            
            var url = $"https://localhost:7039/api/Examen/NuevoRegistros/{id}/{fecha.ToString("yyyy-MM-dd")}";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return false;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                            dynamic obj = JsonConvert.DeserializeObject(responseBody);


                            Registrar_Response registros = JsonConvert.DeserializeObject<Registrar_Response>(responseBody);
                            if (registros.ok)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                return false;
            }
        }


        public List<ListResults_Response> ListaRegistros(string ids)
        {
            List<ListResults_Response> lista = new List<ListResults_Response>();

            var url = $"https://localhost:7039/api/Examen/ObtenerRegistrosId/{ids}";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return lista;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            //Console.WriteLine(responseBody);
                            //dynamic obj = JsonConvert.DeserializeObject(responseBody);


                            DatosList_Response registros = JsonConvert.DeserializeObject<DatosList_Response>(responseBody);
                            lista = registros.results;
                            return lista;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                return lista;
            }
        }
    }
}
