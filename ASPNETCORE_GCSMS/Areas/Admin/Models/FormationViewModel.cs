namespace ASPNETCORE_GCSMS.Areas.Admin.Models
{
	public class FormationViewModel
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public string Categorie { get; set; }
		public int Position { get; set; }
		//The position:
		//1: Description, principal page Formation 
		//2: Content Formation
		//3: Modal Content Formation
	}
}
