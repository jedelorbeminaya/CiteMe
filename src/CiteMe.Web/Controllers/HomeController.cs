using CiteMe.Application.Contracts;
using CiteMe.Application.Services;
using CiteMe.Domain;
using CiteMe.Models;
using CiteMe.Persistence;
using CiteMe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CiteMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICitesServices _citesServices;

        public HomeController(ILogger<HomeController> logger, ICitesServices citesServices)
        {
            _logger = logger;
            _citesServices = citesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CitesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //_context.Cites.Add(model);
            //_context.SaveChanges();
            //return View();
            //return RedirectToAction("Index");
            var state = _citesServices.Create(model);
            if (state)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Error = "¡Ooops! Error Seving...";
                return View(model);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
