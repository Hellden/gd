using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_GCSMS.Data.DbModels
{
    public class Formation
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
