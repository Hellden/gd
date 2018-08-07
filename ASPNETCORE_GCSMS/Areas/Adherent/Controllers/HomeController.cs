using ASPNETCORE_GCSMS.Areas.Adherent.Models;
using ASPNETCORE_GCSMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPNETCORE_GCSMS.Areas.Adherent.Controllers
{
	[Authorize]
	[Area("Adherent")]
	public class HomeController : Controller
	{
		private readonly ApiContext _context;

		public HomeController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}