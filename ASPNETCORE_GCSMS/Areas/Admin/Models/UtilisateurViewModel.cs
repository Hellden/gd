using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_GCSMS.Areas.Admin.Models
{
	public class UtilisateurViewModel
	{
		public int Id { get; set; }
		[Required]
		public string Etablissement { get; set; }
		[Required]
		[Display(Name ="Utilisateur")]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

		[Display(Name = "Rôle")]
		public string Role { get; set; }
	}
}