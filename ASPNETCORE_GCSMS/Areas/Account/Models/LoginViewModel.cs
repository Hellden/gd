using System.ComponentModel.DataAnnotations;

namespace ASPNETCORE_GCSMS.Areas.Account.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Un login doit être saisie.")]
		public string Login { get; set; }

		[Display(Name = "Se souvenir de moi ?")]
		public bool RememberMe { get; set; }

		[Required(ErrorMessage = "Un mot de passe est nécessaire.")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
