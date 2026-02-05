using System;

namespace Wypozyczalnia
{
	public class Wypozyczenie
	{
		public int IdKlienta { get; set; }
		public int IdSprzetu { get; set; }
		public string NazwaSprzetu { get; set; }
		public string ImieKlienta { get; set; }
		public int IloscDni { get; set; }
		public DateTime DataWypozyczenia { get; set; }
		public decimal CenaZaDzien { get; set; }

		public Wypozyczenie(int idKlienta, string imie, int idSprzetu, string nazwaSprzetu, decimal cena, int dni)
		{
			IdKlienta = idKlienta;
			ImieKlienta = imie;
			IdSprzetu = idSprzetu;
			NazwaSprzetu = nazwaSprzetu;
			CenaZaDzien = cena;
			IloscDni = dni;
			DataWypozyczenia = DateTime.Now;
		}

		public decimal ObliczOplate()
		{
			return CenaZaDzien * IloscDni;
		}

		public string DrukujFakture()
		{
			return $"= FAKTURA =\nKlient: {ImieKlienta}\nSprzęt: {NazwaSprzetu}\nDni: {IloscDni}\nDo zapłaty: {ObliczOplate()} PLN\nData: {DateTime.Now}";
		}

		public string DoPliku()
		{
			return $"{IdKlienta};{ImieKlienta};{IdSprzetu};{NazwaSprzetu};{CenaZaDzien};{IloscDni};{DataWypozyczenia}";
		}

		public static Wypozyczenie ZPliku(string linia)
		{
			if (string.IsNullOrWhiteSpace(linia)) return null;
			var d = linia.Split(';');
			if (d.Length < 7) return null;
			return new Wypozyczenie(
				int.Parse(d[0]),
				d[1],
				int.Parse(d[2]),
				d[3],
				decimal.Parse(d[4]),
				int.Parse(d[5])
			)
			{ DataWypozyczenia = DateTime.Parse(d[6]) };
		}
	}
}
