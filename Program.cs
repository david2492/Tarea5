using System;

public class Program
{
    public static void Main()
    {
        Console.Title = "Cajero Automático Vive Colombia";
        CajeroAutomatico cajero = new CajeroAutomatico();

        Console.WriteLine("********Cajero Automático Vive Colombia********\n");
        Console.Write("Ingrese su identificación: ");
        string identificacion = Console.ReadLine();
        Console.Write("Ingrese su contraseña: ");
        string password = Console.ReadLine();

        Cliente clienteAutenticado = cajero.AutenticarCliente(identificacion, password);

        if (clienteAutenticado != null)
        {
            cajero.MenuOperaciones(clienteAutenticado);
        }
    }
}