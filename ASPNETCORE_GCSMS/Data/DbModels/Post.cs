using ASPNETCORE_GCSMS.Data.DbModels;

namespace ASPNETCORE_GCSMS.DbModels
{
    public class Post
	{
		public int ID { get; set; }
		public string Content { get; set; }

		public virtual User User { get; set; }
	}
}
