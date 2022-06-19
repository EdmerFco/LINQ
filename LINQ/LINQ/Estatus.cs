using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Estatus
    {
        public Estatus(int Id, string Nombre)
        {
            id = Id;
            nombre = Nombre;
        }
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
