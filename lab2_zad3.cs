ZADANIE 3 – Student

class Student
{
    string imie;
    string nazwisko;
    List<int> oceny;

    public Student(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        oceny = new List<int>();
    }

    public void DodajOcene(int ocena)
    {
        oceny.Add(ocena);
    }

    public double SredniaOcen
    {
        get
        {
            if (oceny.Count == 0) return 0;

            double suma = 0;
            foreach (int o in oceny)
                suma += o;

            return suma / oceny.Count;
        }
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student("Jan", "Kowalski");
        s.DodajOcene(5);
        s.DodajOcene(5);
        s.DodajOcene(3);
        Console.WriteLine($"Średnia ocen studenta: {s.SredniaOcen}");
    }
}

