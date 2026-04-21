using ListaDoble;

class Program
{
    static void Main()
    {
        Domador domador1 = new Domador();
        int opcion;

        do
        {
            Console.WriteLine("====== MENÚ DOMADOR ======");
            Console.WriteLine("1 - Agregar y domesticar león");
            Console.WriteLine("2 - Mostrar leones (Rebelde a Docil)");
            Console.WriteLine("3 - Mostrar leones mayores a una edad");
            Console.WriteLine("4 - Mezcla de leones pares a nuevo domador");
            Console.WriteLine("9 - Salir");
            Console.Write("Seleccione opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.\n");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    domador1.Domesticar();
                    break;
                case 2:
                    domador1.Mostrar();
                    break;
                case 3:
                    domador1.MayoresA();
                    break;
                case 4:
                    Domador domador2 = new Domador();
                    Console.Write("¿Cuántas jaulas desea agregar al nuevo domador? ");
                    if (int.TryParse(Console.ReadLine(), out int numJaulas))
                    {
                        for (int i = 0; i < numJaulas; i++)
                        {
                            Console.WriteLine($"\n--- León {i + 1} ---");
                            Console.Write("Ingrese nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese edad: ");
                            if (int.TryParse(Console.ReadLine(), out int edad))
                            {
                                Leon leon = new Leon(nombre, edad);
                                Jaula jaula = new Jaula(leon);

                                if (domador2.Docil == null)
                                {
                                    domador2.Docil = jaula;
                                    domador2.Rebelde = jaula;
                                }
                                else
                                {
                                    jaula.Sig = domador2.Docil;
                                    domador2.Docil.Ant = jaula;
                                    domador2.Docil = jaula;
                                }
                            }
                        }
                        domador1.MezclaParesInicio(domador2);
                        Console.WriteLine("\nDomador 2 después de la mezcla:");
                        domador2.Mostrar();
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;
                case 9:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                    break;
            }
        } while (opcion != 9);
    }
}