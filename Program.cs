
using Cine.Enums;
using Cine.Interfaces;
using Cine.Modelos;
using System.ComponentModel.Design;
class Program
{
    static void Main()
    {
        Persona JohnMarshall = new Persona("John Marshall");
        Persona MichaelKennedy = new Persona("Michael Kennedy");
        Persona JeremyFitzgerald = new Persona("Jeremy Fitzgerald");
        Persona TakayukiYagami = new Persona("Takayuki Yagami");
        PeliHorror TheLamb = new PeliHorror("The Lamb", 118, new DateTime(2024, 10, 19), 50);
        PeliComedia Programadores = new PeliComedia("Progr(amadores)", 90, new DateTime(2025, 9, 19), 0);
       
        TheLamb.Actores.Add(JohnMarshall);
        TheLamb.Actores.Add(MichaelKennedy);
        TheLamb.Actores.Add(JeremyFitzgerald);
        TheLamb.Directores.Add(TakayukiYagami);
        Programadores.Actores.Add(JohnMarshall);
        Programadores.Actores.Add(MichaelKennedy);
        Programadores.Directores.Add(JohnMarshall);
        JohnMarshall.TrabajosComoActor.Add(TheLamb);
        JohnMarshall.TrabajosComoActor.Add(Programadores);
        JohnMarshall.TrabajosComoDirector.Add(Programadores);
        MichaelKennedy.TrabajosComoActor.Add(TheLamb);
        MichaelKennedy.TrabajosComoActor.Add(Programadores);
        JeremyFitzgerald.TrabajosComoActor.Add(TheLamb);
        TakayukiYagami.TrabajosComoDirector.Add(TheLamb);

        List<IPersona> TrabajadoresRegistrados = new List<IPersona>
        {
            JohnMarshall,
            MichaelKennedy,
            JeremyFitzgerald,
            TakayukiYagami
        };

        List<IPelicula> Peliculas = new List<IPelicula>()
        {
            TheLamb,
            Programadores
        };

        bool swich = true;
        while (swich) 
        {
            Console.WriteLine("ACLARACION: LOS UNICOS GENEROS DE PELICULAS DISPONIBLES SON comedia, musical Y horror\nBienvenido, Elija la opcion que desee:\n" +
                "1 para registrar una nueva persona al ambito laboral\n" +
                "2 para registrar a una persona del ambito laboral como actor de alguna pelicula\n" +
                "3 para registrar a una persona del ambito laboral como director de alguna pelicula\n" +
                "4 para registrar una nueva pelicula (sin registrar actores y directores)\n" +
                "5 para modificar el porcentaje de progreso de alguna pelicula\n" +
                "6 para quitar a una persona de la lista de actores de alguna pelicula\n" +
                "7 para quitar a una persona de la lista de directores de alguna pelicula\n" +
                "8 para mostrar las peliculas actuales\n" +
                "9 para mostrar los trabajos en los que esta involucrado alguna persona del ambito laboral\n\n" +
                "0 para salir del programa");
            int input = int.Parse(Console.ReadLine());
            if (input == 0) { swich = false; }
            else if (input == 1)
            {
                Console.WriteLine("Ingrese el nombre y apellido de la persona a registrar: ");
                string miNombre = Console.ReadLine();
                TrabajadoresRegistrados.Add(new Persona(miNombre));

            }
            else if (input == 2)
            {
                Console.WriteLine("Selecciona la pelicula a la cual vas a sumarle un actor (asegurate de poner las mayusculas):\n");
                foreach (IPelicula value in Peliculas) { Console.WriteLine($"{value.Titulo}\n"); }
                string peliChosen = Console.ReadLine();
                IPelicula peliElegida = Peliculas.Find(p => p.Titulo == peliChosen);
                if (peliElegida == null) { Console.WriteLine("La pelicula que has ingresado no esta en la lista."); }
                else
                {
                    Console.WriteLine($"Ahora elija un actor para agregar al reparto de {peliElegida.Titulo} (al igual que antes, revise las mayusculas):\n");
                    foreach (IPersona value in TrabajadoresRegistrados) { Console.WriteLine($"{value.Nombre}\n"); }
                    string actorChosen = Console.ReadLine();
                    IPersona actorElegido = TrabajadoresRegistrados.Find(p => p.Nombre == actorChosen);
                    if (actorElegido == null) { Console.WriteLine("El actor que quisiste agregar no esta registrado."); }
                    else
                    {
                        if (peliElegida.Actores.Contains(actorElegido))
                        {
                            Console.WriteLine($"El actor que has intentado agregar ya formaba parte del reparto de {peliElegida.Titulo}");
                        }
                        else
                        {
                            peliElegida.Actores.Add(actorElegido);
                            actorElegido.TrabajosComoActor.Add(peliElegida);
                            Console.WriteLine("Actor agregado exitosamente!");
                        }
                    }
                }
            }
            else if (input == 3)
            {
                Console.WriteLine("Selecciona la pelicula a la cual vas a sumarle un director (asegurate de poner las mayusculas):\n");
                foreach (IPelicula value in Peliculas) { Console.WriteLine($"{value.Titulo}\n"); }
                string peliChosen = Console.ReadLine();
                IPelicula peliElegida = Peliculas.Find(p => p.Titulo == peliChosen);
                if (peliElegida == null) { Console.WriteLine("La pelicula que has ingresado no esta en la lista."); }
                else
                {
                    Console.WriteLine($"Ahora elija un director para agregar al reparto de {peliElegida.Titulo} (al igual que antes, revise las mayusculas):\n");
                    foreach (IPersona value in TrabajadoresRegistrados) { Console.WriteLine($"{value.Nombre}\n"); }
                    string directorChosen = Console.ReadLine();
                    IPersona directorElegido = TrabajadoresRegistrados.Find(p => p.Nombre == directorChosen);
                    if (directorElegido == null) { Console.WriteLine("El director que quisiste agregar no esta registrado."); }
                    else
                    {
                        if (peliElegida.Directores.Contains(directorElegido))
                        {
                            Console.WriteLine($"El actor que has intentado agregar ya formaba parte del reparto de {peliElegida.Titulo}");
                        }
                        else
                        {
                            peliElegida.Directores.Add(directorElegido);
                            directorElegido.TrabajosComoDirector.Add(peliElegida);
                            Console.WriteLine("Director agregado exitosamente!");
                        }
                    }
                }
            }
            else if (input == 4)
            {
                Console.WriteLine("Ingrese el nombre de la nueva pelicula para registrar: ");
                string miTitulo = Console.ReadLine();
                Console.WriteLine("Ahora ingrese su duracion: ");
                int miDuracion = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el anio, mes y dia de estreno de la pelicula: ");
                DateTime miFecha = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el progreso porcentual de finalizacion de la obra: ");
                int miProgreso = int.Parse(Console.ReadLine());
                Console.WriteLine("Finalmente, ingrese el genero de la pelicula: ");
                string miGenero = Console.ReadLine().ToLower();
                if (miGenero == "comedia") { Peliculas.Add(new PeliComedia(miTitulo, miDuracion, miFecha, miProgreso)); }
                else if (miGenero == "musical") { Peliculas.Add(new PeliMusical(miTitulo, miDuracion, miFecha, miProgreso)); }
                else if (miGenero == "horror") { Peliculas.Add(new PeliHorror(miTitulo, miDuracion, miFecha, miProgreso)); }
                else { Console.WriteLine("El genero que has ingresado no esta registrado en los enums del programa"); }
            }
            else if (input == 5)
            {
                Console.WriteLine("Selecciona la pelicula a la cual vas a modificar su progreso (asegurate de poner las mayusculas):\n");
                foreach (IPelicula value in Peliculas) { Console.WriteLine($"{value.Titulo}\n"); }
                string peliChosen = Console.ReadLine();
                IPelicula peliElegida = Peliculas.Find(p => p.Titulo == peliChosen);
                if (peliElegida == null) { Console.WriteLine("La pelicula que has ingresado no se encuentra en la lista."); }
                else
                {
                    Console.WriteLine($"El progreso actual de esta pelicula es de {peliElegida.ProgresoPorcentual}%, ingrese el nuevo porcentaje: ");
                    int nuevoProgreso = int.Parse(Console.ReadLine());
                    peliElegida.ProgresoPorcentual = nuevoProgreso;
                    Console.WriteLine("Progreso modificado exitosamente!");
                }
            }
            else if (input == 6)
            {
                Console.WriteLine("Selecciona la pelicula a la cual vas a quitarle un actor (asegurate de poner las mayuscylas):\n");
                foreach (IPelicula value in Peliculas) { Console.WriteLine($"{value.Titulo}\n"); }
                string peliChosen = Console.ReadLine();
                IPelicula peliElegida = Peliculas.Find(p => p.Titulo == peliChosen);
                if (peliElegida == null) { Console.WriteLine("La pelicula que has ingresado no se encuentra en la lista."); }
                else
                {
                    Console.WriteLine($"Ahora elija un actor para quitar del reparto de {peliElegida.Titulo} (al igual que antes, revise las mayusculas):\n");
                    foreach (IPersona value in peliElegida.Actores) { Console.WriteLine($"{value.Nombre}\n"); }
                    string actorChosen = Console.ReadLine();
                    IPersona actorElegido = peliElegida.Actores.Find(p => p.Nombre == actorChosen);
                    if (actorElegido == null) { Console.WriteLine("El actor que has ingresado no forma parte del reparto."); }
                    else
                    {
                        peliElegida.Actores.Remove(actorElegido);
                        actorElegido.TrabajosComoActor.Remove(peliElegida);
                        Console.WriteLine("Actor eliminado exitosamente!");
                    }
                }
            }
            else if (input == 7)
            {
                Console.WriteLine("Selecciona la pelicula a la cual vas a quitarle un director (asegurate de poner las mayusculas):\n");
                foreach (IPelicula value in Peliculas) { Console.WriteLine($"{value.Titulo}\n"); }
                string peliChosen = Console.ReadLine();
                IPelicula peliElegida = Peliculas.Find(p => p.Titulo == peliChosen);
                if (peliElegida == null) { Console.WriteLine("La pelicula ingresada no se encuentra en la lista."); }
                else
                {
                    Console.WriteLine($"Ahora elija un director para quitar del reparto de {peliElegida.Titulo} (al igual que antes, revise las mayusculas):\n");
                    foreach (IPersona value in peliElegida.Directores) { Console.WriteLine($"{value.Nombre}\n"); }
                    string directorChosen = Console.ReadLine();
                    IPersona directorElegido = peliElegida.Directores.Find(p => p.Nombre == directorChosen);
                    if (directorElegido == null) { Console.WriteLine("El director que elegiste no forma parte del reparto."); }
                    else
                    {
                        peliElegida.Directores.Remove(directorElegido);
                        directorElegido.TrabajosComoDirector.Remove(peliElegida);
                        Console.WriteLine("Director eliminado exitosamente!");
                    }
                }
            }
            else if (input == 8)
            {
                Console.WriteLine("Estas son las peliculas que se estan trabajando:\n");
                foreach (IPelicula value in Peliculas)
                {
                    value.MostrarInformacion();
                    Console.WriteLine("\n\n");
                }
            }
            else if (input == 9)
            {
                Console.WriteLine("Ingrese el nombre del trabajador del cual desea ver las peliculas en las que esta involucrado (atencion a las mayusculas):");
                foreach (IPersona value in TrabajadoresRegistrados) { Console.WriteLine($"{value.Nombre}\n"); }
                string personaChosen = Console.ReadLine();
                IPersona personaElegida = TrabajadoresRegistrados.Find(p => p.Nombre == personaChosen);
                if (personaElegida == null) { Console.WriteLine($"La persona que ingresaste no se encuentra registrada."); }
                else
                {
                    personaElegida.MostrarInformacion();
                }
            }
        }
    }
}