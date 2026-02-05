using System;
using System.Collections.Generic;
using System.IO;

namespace Wypozyczalnia
{
	public class MenedzerKlientow
	{
		public List<Klient> Klienci = new List<Klient>();
		private string folder = "Dane";
		private string sciezka = "Dane/klienci.txt";

		public MenedzerKlientow()
		{
			if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
			if (!File.Exists(sciezka)) File.Create(sciezka).Close();

			foreach (var linia in File.ReadAllLines(sciezka))
			{
				if (!string.IsNullOrWhiteSpace(linia))
				{
					var dane = linia.Split(';');
					Klienci.Add(new Klient(int.Parse(dane[0]), dane[1]));
				}
			}
		}

		public void DodajKlienta()
		{
			Console.Write("Imię klienta: ");
			string imie = Console.ReadLine();
			Klienci.Add(new Klient(Klienci.Count + 1, imie));
			Zapisz();
		}

		public void WyswietlKlientow()
		{
			if (Klienci.Count == 0) Console.WriteLine("Brak klientów.");
			foreach (var k in Klienci)
				Console.WriteLine(k.Id + " " + k.Imie);
		}

		public void UsunKlienta()
		{
			if (Klienci.Count == 0) { Console.WriteLine("Brak klientów do usunięcia."); return; }
			WyswietlKlientow();
			Console.Write("Podaj Id klienta do usunięcia: ");
			int id = int.Parse(Console.ReadLine());
			var k = Klienci.Find(x => x.Id == id);
			if (k != null)
			{
				Klienci.Remove(k);
				Zapisz();
				Console.WriteLine("Klient usunięty.");
			}
			else Console.WriteLine("Nie znaleziono klienta.");
		}

		private void Zapisz()
		{
			List<string> linie = new List<string>();
			foreach (var k in Klienci)
				linie.Add(k.Id + ";" + k.Imie);
			File.WriteAllLines(sciezka, linie);
		}
	}
}
