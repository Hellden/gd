using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE_GCSMS.Areas.Admin.Models
{
	public class EtablissementViewModel
	{
		public int Id { get; set; }
		public string Nom { get; set; }
		[Display(Name = "Hébergement Permanent")]
		public int? Ehpad { get; set; }
		public int? Pasa { get; set; }
		public int? Usa { get; set; }
		public int? Uhr { get; set; }
		public int? Fam { get; set; }
		public int? Fah { get; set; }
		[Display(Name = "Hébergement Temporaire")]
		public int? Temporaire { get; set; }
		public int? Jour { get; set; }
		[Display(Name = "Foyer de Vie")]
		public int? Foyer { get; set; }
		public string IframeGoogle { get; set; }

		public string StatusMessage { get; set; }
	}
}
