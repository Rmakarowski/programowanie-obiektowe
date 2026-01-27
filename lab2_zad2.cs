// ZADANIE 2 – BankAccount

using System;
class BankAccount
{
    public decimal Saldo { get; private set; }
    public string Wlasciciel { get; private set; }

    public BankAccount(string wlasciciel, decimal saldoPoczatkowe)
    {
        if (string.IsNullOrWhiteSpace(wlasciciel))
            throw new ArgumentException("Właściciel nie może być pusty");
        if (saldoPoczatkowe < 0)
            throw new ArgumentException("Saldo początkowe nie może być ujemne");

        Wlasciciel = wlasciciel;
        Saldo = saldoPoczatkowe;
    }

    public void Wplata(decimal kwota)
    {
        if (kwota > 0)
            Saldo += kwota;
        else
            throw new ArgumentException("Kwota musi być dodatnia");
    }

    public void Wyplata(decimal kwota)
    {
        if (kwota > 0 && kwota <= Saldo)
            Saldo -= kwota;
        else
            throw new ArgumentException("Za mało środków lub nieprawidłowa kwota");
    }
}

class Program
{
    static void Main()
    {
        BankAccount konto = new BankAccount("Jan Kowalski", 10000);
        konto.Wplata(500);
        konto.Wyplata(100);
        Console.WriteLine($"Saldo: {konto.Saldo}");
    }
}
