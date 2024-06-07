using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectT1.Datos;
using ProjectT1.Models;

namespace ProjectT1.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            if (_context.Vehiculo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehiculo'  is null.");
            }

            var vehiculos = await _context.Vehiculo
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .ToListAsync();

            return View(vehiculos);
        }


        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewBag.Marcas = new SelectList(_context.Marca, "IdMarca", "NomMarca");
            ViewBag.Modelos = new SelectList(_context.Modelo, "IdModelo", "NomModelo");
            
            // Obtén las marcas desde la base de datos
            var marcas = _context.Marca.ToList();

            // Pasa las marcas a la vista usando ViewBag
            ViewBag.Marcas = new SelectList(marcas, "IdMarca", "NomMarca");

            return View();
        }
        // POST: Vehiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,NroPlaca,IdModelo,Anio,Color,EstPer")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculo.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Obtén las marcas desde la base de datos
            var marcas = _context.Marca.ToList();

            // Pasa las marcas a la vista usando ViewBag
            ViewBag.Marcas = new SelectList(marcas, "IdMarca", "NomMarca");

            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,NroPlaca,IdModelo,Anio,Color,EstPer")] Vehiculo vehiculo)
        {
            if (id != vehiculo.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.IdVehiculo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Vehiculo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehiculo'  is null.");
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculo.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
          return (_context.Vehiculo?.Any(e => e.IdVehiculo == id)).GetValueOrDefault();
        }

        [HttpGet]
        public JsonResult ObtenerModelos(int idMarca)
        {
            var modelos = _context.Modelo
                .Where(m => m.MarcaId == idMarca)
                .Select(m => new { idModelo = m.IdModelo, nomModelo = m.NomModelo })
                .ToList();
            return Json(modelos);
        }


        


    }
}
