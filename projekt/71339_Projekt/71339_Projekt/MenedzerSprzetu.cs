using System;
using System.Collections.Generic;
using System.IO;

namespace Wypozyczalnia
{
	public class MenedzerSprzetu
	{
		public List<Sprzet> Sprzety = new List<Sprzet>();
		private string folder = "Dane";
		private string sciezka = "Dane/sprzety.txt";

		public MenedzerSprzetu()
		{
			if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
			if (!File.Exists(sciezka)) File.Create(sciezka).Close();

			foreach (var linia in File.ReadAllLines(sciezka))
			{
				if (!string.IsNullOrWhiteSpace(linia))
				{
					var d = linia.Split(';');
					if (d.Length < 4) continue;
					bool dostepny = d[3].Trim().ToLower() == "true";
					Sprzety.Add(new SprzetInny(int.Parse(d[0]), d[1], decimal.Parse(d[2])) { Dostepny = dostepny });
				}
			}
		}

		public void DodajSprzet()
		{
			Console.WriteLine("Wybierz typ sprzętu:");
			Console.WriteLine("1 - Sprzęt budowlany");
			Console.WriteLine("2 - Sprzęt ogrodowy");
			Console.WriteLine("3 - Maszyna ciężka");
			Console.WriteLine("4 - Inny sprzęt");
			Console.Write("Twój wybór: ");
			string typ = Console.ReadLine();

			Console.Write("Nazwa sprzętu: ");
			string nazwa = Console.ReadLine();

			Console.Write("Cena za dzień: ");
			decimal cena = decimal.Parse(Console.ReadLine());

			Sprzet nowySprzet;

			if (typ == "1") nowySprzet = new SprzetBudowlany(Sprzety.Count + 1, nazwa, cena);
			else if (typ == "2") nowySprzet = new SprzetOgrodowy(Sprzety.Count + 1, nazwa, cena);
			else if (typ == "3") nowySprzet = new MaszynaCiezka(Sprzety.Count + 1, nazwa, cena);
			else nowySprzet = new SprzetInny(Sprzety.Count + 1, nazwa, cena);

			Sprzety.Add(nowySprzet);
			Zapisz();
			Console.WriteLine("Dodano sprzęt: " + nazwa + " (" + nowySprzet.GetType().Name + ")");
		}


		public void WyswietlSprzety()
		{
			if (Sprzety.Count == 0)
			{
				Console.WriteLine("Brak sprzętu.");
				return;
			}

			Console.WriteLine("\nLista sprzętu:");
			foreach (var s in Sprzety)
			{
				
				Console.WriteLine($"{s.Id} - {s.Nazwa} | Typ: {s.GetType().Name} | Dostępny: {s.Dostepny} | Cena za dzień: {s.CenaZaDzien} zł");
			}
		}


		public void UsunSprzet()
		{
			if (Sprzety.Count == 0) { Console.WriteLine("Brak sprzętu do usunięcia."); return; }
			WyswietlSprzety();
			Console.Write("Podaj Id sprzętu do usunięcia: ");
			int id = int.Parse(Console.ReadLine());
			var s = Sprzety.Find(x => x.Id == id);
			if (s != null)
			{
				Sprzety.Remove(s);
				Zapisz();
				Console.WriteLine("Sprzęt usunięty.");
			}
			else Console.WriteLine("Nie znaleziono sprzętu.");
		}

		public void EdytujSprzet()
		{
			if (Sprzety.Count == 0) { Console.WriteLine("Brak sprzętu do edycji."); return; }
			WyswietlSprzety();
			Console.Write("Podaj Id sprzętu do edycji: ");
			int id = int.Parse(Console.ReadLine());
			var s = Sprzety.Find(x => x.Id == id);
			if (s != null)
			{
				Console.Write("Nowa nazwa: ");
				s.Nazwa = Console.ReadLine();
				Console.Write("Nowa cena za dzień: ");
				s.CenaZaDzien = decimal.Parse(Console.ReadLine());
				Zapisz();
				Console.WriteLine("Sprzęt zaktualizowany.");
			}
			else Console.WriteLine("Nie znaleziono sprzętu.");
		}

		private void Zapisz()
		{
			List<string> linie = new List<string>();
			foreach (var s in Sprzety)
				linie.Add(s.Id + ";" + s.Nazwa + ";" + s.CenaZaDzien + ";" + s.Dostepny);
			File.WriteAllLines(sciezka, linie);
		}
	}
}
