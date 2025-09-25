using System;
using System.Collections.Generic;

class Program
{
    // Lista de revistas científicas 

    static List<string> catalogo = new List<string>()
    {
        "Redalyc.org",
        "Latindex",
        "Scimago Journal & Country Rank (SJR)",
        "Ciencia Ergo Sum",
        "Estudios Constitucionales",
        "Alea",
        "Revista de Derecho Económico y Socioambiental",
        "Podium",
        "REMI",
        "Revista de Educación a Distancia (RED)"
    };

    static void Main(string[] args)
    
    {
        int opcion;
        do

        {
            Console.WriteLine("\nCatálogo de Revistas Científicas para Investigaciones");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Listar catálogo");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Buscar revista por título: ");
                    string titulo = Console.ReadLine();

                    bool encontrado = BuscarRevistaRecursiva(catalogo, titulo, 0);

                    if (encontrado)
                        Console.WriteLine("Revista Encontrada");
                    else
                        Console.WriteLine("Revista no encontrada");
                    break;

                case 2:
                    Console.WriteLine("Catálogo de Revistas:");
                    for (int i = 0; i < catalogo.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {catalogo[i]}");
                    }
                    break;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("La opción no es correcta, intenta de nuevo.");
                    break;
            }

        } while (opcion != 3);
    }

    // Función recursiva para buscar las revistas

    static bool BuscarRevistaRecursiva(List<string> lista, string titulo, int indice)
    {
        if (indice >= lista.Count) return false;
        if (lista[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
            return true; 
        return BuscarRevistaRecursiva(lista, titulo, indice + 1);
    }
}
