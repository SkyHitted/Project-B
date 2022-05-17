using System.Collections.Generic;

namespace projectBGroep3
{
    class MenuClass
    {
        public string keukenNaam { get; set; }
        public List<MenuGerechten> ontbijt { get; set; }
        public List<MenuGerechten> lunch { get; set; }
        public List<MenuGerechten> avondeten { get; set; }
        public List<MenuGerechten> desert { get; set; }

    }
    class MenuGerechten
    {
        public string naamGerecht { get; set; }
        public double prijsGerecht { get; set; }
        public string allergieGerecht { get; set; }

    }
    class NewKeuken
    {
        public List<MenuClass> Menu { get; set; }
    }
}

