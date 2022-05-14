using System;
using System.Collections.Generic;
using System.Linq;


namespace płyty
{

    class Plyta
    {        
        public string Tytul { get; }
        public string Typ { get; }
        public TimeSpan CzasTrwania
        {
            get
            {
                TimeSpan czasSuma = TimeSpan.Zero;
                foreach (Utwor utwor in Utwory)
                {
                    //Add
                    czasSuma += utwor.CzasTrwania;
                }

                return czasSuma;
            }
        }
        public List<Utwor> Utwory { get; } = new List<Utwor>();
        public List<string> Wykonawcy
        {
            get
            {
                List<string> wynikowaLista = new List<string>();
                foreach (Utwor utwor in Utwory)
                {
                    wynikowaLista.AddRange(utwor.Wykonawcy);
                }


                return wynikowaLista.Distinct().ToList();
            }
        }

        public int NumerPłyty { get; }

        public Plyta(string tytulPłyty, string typPłyty, int numerPłyty, List<Utwor> utwory)
        {
            Tytul = tytulPłyty;
            Typ = typPłyty;
            NumerPłyty = numerPłyty;
            Utwory.AddRange(utwory);
        }
        public Plyta(string tytulPłyty, string typPłyty, int numerPłyty)
        {
            Tytul = tytulPłyty;
            Typ = typPłyty;
            NumerPłyty = numerPłyty;
        }
       
    }

}
