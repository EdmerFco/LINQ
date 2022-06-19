using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Estado
    {
        public Estado(int Id, string Nombre)
        {
            this.id = Id;
            //this.clave = Clave;
            this.nombre = Nombre;
        }
        public int id { get; set; }
        ///public string clave { get; set; }
        public string nombre { get; set; }
    }
}
