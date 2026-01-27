// ZAD 4
using System;

namespace Lab2_Zad4
{
    static class Program
    {
        public class Licz
        {
            private double value;

            public void Dodaj(double parametr)
            {
                this.value += parametr;
            }

            public void Odejmij(double parametr)
            {
                this.value -= parametr;
            }

            public Licz(double x)
            {
                this.value = x;
            }

            public void WypiszStan() 
            {
                Console.WriteLine($"Aktualna wartość: {this.value}.");
            }
        }
        static void Main(string[] args)
        {
            Licz obiekt1 = new Licz(3);
            obiekt1.Dodaj(2);
            obiekt1.Odejmij(1);
            obiekt1.WypiszStan();
        }
    }
}
