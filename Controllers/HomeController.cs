using AppMVC.Controllers.Data;
using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public HomeController(ApplicationDbContext contexto)
        {
            _contexto=contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Login.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Login login)
        {
            if(ModelState.IsValid)
            {
                _contexto.Login.Add(login);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index"); 
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = _contexto.Login.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Login login)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(login);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = _contexto.Login.Find(id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarLogin(int? id)
        {
            var login = await _contexto.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }
                _contexto.Login.Remove(login);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            
            
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