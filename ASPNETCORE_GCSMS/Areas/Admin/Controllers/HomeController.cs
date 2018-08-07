using ASPNETCORE_GCSMS.Areas.Admin.Models;
using ASPNETCORE_GCSMS.Data;
using ASPNETCORE_GCSMS.Data.DbModels;
using ASPNETCORE_GCSMS.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNETCORE_GCSMS.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	public class HomeController : Controller
	{
		//Déclare DataContext:Apicontext
		private readonly ApiContext _context;
		public HomeController(
			ApiContext context
			)
		{
			_context = context;
		}


		public IActionResult Index()
		{
			return View();
		}

		#region Posts
		[HttpGet]
		public IActionResult Posts(PostViewModel vm, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			//Read database for display in the post page.
			var sqlPosts = (from article in _context.GCSMS_Posts
							from utilisateur in _context.GCSMS_Users
							select new PostViewModel
							{
								Content = article.Content,
								Id = article.ID
							}).ToList();
			ViewData["listPost"] = sqlPosts;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Posts([Bind("Content,UserId")] Post article, PostViewModel vm, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			try
			{
				if (ModelState.IsValid)
				{
					//Recovery new Post
					article.Content = vm.Content;
					//article.UserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

					_context.Add(article);
					await _context.SaveChangesAsync();
				}
				else
				{
					ModelState.AddModelError("", "Un contenu est nécessaire !");
				}
			}
			catch (Exception ex)
			{
				ViewData["Erreur"] = ex.Message;
			}

			return RedirectToAction("Posts", "Admin");
		}

		[HttpGet]
		public IActionResult EditPosts(int Id)
		{
			//Retrieval Id of the Post selected.
			var post = _context.GCSMS_Posts.SingleOrDefault(p => p.ID == Id);

			PostViewModel editPost = new PostViewModel
			{
				Content = post.Content
			};

			return View(editPost);
		}

		[HttpPost]
		public async Task<IActionResult> EditPosts(PostViewModel vm)
		{
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				ViewData["Erreur"] = ex.Message;
			}
			return RedirectToAction("Posts", "Admin");
		}

		[HttpGet]
		public IActionResult PlaceLibre()
		{
			var place = _context.GCSMS_Etablissement.Single(p => p.Id == Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value));

			var etab = new EtablissementViewModel
			{
				Id = place.Id,
				Nom = place.Nom,
				Ehpad = place.Ehpad,
				Fah = place.Fah,
				Fam = place.Fam,
				Foyer = place.Foyer,
				IframeGoogle = place.IframeGoogle,
				Jour = place.Jour,
				Pasa = place.Pasa,
				Temporaire = place.Temporaire,
				Uhr = place.Uhr,
				Usa = place.Usa
			};
			return View(etab);
		}

		[HttpPost]
		public async Task<IActionResult> PlaceLibre(EtablissementViewModel vm)
		{
			var etab = _context.GCSMS_Etablissement.Single(p => p.Id == vm.Id);

			try
			{
				//Coresspondance with the table GCSMS_Etablissement.
				etab.Ehpad = vm.Ehpad;
				etab.Fah = vm.Fah;
				etab.Fam = vm.Fam;
				etab.Foyer = vm.Foyer;
				etab.IframeGoogle = vm.IframeGoogle;
				etab.Jour = vm.Jour;
				etab.Pasa = vm.Pasa;
				etab.Temporaire = vm.Temporaire;
				etab.Uhr = vm.Uhr;
				etab.Usa = vm.Usa;

				await _context.SaveChangesAsync();

				return RedirectToAction("PlaceLibre", "Home", new { confirm = "ok" });
			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion

		#region Formation
		public IActionResult Hoteliere()
		{
			var query = (from x in _context.GCSMS_Formation
						 where x.Categorie == "Hoteliere"
						 select new FormationViewModel
						 {
							 Content = x.Content,
							 Position = x.Position
						 }).ToList();

			return View(query);

		}

		[HttpGet]
		public IActionResult EditeServiceHoteliere()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Hoteliere" && x.Position == 1);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeServiceHoteliere(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 1);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Hoteliere", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public IActionResult EditeContenuHoteliere()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Hoteliere" && x.Position == 2);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeContenuHoteliere(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 2);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Hoteliere", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		//Ressources Humaines
		public	IActionResult RH()
		{
			var query = (from x in _context.GCSMS_Formation
						 where x.Categorie == "RH"
						 select new FormationViewModel
						 {
							 Content = x.Content,
							 Position = x.Position
						 }).ToList();

			return View(query);
		}

		[HttpGet]
		public IActionResult EditeServiceRH()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "RH" && x.Position == 1);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeServiceRH(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 1);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("RH", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public IActionResult EditeContenuRH()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "RH" && x.Position == 2);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeContenuRH(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 2);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("RH", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		//Informatique
		public IActionResult Informatique()
		{
			var query = (from x in _context.GCSMS_Formation
						 where x.Categorie == "Informatique"
						 select new FormationViewModel
						 {
							 Content = x.Content,
							 Position = x.Position
						 }).ToList();

			return View(query);
		}

		[HttpGet]
		public IActionResult EditeServiceInformatique()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Informatique" && x.Position == 1);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeServiceInformatique(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 1);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Informatique", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public IActionResult EditeContenuInformatique()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Informatique" && x.Position == 2);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeContenuInformatique(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 2);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Informatique", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		//Ethique
		public IActionResult Ethique()
		{
			var query = (from x in _context.GCSMS_Formation
						 where x.Categorie == "Ethique"
						 select new FormationViewModel
						 {
							 Content = x.Content,
							 Position = x.Position
						 }).ToList();

			return View(query);
		}

		[HttpGet]
		public IActionResult EditeServiceEthique()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Ethique" && x.Position == 1);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeServiceEthique(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 1);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Ethique", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public IActionResult EditeContenuEthique()
		{
			var query = _context.GCSMS_Formation.SingleOrDefault(x => x.Categorie == "Ethique" && x.Position == 2);
			var requet = new FormationViewModel
			{
				Content = query.Content,
				Id = query.Id
			};
			return View(requet);
		}

		[HttpPost]
		public async Task<IActionResult> EditeContenuEthique(FormationViewModel vm)
		{
			var form = _context.GCSMS_Formation.Single(p => p.Id == vm.Id && p.Position == 2);

			try
			{
				form.Content = vm.Content;

				await _context.SaveChangesAsync();
				return RedirectToAction("Ethique", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion

		#region Utilisateur
		[HttpGet]
		public IActionResult Utilisateur()
		{
			//Test Role Users Superadmin
			if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "SuperAdmin")
			{
				//Display all Users in the GCSMS_Users database
				var sql = (from Util in _context.GCSMS_Users
						   join Etab in _context.GCSMS_Etablissement
						   on Util.EtablissementId equals Etab.Id
						   select new UtilisateurViewModel
						   {
							   Etablissement = Etab.Nom,
							   Role = Util.Role,
							   Username = Util.Username
						   }).ToList();
				return View(sql);
			}
			//Test Role Users Superadmin
			else if (User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value == "Administrateur")
			{
				//View users by membership of the institution.
				var sql = (from Util in _context.GCSMS_Users
						   join Etab in _context.GCSMS_Etablissement
						   on Util.EtablissementId equals Etab.Id
						   where Util.EtablissementId == Convert.ToInt32(User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Country).Value)
						   select new UtilisateurViewModel
						   {
							   Etablissement = Etab.Nom,
							   Role = Util.Role,
							   Username = Util.Username
						   }).ToList();
				return View(sql);
			}
			return View();
		}

		[HttpGet]
		public IActionResult NouvelleUtilisateur()
		{
			return View();
		}

		[HttpPost]
		public IActionResult NouvelleUtilisateur([Bind("Etablissement,Username,Password,Role")] User dbUser, UtilisateurViewModel vm)
		{
			try
			{
				if (vm.Etablissement == null)
				{
					dbUser.EtablissementId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Country).Value);
				}
				else
				{
					dbUser.EtablissementId = Convert.ToInt32(vm.Etablissement);
				}
				dbUser.Username = vm.Username;
				dbUser.Password = vm.Password;
				dbUser.Role = vm.Role;

				_context.GCSMS_Users.Add(dbUser);
				_context.SaveChanges();

				return RedirectToAction("Utilisateur", "Home", new { confirm = "ok" });

			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion
	}
}