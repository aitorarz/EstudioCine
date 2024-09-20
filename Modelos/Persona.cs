using Cine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Modelos
{
    class Persona : IPersona
    {
        public string Nombre { get; set; }
        public List<IPelicula> TrabajosComoActor { get; set; }
        public List<IPelicula> TrabajosComoDirector { get; set; }
        public Persona(string nombre)
        {
            Nombre = nombre;
            TrabajosComoActor = new List<IPelicula>();
            TrabajosComoDirector = new List<IPelicula>();
        }
        public void MostrarNombre()
        {
            Console.WriteLine($"{Nombre}");
        }
        public void MostrarInformacion()
        {
            Console.WriteLine("Peliculas en las que actua:\n");
            foreach (IPelicula value in TrabajosComoActor)
            {
                Console.WriteLine($"{value.Titulo} - \n");
            }
            Console.WriteLine("Peliculas donde es director:\n");
            foreach(IPelicula value in TrabajosComoDirector)
            {
                Console.WriteLine($"{value.Titulo} - \n");
            }
        }
    }
}
