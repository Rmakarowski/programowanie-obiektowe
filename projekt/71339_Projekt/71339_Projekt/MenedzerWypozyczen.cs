using System;
using System.Collections.Generic;
using System.IO;

namespace Wypozyczalnia
{
	public class MenedzerWypozyczen
	{
		private List<Wypozyczenie> Wypozyczenia = new List<Wypozyczenie>();
		private MenedzerKlientow mk;
		private MenedzerSprzetu ms;
		private string folder = "Dane";
		private string sciezka = "Dane/wypozyczenia.txt";

		public MenedzerWypozyczen(MenedzerKlientow k, MenedzerSprzetu s)
		{
			mk = k;
			ms = s;
			if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
			if (!File.Exists(sciezka)) File.Create(sciezka).Close();

			foreach (var linia in File.ReadAllLines(sciezka))
			{
				var wyp = Wypozyczenie.ZPliku(linia);
				if (wyp != null)
				{
					Wypozyczenia.Add(wyp);
					var sprzet = ms.Sprzety.Find(x => x.Id == wyp.IdSprzetu);
					if (sprzet != null) sprzet.Dostepny = false;
				}
			}
		}

		public void Wypozycz()
		{
			if (mk.Klienci.Count == 0 || ms.Sprzety.Count == 0)
			{
				Console.WriteLine("Brak klientów lub sprzętu.");
				return;
			}

			mk.WyswietlKlientow();
			Console.Write("Id klienta: ");
			int kid = int.Parse(Console.ReadLine());

			ms.WyswietlSprzety();
			Console.Write("Id sprzętu: ");
			int sid = int.Parse(Console.ReadLine());

			Console.Write("Na ile dni? ");
			int dni = int.Parse(Console.ReadLine());

			Klient k = mk.Klienci.Find(x => x.Id == kid);
			Sprzet s = ms.Sprzety.Find(x => x.Id == sid && x.Dostepny);

			if (k != null && s != null)
			{
				var wyp = new Wypozyczenie(k.Id, k.Imie, s.Id, s.Nazwa, s.CenaZaDzien, dni);
				Wypozyczenia.Add(wyp);
				s.Dostepny = false;
				Zapisz();
				Console.WriteLine("Wypożyczono sprzęt.");
				Console.WriteLine(wyp.DrukujFakture());
			}
			else Console.WriteLine("Nie można wypożyczyć.");
		}

		public void Zwrot()
		{
			if (Wypozyczenia.Count == 0) { Console.WriteLine("Brak wypożyczeń."); return; }
			foreach (var w in Wypozyczenia) Console.WriteLine(w.ImieKlienta + " - " + w.NazwaSprzetu);
			Console.Write("Nazwa sprzętu do zwrotu: ");
			string nazwa = Console.ReadLine();
			var wyp = Wypozyczenia.Find(x => x.NazwaSprzetu == nazwa);
			if (wyp != null)
			{
				var sprzet = ms.Sprzety.Find(x => x.Id == wyp.IdSprzetu);
				if (sprzet != null) sprzet.Dostepny = true;
				Wypozyczenia.Remove(wyp);
				Zapisz();
				Console.WriteLine("Sprzęt zwrócony.");
				Console.WriteLine(wyp.DrukujFakture());
			}
			else Console.WriteLine("Nie znaleziono wypożyczenia.");
		}

		public void WyswietlWypozyczenia()
		{
			if (Wypozyczenia.Count == 0) { Console.WriteLine("Brak wypożyczeń."); return; }
			foreach (var w in Wypozyczenia)
				Console.WriteLine($"{w.ImieKlienta} wypożyczył {w.NazwaSprzetu} na {w.IloscDni} dni, do zapłaty: {w.ObliczOplate()} PLN");
		}

		private void Zapisz()
		{
			List<string> linie = new List<string>();
			foreach (var w in Wypozyczenia) linie.Add(w.DoPliku());
			File.WriteAllLines(sciezka, linie);
		}
	}
}
