using CiteMe.Application.Contracts;
using CiteMe.Application.Services;
using CiteMe.Domain;
using CiteMe.Models;
using CiteMe.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CiteMe.Web.Controllers
{
    public class CitesController : Controller
    {
        private readonly ICitesServices _citesServices;

        public CitesController(ICitesServices citesServices)
        {
            _citesServices = citesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var citesDb = await _context.Cites.ToListAsync();
            var citesDb = await _citesServices.GetAll();

            return View(citesDb);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var citesDb = await _citesServices.Get(id);
            return View(citesDb);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var citesDb = await _citesServices.Get(id);
            return View(citesDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CitesModel model)
        {
            //_context.Cites.Remove(model);
            //_context.SaveChanges();
            //return View();
            //return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
            var state = await _citesServices.Remove(model);
            if (state)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "¡Ooops! Error Seving...";
                return View(model);
            }
        }
    }
}
