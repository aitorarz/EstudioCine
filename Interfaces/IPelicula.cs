using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cine.Enums;
using Cine.Interfaces;
using Cine.Modelos;

namespace Cine.Interfaces
{
    public interface IPelicula
    {
        string Titulo {  get; set; }
        GeneroPelicula GeneroPelicula {  get; set; }
        int Duracion {  get; set; }
        DateTime FechaEstreno { get; set; }
        int ProgresoPorcentual { get; set; }
        List<IPersona> Directores { get; set; }
        List<IPersona> Actores { get; set; }
        void MostrarInformacion();
    }
}
