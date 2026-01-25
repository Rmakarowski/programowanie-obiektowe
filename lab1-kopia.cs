// // ZAD 1 program obliczający wyróżnik delta i pierwiastki trójmianu kwadratowego
// using System;

// class Program
// {
//     static void Main()
//     {
//         // Wywołanie metody rozwiązującej zadanie
//         ObliczTrojmian();
//     }

//     // Metoda obliczająca deltę i pierwiastki trójmianu kwadratowego
//     static void ObliczTrojmian()
//     {
//         int a = 1;
//         int b = 5;
//         int c = 6;

//         // Obliczenie wyróżnika (delta)
//         int delta = (b * b) - (4 * a * c);

//         if (delta > 0)
//         {
//             double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
//             double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

//             Console.WriteLine("x1 jest równe = " + x1);
//             Console.WriteLine("x2 jest równe = " + x2);
//         }
//         else if (delta == 0)
//         {
//             double x0 = (-b) / (2 * a);
//             Console.WriteLine("x0 jest równe = " + x0);
//         }
//         else
//         {
//             Console.WriteLine("Brak rzeczywistych pierwiastków");
//         }
//     }
// }


// Zad 2 Napisz program umożliwiający wprowadzanie 10-ciu liczb. Dla wprowadzonych liczb wykonaj odpowiednie algorytmy:
// -oblicz sumę elementów tablicy,
// -oblicz iloczyn elementów tablicy,
// -wyznacz wartość średnią,
// -wyznacz wartość minimalną,
// -wyznacz wartość maksymalną.

// using System;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         // Wywołanie metody realizującej całe zadanie
//         ObliczTablice();
//     }

//     // Metoda realizująca zadanie z tablicą
//     static void ObliczTablice()
//     {
//         int[] tab = new int[10];

//         // Wprowadzanie liczb do tablicy
//         for (int i = 0; i < 10; i++)
//         {
//             Console.WriteLine("Podaj liczbę {0}: ", i + 1);
//             tab[i] = Convert.ToInt32(Console.ReadLine());
//         }

//         // Obliczanie sumy
//         int suma = 0;
//         for (int i = 0; i < 10; i++)
//         {
//             suma = suma + tab[i];
//         }
//         Console.WriteLine("Suma elementów to: " + suma);

//         // Obliczanie iloczynu
//         int iloczyn = 1;
//         for (int i = 0; i < 10; i++)
//         {
//             iloczyn = iloczyn * tab[i];
//         }
//         Console.WriteLine("Iloczyn elementów tablicy to: " + iloczyn);

//         // Wyznaczanie wartości minimalnej i maksymalnej
//         int max = tab.Max();
//         int min = tab.Min();

//         Console.WriteLine("Maksymalna liczba to: " + max + 
//                           " Minimalna liczba to: " + min);
//     }
// }


// Zad 3 Napisz program wyświetlający liczby od 20-0, z wyłączeniem liczb {2,6,9,15,19}. Do realizacji
// zadania wyłączenia użyj instrukcji continue;

// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.WriteLine("Podaj liczbę początkową:");
//         int n = int.Parse(Console.ReadLine());
//         WyswietlLiczby(n);
//     }

//     // Metoda wyświetlająca liczby od n do 0 z pominięciem wybranych
//     static void WyswietlLiczby(int n)
//     {
//         for (int i = n; i >= 0; i--)
//         {
//             if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
//             {
//                 continue;
//             }
//             Console.WriteLine("Liczby to: " + i);
//         }
//     }
// }




//Zad 4 Napisz program, który w nieskończoność pyta użytkownika o liczby całkowite. Pętla
//nieskończona powinna się zakończyć gdy użytkownik wprowadzi liczbę mniejszą od zera. Do
//opuszczenia pętli nieskończonej użyj instrukcji break. Pętle nieskończoną realizuje się
//następującymi konstrukcjami:
//while (true)
//{ ciało pętli }
//lub
//for(;;)
// { ciało pętli }

// using System;

// class Program
// {
//     static void Main()
//     {
//         // Wywołanie metody realizującej pętlę nieskończoną
//         PetlaNieskonczona();
//     }

//     // Metoda realizująca pętlę nieskończoną z instrukcją break
//     static void PetlaNieskonczona()
//     {
//         for (int i = 0; i >= 0; i++)
//         {
//             Console.WriteLine("Podaj liczbę całkowitą: ");
//             int x = Convert.ToInt32(Console.ReadLine());

//             if (x < 0)
//             {
//                 Console.WriteLine("Podałeś liczbę mniejszą od zera");
//                 break;
//             }
//         }
//     }
// }


//Zad 5 Napisz program umożliwiający wprowadzanie n liczb oraz sortujący te liczby metodą
//bąbelkową lub wstawiania. Wyniki wyświetlaj na konsoli.

// using System;

// class Program
// {
//     static void Main()
//     {
//         // Wywołanie metody sortującym liczby
//         SortowanieLiczb();
//     }

//     // Metoda wczytująca liczby i sortująca je metodą bąbelkową
//     static void SortowanieLiczb()
//     {
//         Console.Write("Podaj ilość liczb: ");
//         int n = int.Parse(Console.ReadLine());

//         int[] tab = new int[n];

//         // Wczytywanie liczb do tablicy
//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Podaj liczbę {i + 1}: ");
//             tab[i] = int.Parse(Console.ReadLine());
//         }

//         // Sortowanie bąbelkowe
//         for (int i = 0; i < n - 1; i++)
//         {
//             for (int j = 0; j < n - i - 1; j++)
//             {
//                 if (tab[j] > tab[j + 1])
//                 {
//                     int temp = tab[j];
//                     tab[j] = tab[j + 1];
//                     tab[j + 1] = temp;
//                 }
//             }
//         }

//         // Wyświetlenie posortowanych liczb
//         Console.WriteLine("Posortowane liczby (rosnąco):");
//         foreach (int liczba in tab)
//         {
//             Console.WriteLine(liczba);
//         }
//     }
// }
