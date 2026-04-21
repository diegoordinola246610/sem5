namespace ListaDoble
{
    class Domador
    {
        public Jaula? Docil { get; set; }  // Primera jaula
        public Jaula? Rebelde { get; set; } // Última jaula

        public Domador()
        {
            Docil = null;
            Rebelde = null;
        }

        // Agrega 1 jaula por el lado Docil
        public void Domesticar()
        {
            Console.Write("Ingrese nombre del león: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese edad del león: ");
            int edad = int.Parse(Console.ReadLine());

            Leon nuevoLeon = new Leon(nombre, edad);
            Jaula nuevaJaula = new Jaula(nuevoLeon);

            if (Docil == null)
            {
                Docil = nuevaJaula;
                Rebelde = nuevaJaula;
            }
            else
            {
                nuevaJaula.Sig = Docil;
                Docil.Ant = nuevaJaula;
                Docil = nuevaJaula;
            }

            Console.WriteLine("León domesticado exitosamente.\n");
        }

        // Muestra las jaulas a partir del Rebelde al Docil (orden inverso)
        public void Mostrar()
        {
            if (Rebelde == null)
            {
                Console.WriteLine("No hay leones en el domador.\n");
                return;
            }

            Console.WriteLine("=== Leones en el Domador ===");
            Jaula actual = Rebelde;
            int contador = 1;
            while (actual != null)
            {
                Console.WriteLine($"{contador}. {actual.Leon}");
                actual = actual.Ant;
                contador++;
            }
            Console.WriteLine();
        }

        // Muestra leones mayores o iguales a una edad especificada
        public void MayoresA()
        {
            Console.Write("Ingrese edad mínima: ");
            int edadMin = int.Parse(Console.ReadLine());

            bool encontrado = false;
            Console.WriteLine($"=== Leones con edad >= {edadMin} ===");

            Jaula actual = Rebelde;
            while (actual != null)
            {
                if (actual.Leon.Edad >= edadMin)
                {
                    Console.WriteLine(actual.Leon);
                    encontrado = true;
                }
                actual = actual.Ant;
            }

            if (!encontrado)
            {
                Console.WriteLine("No hay leones con esa edad.");
            }
            Console.WriteLine();
        }

        // Agrega leones con edad par del domador actual al final del domador pasado
        public void MezclaParesInicio(Domador drador2)
        {
            Jaula actual = Rebelde;
            while (actual != null)
            {
                if (actual.Leon.Edad % 2 == 0) // Si es par
                {
                    Leon leonPar = new Leon(actual.Leon.Nombre, actual.Leon.Edad);
                    Jaula nuevaJaula = new Jaula(leonPar);

                    if (drador2.Rebelde == null)
                    {
                        drador2.Docil = nuevaJaula;
                        drador2.Rebelde = nuevaJaula;
                    }
                    else
                    {
                        // Agrega al final (al lado Rebelde)
                        drador2.Rebelde.Sig = nuevaJaula;
                        nuevaJaula.Ant = drador2.Rebelde;
                        drador2.Rebelde = nuevaJaula;
                    }
                }
                actual = actual.Ant;
            }

            Console.WriteLine("Mezcla realizada exitosamente.\n");
        }
    }
}