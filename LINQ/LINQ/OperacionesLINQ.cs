using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LINQ
{
    public class OperacionesLINQ
    {
        static List<Alumno> _alumnoes = new List<Alumno>();
        static List<Estado> _estados = new List<Estado>();
        static List<Estatus> _estatus = new List<Estatus>();
        static List<ItemISR> _TablaISR = new List<ItemISR>();
        public static void CargarLists()

        {

            Console.WriteLine("Alumns de Tich");
            Console.WriteLine("Coloca la direccion del _archivo que deses leer recuerda que tiene que ser Txt");
            string nombre = @"C:\Users\pacoh\Documents\TICH\Semana 2\json\Alumnos.json";
            string lienea;
            StreamReader _archivo = new StreamReader(nombre);
            lienea = _archivo.ReadToEnd();
            _archivo.Close();

            _alumnoes = JsonConvert.DeserializeObject<List<Alumno>>(lienea);
            //alumnoes.Add(alumnoes);

            /*foreach (Alumno alumno in _alumnoes)
            {
                Console.WriteLine(alumno.nombre);
            }*/

            Console.WriteLine("Lista de Estados de los alumnos");

            _archivo = new StreamReader(@"C:\Users\pacoh\Documents\TICH\Semana 2\json\Estados.json");
            lienea = _archivo.ReadToEnd();
            _archivo.Close();

            _estados = JsonConvert.DeserializeObject<List<Estado>>(lienea);

           /* foreach (Estado estado in _estados)
            {
                Console.WriteLine($"Id: {estado.id}, nombre {estado.nombre}");
            }*/

            //Console.WriteLine("Lista de Estatus de alumnos ");

            _archivo = new StreamReader(@"C:\Users\pacoh\Documents\TICH\Semana 2\json\Estatus.json");
            lienea = _archivo.ReadToEnd();
            _archivo.Close();
            _estatus = JsonConvert.DeserializeObject<List<Estatus>>(lienea);

          /*  foreach (Estatus est in _estatus)
            {
                Console.WriteLine(est.nombre);
            }*/

          _archivo = new StreamReader(@"C:\Users\pacoh\Documents\TICH\Semana 2\30-05-2022\TablaISR.csv");
            
            while(!_archivo.EndOfStream)
            {
              string recorre =  _archivo.ReadLine();
              string[] lineas = recorre.Split(',');
             
                ItemISR  itemISR = new ItemISR();
                
                itemISR.limInf = decimal.Parse(lineas[0]);
                itemISR.limSup= decimal.Parse(lineas[1]);
                itemISR.cuotaFija = decimal.Parse(lineas[2]);
                itemISR.porExced = decimal.Parse(lineas[3]);
                itemISR.subsidio = decimal.Parse(lineas[4]);

                _TablaISR.Add(itemISR);
               
            }
            _archivo.Close();
 
          /* foreach(var tab in _TablaISR)
            {
                int i = 1;
                Console.WriteLine($"{i} {tab.cuotaFija}");
                i++;
            }*/
        }
      public static void Consultas()
        {

       /* Estado estado = _estados.First(x => x.id == 5);
        Console.WriteLine($"El es tado que tiene el {estado.id} es {estado.nombre}");*/
       //7.2.1.1.
         var oEstados = 
                from estado in _estados
                where estado.id == 5
                select estado;
            foreach(var oEstado in oEstados)
            {
                Console.WriteLine($"El estado con el {oEstado.id}, es {oEstado.nombre}");
            }

            ////////////////////////////////////////////////////////////////// 
           //7.2.1.2.
           var alumnosE = 
                from alum in _alumnoes 
                where alum.idEstado == 29 || alum.idEstado == 13
                orderby alum.nombre
                select alum;
            foreach(var alum in alumnosE)
            {
                Console.WriteLine($"Los Alumnos son {alum.nombre}");
            }

          /////////////////////////////////////////////////////////////
          //7.2.1.3.
            var alumnosEE = 
                from alum in _alumnoes
                where (alum.idEstado == 19 || alum.idEstado == 20) && (alum.idEstatus == 4 || alum.idEstatus == 5)
                select alum;
            foreach(var alum in alumnosEE)
            {
                Console.WriteLine($"alumnos que son IdEstado 19 y 20 y además de que estén en el estatus 4 o 5 son: { alum.nombre}");

            }
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");

            ////////////////////////////////////////////////////////
            //7.2.1.4.
            var alumnosC = 
                from alum in _alumnoes
                where alum.calificacion >= 6
                orderby alum.calificacion
                select alum;

            foreach(var alum in alumnosC)
            Console.WriteLine($"Alumnos con calificacion aprovatoria (6 para arriva) nombre:{alum.nombre}  calificacion: {alum.calificacion}");

            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
            ///////////////////////////////////////////////////
            //7.2.1.5.
            var alumnosP =
                (from alum in _alumnoes
                select alum.calificacion).Average();
            Console.WriteLine($"calificación promedio de los alumnos {alumnosP}");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");

            /////////////////////////////////////////////////
            ///7.2.1.6. 
            ///

            bool califi10 = _alumnoes.Any(alum => alum.calificacion == 10 );

            if (califi10)
            {
               // Console.WriteLine("fue falsa");
                _alumnoes.Any(alumno =>  alumno.calificacion > 6 || _alumnoes.Any(al =>  al.calificacion < 7));
                
                var alum =
                    from alumno in _alumnoes
                    select alumno;

                foreach( var al in alum)
                {
                    al.calificacion += 2;
                }

               // _alumnoes = alum;
            }
            else
            {
               
                 var alum =
                    from alumno in _alumnoes
                    select alumno;

                foreach( var al in alum)
                {
                    al.calificacion += 1;                                 
                }
                 // _alumnoes = alum;
            }



           /* foreach(var alum in _alumnoes)
            {
                Console.WriteLine($"{alum.nombre} {alum.calificacion}");
            }*/

            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
            ///////////////////////////////////////////////
            ///7.2.1.7.

            //////////////////////////////////////////////
            ///7.2.1.8.
            var alumnosE2 =
                from alum in _alumnoes
                join  est in _estatus on alum.idEstatus equals est.id
                where est.id == 3
                orderby alum.nombre
                select new {idAlumno = alum.id,  nombreAlumno = alum.nombre, nombreEstado = est.nombre };

            foreach(var alum in alumnosE2)
            {
                Console.WriteLine($"Id alumno: {alum.idAlumno} nombre {alum.nombreAlumno} estatus: {alum.nombreEstado}");
            }
            
          Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////");
            /*foreach(var alum in _alumnoes)
            {
                Console.WriteLine($"{alum.nombre}, {alum.idEstatus}");
            }*/

            //////////////////////////////////////////////
            //7.2.1.9.
              var alumnosEstatusMayorA2 = 
                from alm in _alumnoes
                join _estatus in _estatus
                on alm.idEstatus equals _estatus.id
                join _estado in _estados
                on alm.idEstatus equals _estado.id
                where alm.idEstatus > 2
                orderby _estatus.nombre
                select new
                 {
                  idAlumno = alm.id,
                  nombreAlumno = alm.nombre,
                  nombreEstado = _estado.nombre,
                  nombreEstatus = _estatus.nombre
                  };
          //  var respuestaAlumnos = alumnosEstatusMayorA2.ToArray()[0];
          foreach(var respuestaAlumnos in alumnosEstatusMayorA2)
            {
             Console.WriteLine($"IdAlumno: {respuestaAlumnos.idAlumno}, " +
             $"nombre: {respuestaAlumnos.nombreAlumno}, " +
             $"estado: {respuestaAlumnos.nombreEstado}, " +
             $"estatus: {respuestaAlumnos.nombreEstatus}" );
            }
            /////////////////////////////////////////////
            ///7.2.1.10.
          Console.WriteLine(" sueldo mensual");
          decimal sueldoM = decimal.Parse(Console.ReadLine());

            decimal sueldoQ = sueldoM / 2;

          var tablaISR = 
                from item in  _TablaISR
                where item.limInf <= sueldoQ && item.limSup >= sueldoQ
                select item;
            foreach(var item in tablaISR)
            {
                Console.WriteLine($"Liminf: {item.limInf} LimSup: {item.limSup}, CuataFija: {item.cuotaFija}, ExedLiminf {item.porExced}, Subsidio {item.subsidio}");

                decimal Excedente = ((sueldoQ - item.limInf) *(item.porExced / 100));

             decimal impuesto = item.cuotaFija + Excedente - item
                    .subsidio;
            
            Console.WriteLine($" El Impuesto a pagar es {impuesto.ToString("C2")}");
            }

           /* foreach(var item in tablaISR)
            {
                Console.WriteLine($"Liminf: {item.limInf} LimSup: {item.limSup}, CuataFija: {item.cuotaFija}, ExedLiminf {item.porExced}, Subsidio {item.subsidio}");
            }*/
            ////////////////////////////////////////

        }



    }
}
