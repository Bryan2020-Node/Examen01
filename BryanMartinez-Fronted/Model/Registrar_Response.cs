using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Registrar_Response
    {
        public bool ok { get; set; }
    }


    public class DatosList_Response
    {
        public bool ok { get; set; }
        public List<ListResults_Response> results { get; set; }
       
    }

    public class ListResults_Response
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public decimal sales { get; set; }
        public decimal expenses { get; set; }
        public decimal utility { get; set; }
    }
}
