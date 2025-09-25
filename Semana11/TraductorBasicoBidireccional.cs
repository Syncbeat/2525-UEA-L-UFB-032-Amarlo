using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class TraductorSimple
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>();

    static void Main()
    {
        CargarDiccionario();
    // Menu con 3 opciones y excepcion si se introduce una opción invalida
        while (true)
        {
            Console.WriteLine("=== MENÚ ===");
            Console.WriteLine("1. Traducir frase");
            Console.WriteLine("2. Agregar palabra");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Traducir();
            }
            else if (opcion == "2")
            {
                AgregarPalabra();
            }
            else if (opcion == "0")
            {
                Console.WriteLine("¡Adiós!");
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida.\n");
            }
        }
    }
    // Diccionario Sugerido
    static void CargarDiccionario()
    {
        AgregarPar("time", "tiempo");
        AgregarPar("person", "persona");
        AgregarPar("year", "año");
        AgregarPar("way", "camino");
        AgregarPar("day", "día");
        AgregarPar("thing", "cosa");
        AgregarPar("man", "hombre");
        AgregarPar("world", "mundo");
        AgregarPar("life", "vida");
        AgregarPar("hand", "mano");
    }

    static void AgregarPar(string palabra1, string palabra2)
    {
        diccionario[palabra1.ToLower()] = palabra2;
        diccionario[palabra2.ToLower()] = palabra1;
    }

    // Permite al usuario agregar una nueva palabra

    static void AgregarPalabra()
    {
        Console.Write("Palabra: ");
        string palabra = Console.ReadLine()?.ToLower();
        Console.Write("Traducción: ");
        string traduccion = Console.ReadLine()?.ToLower();

        if (string.IsNullOrEmpty(palabra) || string.IsNullOrEmpty(traduccion))
        {
            Console.WriteLine("Entrada inválida.\n");
            return;
        }

        // Esta función permite traducción bidireccional Español = Ingles e Ingles = Español

        diccionario[palabra] = traduccion;
        diccionario[traduccion] = palabra;

        Console.WriteLine("Palabra agregada.\n");
    }

        // input para agregar la frase para traducir

    static void Traducir()
    {
        Console.Write("Frase: ");
        string frase = Console.ReadLine();

        if (string.IsNullOrEmpty(frase))
        {
            Console.WriteLine("No se ingresó nada.\n");
            return;
        }

        //La expresion (\p{L}+) permite dividir las palabras usando expresiones regulares

        string[] partes = Regex.Split(frase, @"(\p{L}+)");
        for (int i = 0; i < partes.Length; i++)
        {
            if (Regex.IsMatch(partes[i], @"^\p{L}+$"))
            {
                string palabra = partes[i].ToLower();
                if (diccionario.ContainsKey(palabra))
                {
                    partes[i] = AjustarMayusculas(partes[i], diccionario[palabra]);
                }
            }
        }

        string resultado = string.Join("", partes);
        Console.WriteLine("Traducción:");
        Console.WriteLine(resultado + "\n");
    }

    static string AjustarMayusculas(string original, string traduccion)
    {
        if (original.ToUpper() == original)
            return traduccion.ToUpper();
        if (char.IsUpper(original[0]))
            return char.ToUpper(traduccion[0]) + traduccion.Substring(1);
        return traduccion;
    }
}