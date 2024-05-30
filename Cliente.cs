using System;

public class Cliente
{
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
    private string Password { get; set; }
    public int PuntosViveColombia { get; set; }
    public double Saldo { get; set; }
    private double TopeDiarioRetiros = 2000000;
    private double RetirosHoy = 0;

    public Cliente(string nombre, string identificacion, string password, double saldoInicial, int puntosViveColombia)
    {
        Nombre = nombre;
        Identificacion = identificacion;
        Password = password;
        Saldo = saldoInicial;
        PuntosViveColombia = puntosViveColombia;
    }

    public bool Autenticar(string password)
    {
        return Password == password;
    }

    public bool Retirar(double cantidad)
    {
        if (Saldo >= cantidad && RetirosHoy + cantidad <= TopeDiarioRetiros)
        {
            Saldo -= cantidad;
            RetirosHoy += cantidad;
            return true;
        }
        return false;
    }

    public bool Transferir(Cliente cuentaDestino, double cantidad)
    {
        if (Saldo >= cantidad)
        {
            Saldo -= cantidad;
            cuentaDestino.Saldo += cantidad;
            return true;
        }
        return false;
    }

    public void ReiniciarRetirosDiarios()
    {
        RetirosHoy = 0;
    }
}