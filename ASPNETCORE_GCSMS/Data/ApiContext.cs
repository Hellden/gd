using ASPNETCORE_GCSMS.Data.DbModels;
using ASPNETCORE_GCSMS.DbModels;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_GCSMS.Areas.Admin.Models;

namespace ASPNETCORE_GCSMS.Data
{
	public class ApiContext : DbContext
	{
		public	ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{

		}
		public virtual DbSet<Post> GCSMS_Posts { get; set; }
		public virtual DbSet<User> GCSMS_Users  { get; set; }
		public virtual DbSet<Etablissement> GCSMS_Etablissement { get; set; }
		public virtual DbSet<Formation> GCSMS_Formation { get; set; }
	}
}
