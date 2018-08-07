using ASPNETCORE_GCSMS.DbModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCORE_GCSMS.Data.DbModels
{
	public class User
	{
		public int Id { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }

		public int? EtablissementId { get; set; }

		public virtual ICollection<Post> Posts { get; set; }
	}
}
