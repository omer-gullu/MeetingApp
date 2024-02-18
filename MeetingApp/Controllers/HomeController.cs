using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeetingApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			int saat = DateTime.Now.Hour;
            ViewBag.selamlama = saat < 18 ? "İyi Günler" : "İyi Akşamlar" ;
			ViewBag.karsilama = ViewBag.selamlama + " " + ViewBag.userName;

			var meetingInfo = new MeetingInfo()
			{
				Id = 1,
				Location = "İstanbul, ABC Kongre Merkezi",
				Date = new DateTime(2024,01,20,20,0,0),
				NumberOfPeople = 100,
				
			};
			
			return View(meetingInfo);
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
