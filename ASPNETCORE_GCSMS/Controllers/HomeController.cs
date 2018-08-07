using ASPNETCORE_GCSMS.Data;
using ASPNETCORE_GCSMS.Data.DbModels;
using ASPNETCORE_GCSMS.Models;
using ASPNETCORE_GCSMS.Models.HomeViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASPNETCORE_GCSMS.Controllers
{
	public class HomeController : Controller
	{

		private readonly ApiContext _context;

		public HomeController(ApiContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region Slide
		public IActionResult Valeurs()
		{
			return View();
		}

		public IActionResult EtablissementAdherents()
		{
			return View();
		}

		public IActionResult Actions()
		{
			return View();
		}
		#endregion

		#region Nav
		[TempData]
		public string StatusMessage { get; set; }

		[HttpGet]
		public IActionResult ModalContact()
		{
			return View();
		}

		//Method asynchrone to avoid blocking a thread on sending mail.
		[HttpPost]
		public async Task<IActionResult> ModalContact(ModalTicketViewModel model)
		{
			//Create instance Mail.
			MailMessage email = new MailMessage()
			{
				//Create Mail.
				From = new MailAddress("siteweb@gepy89.fr")
			};
			email.To.Add(new MailAddress("fonction-formation@gepy89.fr"));
			email.Subject = "Contact Site Web du GEPY";
			email.IsBodyHtml = true;
			email.Body = "<html>"
							+ "<body>"
								+ "<p><b>Contact via le formulaire du site WEB du G.E.P.Y</b></p>"
								+ "<p><b>Nom:</b>" + model.Nom + "</p>"
								+ "<p><b>Message:</b> </br>" + model.Message + "</p>"
							+ "</body>"
						+ "</html>";


			//Create profil smtp.
			SmtpClient smtp = new SmtpClient()
			{
				Host = "smtp.orange.fr",
				Credentials = new System.Net.NetworkCredential("maisonretraite.courson@orange.fr", "77ctkcq")
			};

			try
			{
				await smtp.SendMailAsync(email);
				StatusMessage = "Votre message à bien été envoyé.";
			}
			catch (SmtpException)
			{
				throw new ApplicationException(message: "Erreur de l'envoie du message.");
			}
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Formations()
		{
			var bdd = from x in _context.GCSMS_Formation
					  where x.Position == 1
					  select new FormationViewModel
					  {
						  Categorie = x.Categorie,
						  Content = x.Content
					  };
			return View(bdd);
		}

		public IActionResult Projets()
		{
			//Validation message to the Index view throug the Model ModalTicketViewModel
			return View();
		}

		public IActionResult Hoteliere()
		{
			var query = _context.GCSMS_Formation.Single(x => x.Categorie == "Hoteliere" && x.Position == 2);
			var form = new FormationViewModel()
			{
				Content = query.Content
			};
			return View(form);
		}

		public IActionResult RH()
		{
			var quey = _context.GCSMS_Formation.Single(x => x.Categorie == "RH" && x.Position == 2);
			var form = new FormationViewModel()
			{
				Content = quey.Content
			};
			return View(form);
		}

		public IActionResult Informatique()
		{
			var quey = _context.GCSMS_Formation.Single(x => x.Categorie == "Informatique" && x.Position == 2);
			var form = new FormationViewModel()
			{
				Content = quey.Content
			};
			return View(form);
		}

		public IActionResult Ethique()
		{
			var quey = _context.GCSMS_Formation.Single(x => x.Categorie == "Ethique" && x.Position == 2);
			var form = new FormationViewModel()
			{
				Content = quey.Content
			};
			return View(form);
		}

		[HttpGet]
		public IActionResult PlaceLibre()
		{
			var etablissement = new Etablissement();
			//Add default user if not exist, by default user:rchapotin
			//if (!_context.GCSMS_Etablissement.Any())
			//{
			//	etablissement.Nom ="Ancy le Franc Ehpad \"Résidence les Fontenottes\"";
			//	etablissement.Ehpad = 2;


			//	_context.Add(etablissement);
			//	_context.SaveChanges();
			//}
			var sql = (from etab in _context.GCSMS_Etablissement
					  select new EtablissementViewModel
					  {
						  Id = etab.Id,
						  Nom = etab.Nom,
						  Ehpad = etab.Ehpad,
						  Fah = etab.Fah,
						  Fam = etab.Fam,
						  Foyer = etab.Foyer,
						  IframeGoogle = etab.IframeGoogle,
						  Jour = etab.Jour,
						  Pasa = etab.Pasa,
						  Temporaire = etab.Temporaire,
						  Uhr = etab.Uhr,
						  Usa = etab.Usa
					  }).ToList();
			return View(sql);
		}

		#endregion

		public IActionResult MentionLegal()
		{
			return View();
		}

		public IActionResult Politique()
		{
			return View();
		}
	}
}
