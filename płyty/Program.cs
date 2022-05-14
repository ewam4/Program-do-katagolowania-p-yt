using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace płyty
{
    class Program
    {

        static string ZamienNaTekst(Plyta p)
        {
            string wykonawcy = string.Empty;
            foreach (var item in p.Wykonawcy)
            {
                wykonawcy += " " + item;
            }
            
            string output = $"{p.Tytul};{wykonawcy}";



            return output;
        }
        static void Zapisz(List<Plyta> lista)
        {
            //for
            File.WriteAllLines("baza.txt", lista.Select(ZamienNaTekst));
        }
        static Plyta Szukanie(int numerpodany, List<Plyta> lista)
        {
            foreach (var item in lista)
            {
                if (numerpodany == item.NumerPłyty)
                {
                    return item;
                }
            }
            return null;
        }
        static Utwor SzukanieUtworu(string tytulTekst, Plyta plyta)
        {
            foreach (var Utwor in plyta.Utwory)
            {
                if (tytulTekst == Utwor.Tytuł)
                {
                    return Utwor;
                }
            }
            return null;
        }
        static void InfooUtworze(List<Plyta> lista)
        {
            Console.WriteLine("Podaj numer płyty");
            string numerText = Console.ReadLine();
            int numerpodany = int.Parse(numerText);
            Plyta znaleziona = Szukanie(numerpodany, lista);
            Console.WriteLine("Podaj tytuł utworu");
            string tytulText = Console.ReadLine();
            Utwor znaleziony = SzukanieUtworu(tytulText, znaleziona);

            Console.WriteLine("Tytuł utworu '{0}', czas trwania utworu: {1},  kompozytor utworu: {2}", znaleziony.Tytuł, znaleziony.CzasTrwania, znaleziony.Kompozytor);

            for (int i = 0; i < znaleziony.Wykonawcy.Count; i++)
            {
                Console.WriteLine("Wykonawcy: {0} - {1}", i + 1, znaleziony.Wykonawcy[i]);
            }


     
        }
        static void ListaUtworow(Plyta plyta)

        {


            for (int i = 0; i < plyta.Utwory.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, plyta.Utwory[i].Tytuł );
            } 

        }
        static void InfoOWykonawcach(List<Plyta> lista)
        {
            Console.WriteLine("Podaj numer płyty");
            string numerText = Console.ReadLine();
            int numerpodany = int.Parse(numerText);
            Plyta znaleziona = Szukanie(numerpodany, lista);

            for (int i = 0; i < znaleziona.Wykonawcy.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, znaleziona.Wykonawcy[i]);
            }
        }

        static void DodajPlyte(List<Plyta> lista)
        {
            Console.WriteLine("Podaj tytuł płyty");
            string tytulPłyty = Console.ReadLine();
            Console.WriteLine("Podaj typ płyty");
            string typPłyty = Console.ReadLine();
            Console.WriteLine("Podaj numer płyty");
            int numerPłyty = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("Podaj ilość  utworów na płycie");
            int iloscutworow = int.Parse(Console.ReadLine());

            List<Utwor> roboczeutwory = new List<Utwor>();

            for (int i = 0; i < iloscutworow; i++)
            {
                Console.WriteLine("Podaj tytuł pierwszego utworu");
                string tytuł = Console.ReadLine();
                Console.WriteLine("Podaj czas trwania utworu");
                TimeSpan czasTrwania = TimeSpan.Parse(Console.ReadLine());
                Console.WriteLine("Podaj kompozytora");
                string kompozytor = Console.ReadLine();
                Console.WriteLine("Podaj wykonawcę");
                string wykonawca = Console.ReadLine();

                var u0 = new Utwor(tytuł, czasTrwania, kompozytor, wykonawca);
                roboczeutwory.Add(u0);
                lista.Add(new Plyta(tytulPłyty, typPłyty, numerPłyty, roboczeutwory));
            }



            //nie zapisują się płyty

        }
        static void Info(List<Plyta> lista)
        {
            Console.WriteLine("Podaj numer płyty");
            string numerText = Console.ReadLine();
            int numerpodany = int.Parse(numerText);
            Plyta znaleziona = Szukanie(numerpodany, lista);

            Console.WriteLine("Tytuł płyty {0}, Typ płyty {1}, Czas trwania płyty {2}", znaleziona.Tytul, znaleziona.Typ, znaleziona.CzasTrwania);
            Console.WriteLine("Lista utworów:");
            ListaUtworow(znaleziona);

        }

        static void Main(string[] args)
        {
            var lista = new List<Plyta>();
            List<Utwor> roboczeutwory = new List<Utwor>();
            Utwor u1 = new Utwor("Speak to Me/Breathe", new TimeSpan(00, 03, 30), "Gilmour", "Waters");
            Utwor u2 = new Utwor("On the Run", new TimeSpan(00, 04, 46), "Waters", "Mason");
            roboczeutwory.Add(u1);
            roboczeutwory.Add(u2);
            Plyta ob1 = new Plyta("The Dark Side of the Moon", "CD", 1, roboczeutwory);
            lista.Add(ob1);

            int działanie;
            do
            { 
                Console.WriteLine("Program do płyt");
                Console.WriteLine("Aby poznac informacje o płycie wciśnij 1,");
                Console.WriteLine("Aby dodać płytę wciśnij 2,");
                Console.WriteLine("Aby wyświetlić tytuły wszystkich płyt wciśnij 3,");
                Console.WriteLine("Aby wyswietlić wykonawców utworów na wybranej płycie wciśnij 4");
                Console.WriteLine("Aby wyswietlić info o wybranym utworze wciśnij 5");
                Console.WriteLine("Aby zapisać bazę do pliku wciśnij 6");
                Console.WriteLine("Aby odczytać bazę z pliku wciśnij 7");
                Console.WriteLine("Aby zakończyć nacisnij 8");
                                 
                działanie = Convert.ToInt32(Console.ReadLine());
                switch (działanie)
                {
                    case 1:
                        Info(lista);
                        break;
                    case 2:
                        DodajPlyte(lista);
                        break;
                    case 3:
                        foreach (Plyta Płyta in lista)
                        {
                            Console.WriteLine(Płyta.Tytul);
                        }
                        break;
                    case 4:
                        InfoOWykonawcach(lista);
                        break;
                    case 5:
                        InfooUtworze(lista);
                        break;
                    case 6:

                        break;
                }
                
            } while (działanie != 8);

        }
    }
}
//chciałabym dorobić wyjątki i wyłapytanie błędów