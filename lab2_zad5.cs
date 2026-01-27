// ZADANIE 5 – Sumator
class Sumator
{
    private int[] Liczby;

    public Sumator(int[] liczby)
    {
        Liczby = liczby;
    }

    public int Suma()
    {
        int Suma = 0;
        foreach (int Liczba in Liczby)
        {
            Suma += Liczba;
        }
        return Suma;
    }

    public int SumaPodziel2()
    {
        int Suma = 0;
        foreach (int Liczba in Liczby)
        {
            if (Liczba % 2 == 0)
            {
                Suma += Liczba;
            }
        }
        return Suma;
    }

    public int IleElementów()
    {
        return Liczby.Length;
    }

    public void Wypisz()
    {
        foreach (int Liczba in Liczby)
            Console.WriteLine(Liczba);
    }

    public void Parametr(int lowIndex, int highIndex)
    {
        for (int i = lowIndex; i <= highIndex; i++)
        {
            if (i >= 0 && i < Liczby.Length)
            {
                Console.WriteLine(Liczby[i]);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] tablica = { 2, 4, 1, 3, 6, 3, 7, 8, 9, 10, 1 };

        Sumator s = new Sumator(tablica);

        Console.WriteLine("Suma: " + s.Suma());
        Console.WriteLine("Suma podzielnych przez 2: " + s.SumaPodziel2());
        Console.WriteLine("Ile elementów: " + s.IleElementów());

        Console.WriteLine("\nWszystkie elementy:");
        s.Wypisz();

        Console.WriteLine("\nZakres indeksów 1–10:");
        s.Parametr(1, 10);
    }
}
