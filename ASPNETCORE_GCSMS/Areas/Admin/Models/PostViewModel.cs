using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE_GCSMS.Areas.Admin.Models
{
	public class PostViewModel
	{
		public int Id { get; set; }
		public string UserID { get; set; }

		[Required(ErrorMessage = "Merci d'indiquer un contenu")]
		public string Content { get; set; }
	}
}
