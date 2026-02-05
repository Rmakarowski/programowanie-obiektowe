namespace Wypozyczalnia
{
	public class Sprzet
	{
		public int Id { get; set; }
		public string Nazwa { get; set; }
		public bool Dostepny { get; set; }
		public decimal CenaZaDzien { get; set; }

		public Sprzet(int id, string nazwa, decimal cena = 50)
		{
			Id = id;
			Nazwa = nazwa;
			Dostepny = true;
			CenaZaDzien = cena;
		}
	}
}
