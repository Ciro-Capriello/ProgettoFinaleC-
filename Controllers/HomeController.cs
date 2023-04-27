using Microsoft.AspNetCore.Mvc;
using ProgettoFinaleC_.Filters;
using ProgettoFinaleC_.Models;
using ProgettoFinaleC_.Models.DB;
using System.Diagnostics;

namespace ProgettoFinaleC_.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[HttpPost]
		public IActionResult Login(User user)
		{
			var log = Database.Login(user.UserName, user.Password);
			if (log != "0")
			{
				HttpContext.Session.SetString("LogSession", log);
			}
			else
			{
				HttpContext.Session.Remove("LogSession");
				return RedirectToAction("Login", new { showerror = false});
			}
			return RedirectToAction("Index");
		}
		[Route("Home/Login/{showerror=false}")]
		public IActionResult Login(bool showerror)
		{
			if (HttpContext.Session.Get("LogSession") == true)
			{

			}
			return View(new LoginUser(showerror));
		}
		public IActionResult Index()
		{
			return View();
			//Database.GetList()
		}
		[AuthFilter]
		public IActionResult Detail(int id)
		{
			//var p = Database.GetPhone(id);
			return View(/*p*/);

		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}