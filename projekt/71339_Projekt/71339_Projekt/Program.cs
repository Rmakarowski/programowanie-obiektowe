using System;

namespace Wypozyczalnia
{
	class Program
	{
		static void Main()
		{
			MenedzerKlientow menedzerKlientow = new MenedzerKlientow();
			MenedzerSprzetu menedzerSprzetu = new MenedzerSprzetu();
			MenedzerWypozyczen menedzerWypozyczen = new MenedzerWypozyczen(menedzerKlientow, menedzerSprzetu);

			while (true)
			{
				Console.WriteLine("\n= WYPOŻYCZALNIA SPRZĘTU =");
				Console.WriteLine("1 - Dodaj klienta");
				Console.WriteLine("2 - Wyświetl klientów");
				Console.WriteLine("3 - Dodaj sprzęt");
				Console.WriteLine("4 - Wyświetl sprzęt");
				Console.WriteLine("5 - Edytuj sprzęt");
				Console.WriteLine("6 - Wypożycz sprzęt");
				Console.WriteLine("7 - Zwróć sprzęt");
				Console.WriteLine("8 - Wyświetl wypożyczenia");
				Console.WriteLine("9 - Usuń klienta");
				Console.WriteLine("10 - Usuń sprzęt");
				Console.WriteLine("0 - Wyjście");
				Console.Write("Wybór: ");

				string wybor = Console.ReadLine();

				if (wybor == "1") menedzerKlientow.DodajKlienta();
				else if (wybor == "2") menedzerKlientow.WyswietlKlientow();
				else if (wybor == "3") menedzerSprzetu.DodajSprzet();
				else if (wybor == "4") menedzerSprzetu.WyswietlSprzety();
				else if (wybor == "5") menedzerSprzetu.EdytujSprzet();
				else if (wybor == "6") menedzerWypozyczen.Wypozycz();
				else if (wybor == "7") menedzerWypozyczen.Zwrot();
				else if (wybor == "8") menedzerWypozyczen.WyswietlWypozyczenia();
				else if (wybor == "9") menedzerKlientow.UsunKlienta();
				else if (wybor == "10") menedzerSprzetu.UsunSprzet();
				else if (wybor == "0") break;
				else Console.WriteLine("Niepoprawny wybór.");
			}
		}
	}
}
