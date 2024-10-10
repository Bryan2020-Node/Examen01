using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Registros_Response
    {
        public int id {  get; set; }
        public DateTime date {  get; set; }
        public string? name {  get; set; }
        public decimal sales {  get; set; }
        public decimal expenses {  get; set; }
        public decimal utility {  get; set; }
    }

    public class Registros_Request
    {
        public int ids { get; set; }
    }
}
