using System;
using System.Collections.Generic;


namespace płyty
{
    class Utwor
    {
        public string Tytuł { get; }
        public TimeSpan CzasTrwania { get; }
        public List<string> Wykonawcy { get; } = new List<string>();
        public string Kompozytor { get; }

        public Utwor(string tytuł, TimeSpan czasTrwania, string kompozytor, string wykonawca)
        {
            Tytuł = tytuł;
            CzasTrwania = czasTrwania;
            Kompozytor = kompozytor;
            Wykonawcy.Add(wykonawca);

        }
    }
}
