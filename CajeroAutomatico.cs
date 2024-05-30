using System;
using System.Collections.Generic;

public class CajeroAutomatico
{
    private List<Cliente> clientes;

    public CajeroAutomatico()
    {
        clientes = new List<Cliente>
        {
            new Cliente("JONATHAN DAVID RODRIGUEZ TEJADA", "1085298626", "123", 2000000, 5000),
            new Cliente("MARIA CAMILA PORTILLA MORALES", "1085308400", "456", 3000000, 6000),
            new Cliente("MARIA MAGOLA TEJADA MORALES", "59816547", "678", 1500000, 7500),
            new Cliente("CHRISTIAN GUILLERMO RODRIGUEZ TEJADA", "1085222333", "890", 2500000, 3500)
        };
    }

    public Cliente AutenticarCliente(string identificacion, string password)
    {
        foreach (var cliente in clientes)
        {
            if (cliente.Identificacion == identificacion)
            {
                if (cliente.Autenticar(password))
                {
                    return cliente;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                    return null;
                }
            }
        }
        Console.WriteLine("Identificación no encontrada.");
        return null;
    }

    public void MenuOperaciones(Cliente cliente)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("********Cajero Automático Vive Colombia********\n");
            Console.WriteLine($"Hola {cliente.Nombre}!");
            Console.WriteLine("*************************************************");
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("*************************************************");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("*************************************************");
            Console.WriteLine("2. Retirar dinero");
            Console.WriteLine("*************************************************");
            Console.WriteLine("3. Transferir dinero");
            Console.WriteLine("*************************************************");
            Console.WriteLine("4. Consultar puntos ViveColombia");
            Console.WriteLine("*************************************************");
            Console.WriteLine("5. Canjear puntos ViveColombia");
            Console.WriteLine("*************************************************");
            Console.WriteLine("6. Salir");
            Console.WriteLine("*************************************************");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("********Cajero Automático Vive Colombia********\n");

            switch (opcion)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*************************************************");
                    Console.WriteLine($"Saldo actual: {cliente.Saldo}");
                    Console.WriteLine("*************************************************");
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Ingrese la cantidad a retirar: ");
                    Console.WriteLine("*************************************************");
                    double cantidadRetiro;
                    if (double.TryParse(Console.ReadLine(), out cantidadRetiro))
                    {
                        if (cliente.Retirar(cantidadRetiro))
                        {
                            Console.WriteLine("*************************************************");
                            Console.WriteLine("Retiro exitoso.");
                            Console.WriteLine("*************************************************");
                        }
                        else
                        {
                            Console.WriteLine("****************************************************************");
                            Console.WriteLine("Retiro fallido. Verifique el saldo y el límite de retiro diario.");
                            Console.WriteLine("****************************************************************");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cantidad inválida.");
                    }
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Ingrese la identificación del destinatario: ");
                    Console.WriteLine("*************************************************");
                    string identificacionDestino = Console.ReadLine();
                    Cliente cuentaDestino = clientes.Find(c => c.Identificacion == identificacionDestino);
                    if (cuentaDestino != null)
                    {
                        Console.WriteLine($"Nombre del destinatario: {cuentaDestino.Nombre}");
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Ingrese la cantidad a transferir: ");
                        Console.WriteLine("*************************************************");
                        double cantidadTransferencia;
                        if (double.TryParse(Console.ReadLine(), out cantidadTransferencia))
                        {
                            if (cliente.Transferir(cuentaDestino, cantidadTransferencia))
                            {
                                Console.WriteLine("*************************************************");
                                Console.WriteLine("Transferencia exitosa.");
                                Console.WriteLine("*************************************************");
                            }
                            else
                            {
                                Console.WriteLine("*************************************************");
                                Console.WriteLine("Transferencia fallida. Verifique el saldo.");
                                Console.WriteLine("*************************************************");
                            }
                        }
                        else
                        {
                            Console.WriteLine("*************************************************");
                            Console.WriteLine("Cantidad inválida.");
                            Console.WriteLine("*************************************************");
                        }
                    }
                    else
                    {
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Cuenta destino no encontrada.");
                        Console.WriteLine("*************************************************");
                    }
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("*************************************************");
                    Console.WriteLine($"Tus puntos ViveColombia son: {cliente.PuntosViveColombia}");
                    Console.WriteLine("*************************************************");
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    double valorEnPesos = cliente.PuntosViveColombia * 7;
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine($"Tus puntos ViveColombia en pesos son: {valorEnPesos}");
                    Console.WriteLine("*****************************************************");
                    break;
                case "6":
                    Console.ResetColor();
                    return;
                default:
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Opción inválida.");
                    Console.WriteLine("*************************************************");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("*************************************************");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.WriteLine("*************************************************");
            Console.ReadKey();
        }
    }
}