using ASPNETCORE_GCSMS.Areas.Account.Models;
using ASPNETCORE_GCSMS.Data;
using ASPNETCORE_GCSMS.Data.DbModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNETCORE_GCSMS.Areas.Account.Controllers
{
	[Authorize]
	[Area("Account")]
	public class HomeController : Controller
	{
		private readonly ApiContext _context;

		private int IdUtilisateur;
		private int EtablissementId;
		private string RoleUtilisateur;

		public HomeController(ApiContext context)
		{
			_context = context;
		}
		
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Login([Bind("Username,Password,Role")] User utilisateur, string returnUrl = null)
		{
			//Add default user if not exist, by default user:rchapotin
			if (!_context.GCSMS_Users.Any())
			{
				utilisateur.Username = "rchapotin";
				utilisateur.Password = "raphael";
				utilisateur.Role = "SuperAdmin";

				_context.Add(utilisateur);
				await _context.SaveChangesAsync();
			}			

			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}
		

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (ModelState.IsValid)
			{
				if (LoginUser(vm.Login, vm.Password))
				{
					//Read the DB for User = Login

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, vm.Login),
						new Claim(ClaimTypes.NameIdentifier, IdUtilisateur.ToString() ),
						new Claim(ClaimTypes.Country, EtablissementId.ToString()),
						new Claim(ClaimTypes.Role, RoleUtilisateur)
					};
	
					var userIdentity = new ClaimsIdentity(claims, "login");

					ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
					await HttpContext.SignInAsync(principal, new AuthenticationProperties {
						IsPersistent = true
					});

					//Just redirect to our index after logging in. 
					return RedirectToAction("Index","Home",new { Area  = "Adherent" });
				}
				else
				{
					ModelState.AddModelError("user", "Le nom d'utilisateur ou le mot de passe n'est pas valide !");
					return View();
				}
			}
			return View(vm);
		}


		//vérification Utilisateur.
		private bool LoginUser(string Username, string password)
		{
			//Vérif user in the la database Users.
			foreach (var item in _context.GCSMS_Users)
			{
				if (item.Username == Username && item.Password == password)
				{
					IdUtilisateur = item.Id;
					EtablissementId = Convert.ToInt32(item.EtablissementId);
					RoleUtilisateur = item.Role;
					return true;
				}
			}
			return false;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return base.RedirectToAction("Index", "Home", new { Area = "" });
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
}