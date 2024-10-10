using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Datos
{
    public class conexion
    {
        private SqlConnection conexionBd = new SqlConnection("Data Source=MSI\\MSI;Initial Catalog=Examen1;User ID=sa;Password=bryan123");

        private string urlAPI = "http://aphmx442916.azurewebsites.net/sales/data/";

        static HttpClient client = new HttpClient();
        public Registros_Response NuevoDato(string id, DateTime fecha)
        {
            Registros_Response lista = new Registros_Response();
            //List<Registros_Response> listas = new List<Registros_Response>();
            var url = $"http://aphmx442916.azurewebsites.net/sales/data/{id}/{fecha.ToString("yyyy-MM-dd")}";
            //var url = $"http://aphmx442916.azurewebsites.net/sales/data/619/2015-06-12";
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
                            dynamic obj = JsonConvert.DeserializeObject(responseBody);



                            //Registros_Response datos = obj.value.ToObject(typeof(Registros_Response));
                            //listas = obj.value.ToObject(typeof(List<Registros_Response>));

                            //Registros_Response lista = new Registros_Response
                            //{

                            //}

                            Registros_Response registros = JsonConvert.DeserializeObject<Registros_Response>(responseBody);
                            RegistrarEnBd(registros);
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

        public bool RegistrarEnBd(Registros_Response response)
        {
            SqlCommand cmd = new SqlCommand("SP_CatpuraDatosAPI", conexionBd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = response.id;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = response.date;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = response.name;
            cmd.Parameters.Add("@sales", SqlDbType.Decimal).Value = response.sales;
            cmd.Parameters.Add("@expenses", SqlDbType.Decimal).Value = response.expenses;
            cmd.Parameters.Add("@utiliy", SqlDbType.Decimal).Value = response.sales - response.expenses;
            conexionBd.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conexionBd.Close();
                return true;

            }
            else
            {
                conexionBd.Close();
                return false;
            }
            
        }

        public DataTable ObtenerDatos(string request)
        {
            SqlCommand cmd = new SqlCommand("SP_ListaRegistros", conexionBd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sucursales", SqlDbType.NVarChar).Value = request;
            conexionBd.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            conexionBd.Close();
            return dataTable;
        }

    }
}
