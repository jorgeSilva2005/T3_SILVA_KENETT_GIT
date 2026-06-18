using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T3_SILVA_KENETT.Data;
using T3_SILVA_KENETT.Models;

namespace T3_SILVA_KENETT.Controllers
{
    [Authorize]
    public class LibroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros.ToListAsync();
            return View(libros);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);

            if (libro == null) return NotFound();

            return View(libro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Tema,Editorial,AnioPublicacion,Paginas,Categoria,Material,Copias")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Libro registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(libro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var libro = await _context.Libros.FindAsync(id);

            if (libro == null) return NotFound();

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Autor,Tema,Editorial,AnioPublicacion,Paginas,Categoria,Material,Copias")] Libro libro)
        {
            if (id != libro.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();

                    TempData["Mensaje"] = "Libro actualizado correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(libro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.Id == id);

            if (libro == null) return NotFound();

            return View(libro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Libro eliminado correctamente.";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}