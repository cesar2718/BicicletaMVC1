using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bicicletaMVC.Data;
using bicicletaMVC.Models;

namespace bicicletaMVC.Controllers
{
    public class BicicletaController : Controller
    {
        private readonly bicicletaMVCContext _context;

        public BicicletaController(bicicletaMVCContext context)
        {
            _context = context;
        }

        // GET: Bicicleta
        public async Task<IActionResult> Index()

        {
            return View(await _context.Bicicleta.ToListAsync());
        }

        public async Task<IActionResult> IndexCateg(int? id)

        {
            return View(await _context.Bicicleta
                        .Include(c => c.Categoria)
                        .Where(p=> p.CategoriaID == id)    
                        .ToListAsync());
        }

        // GET: Bicicleta/Details/5
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta
                .FirstOrDefaultAsync(m => m.BicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }





        // GET: Bicicleta/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //esto debo cambiar

        public async Task<IActionResult> Create()
        {
            return View(await _context.Bicicleta.ToListAsync());
        }








        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Descripcion,Precio")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicleta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicleta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Descripcion,Precio")] Bicicleta bicicleta)
        {
            if (id != bicicleta.BicicletaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicicletaExists(bicicleta.BicicletaID))
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
            return View(bicicleta);
        }

        // GET: Bicicleta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicleta
                .FirstOrDefaultAsync(m => m.BicicletaID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicleta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicicleta = await _context.Bicicleta.FindAsync(id);
            _context.Bicicleta.Remove(bicicleta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicicletaExists(int id)
        {
            return _context.Bicicleta.Any(e => e.BicicletaID == id);
        }
    }
}
