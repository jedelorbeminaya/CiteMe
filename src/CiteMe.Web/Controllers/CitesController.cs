using CiteMe.Domain;
using CiteMe.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CiteMe.Web.Controllers
{
    public class CitesController : Controller
    {
        private readonly DataContext _context;
        public CitesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var citesDb = await _context.Cites.ToListAsync();
            return View(citesDb);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var citesDb = _context.Cites.Find(id);
            return View(citesDb);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var citesDb = _context.Cites.Find(id);
            return View(citesDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Cites model)
        {
         
            _context.Cites.Remove(model);
            _context.SaveChanges();
            //return View();
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
        }
    }
}
