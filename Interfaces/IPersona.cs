using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cine.Interfaces;
using Cine.Modelos;

namespace Cine.Interfaces
{
    public interface IPersona
    {
        string Nombre { get; set; }
        List<IPelicula> TrabajosComoActor {  get; set; }
        List<IPelicula> TrabajosComoDirector { get; set; }
        void MostrarInformacion();
    }
}
