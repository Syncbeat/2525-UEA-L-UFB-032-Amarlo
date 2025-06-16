// Registro de Estudiante en base de datos

using System;

public class Estudiante
{
    // Datos del estudiante
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; }  // Contendra 2 números de contacto

    //Constructor
    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        if (telefonos.Length != 2)
        {
            throw new ArgumentException("Por favor , ingrese dos números de contacto");
        }

        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;
    }

    //Método que muestra los datos
    public void MostrarDatos()
    {
        Console.WriteLine($"ID: {Id.ToString("D5")}");
        Console.WriteLine($"Nombre: {Nombres} {Apellidos}");
        Console.WriteLine($"Direccion: {Direccion}");
        Console.WriteLine("Telefonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"  - {Telefonos[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Array con dos números de contacto
        string[] telefonos = { "0983260643", "0987654321" };

        //Crea el objeto estudiante
        Estudiante estudiante1 = new Estudiante(
            id: 00001,
            nombres: "Marcelo",
            apellidos: "Guagua",
            direccion: "Av.Gotts Street E35 N24",
            telefonos: telefonos
        );

        // Imprime los datos
        estudiante1.MostrarDatos();
    }
}