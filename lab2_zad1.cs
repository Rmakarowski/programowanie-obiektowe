
ZAD 1
// // // // // // //  Napisz klasę Osoba, która będzie przechowywać informacje o imieniu, nazwisku oraz wieku osoby.
// // // // // // // // • Zaimplementuj konstruktor, który będzie przyjmował wszystkie trzy wartości.
// // // // // // // // • Użyj właściwości Imie, Nazwisko, Wiek, z walidacją:
// // // // // // // // o Imię i Nazwisko muszą mieć co najmniej 2 znaki.
// // // // // // // // o Wiek musi być liczbą dodatnią.
// // // // // // // // • Zaimplementuj metodę WyswietlInformacje(), która wyświetli informacje o osobie.


using System;
    class Osoba
    {
        private string Imie;
        private string Nazwisko;
        private int Wiek;
        public Osoba(string imie, string nazwisko, int wiek)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Wiek = wiek;
        }
        public string imie
        {
            get { return imie; }
            set
            {
                string trimmed = value.Trim();
                if (trimmed.Length >= 2 && !trimmed.Contains(" "))
                    imie = trimmed;
                else
                    throw new ArgumentException("imię musi mieć co najmniej 2 znaki i nie może zawierać spacji");
            }

        }
        public string nazwisko
        {
            get { return nazwisko; }
            set
            {
                string trimmed = value.Trim();
                if (trimmed.Length >= 2 && !trimmed.Contains(" "))
                    nazwisko = trimmed;
                else
                    throw new ArgumentException("nazwisko musi mieć co najmniej 2 znaki i nie może zawierać spacji");
            }
        }
        public int wiek
        {
            get { return wiek; }
            set
            {
                if (wiek > 0)
                    wiek = value;
                else
                    throw new ArgumentException("wiek musi mieć conajmniej 2 znaki");
            }
        }
        public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}");
    }
    }

    class Program
    {
        static void Main()
        {
            Osoba o = new Osoba(" Kuba ", "Kowalski", 20);
        o.WyswietlInformacje();
    }
}
