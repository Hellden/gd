using System.ComponentModel.DataAnnotations;


namespace ASPNETCORE_GCSMS.Models
{
	public class ModalTicketViewModel
	{

		[Display(Name = "Nom et Prénom")]
		[Required(ErrorMessage = "Un Nom doit être saisie")]
		public string Nom { get; set; }


		[EmailAddress(ErrorMessage = "Le mail est incorrect")]
		[Required(ErrorMessage = "L'email est requis")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Un message est requis.")]
		public string Message { get; set; }

		public string StatusMessage { get; set; }
	}
}