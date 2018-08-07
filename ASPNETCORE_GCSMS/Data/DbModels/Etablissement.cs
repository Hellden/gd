using System.Collections.Generic;

namespace ASPNETCORE_GCSMS.Data.DbModels
{
    public class Etablissement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? Ehpad { get; set; }
        public int? Pasa { get; set; }
        public int? Usa { get; set; }
        public int? Uhr { get; set; }
        public int? Fam { get; set; }
        public int? Fah { get; set; }
        public int? Temporaire { get; set; }
        public int? Jour { get; set; }
        public int? Foyer { get; set; }
        public string IframeGoogle { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
