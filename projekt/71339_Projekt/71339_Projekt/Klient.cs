namespace Wypozyczalnia
{
	public class Klient
	{
		public int Id { get; set; }
		public string Imie { get; set; }

		public Klient(int id, string imie)
		{
			Id = id;
			Imie = imie;
		}
	}
}
