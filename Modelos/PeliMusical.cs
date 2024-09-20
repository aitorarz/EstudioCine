using Cine.Enums;
using Cine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine.Modelos
{
    class PeliMusical : IPelicula
    {
        public string Titulo { get; set; }
        public GeneroPelicula GeneroPelicula { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaEstreno { get; set; }
        public int ProgresoPorcentual {  get; set; }
        public List<IPersona> Directores { get; set; }
        public List<IPersona> Actores { get; set; }
        public PeliMusical(string titulo, int duracion, DateTime fechaEstreno, int progresoPorcentual)
        {
            Directores = new List<IPersona>();
            Actores = new List<IPersona>();
            Titulo = titulo;
            GeneroPelicula = GeneroPelicula.Musical;
            Duracion = duracion;
            FechaEstreno = fechaEstreno;
            ProgresoPorcentual = progresoPorcentual;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"\nTitulo: {Titulo}\nGenero: {GeneroPelicula}\nDuracion: {Duracion} minutos\nFecha de Estreno: {FechaEstreno}\nProgreso Porcentual: {ProgresoPorcentual}%");
            Console.WriteLine($"Director/es: ");
            foreach (IPersona value in Directores)
            {
                Console.WriteLine($"{value.Nombre}");
                Console.WriteLine(" - ");
            }
            Console.WriteLine($"\nActores: ");
            foreach (IPersona value in Actores)
            {
                Console.WriteLine($"{value.Nombre}");
                Console.WriteLine(" - ");
            }
        }
    }
}
