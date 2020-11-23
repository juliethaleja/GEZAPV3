using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GEZAPV3.Models;

namespace GEZAPV3.Controllers
{
    public class PersonasController : Controller
    {
        private readonly DataBaseProyectoContext _context;

        public PersonasController(DataBaseProyectoContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var dataBaseProyectoContext = _context.Personas.Include(p => p.IdTipoPNavigation).Include(p => p.IdUsersNavigation);
            return View(await dataBaseProyectoContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdTipoPNavigation)
                .Include(p => p.IdUsersNavigation)
                .FirstOrDefaultAsync(m => m.DIdentidad == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoP"] = new SelectList(_context.TipoPersonas, "IdTipoP", "NombreP");
            ViewData["IdUsers"] = new SelectList(_context.Users, "IdUsers", "Contraseña");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DIdentidad,IdTipoP,IdUsers,PNombre,SNombre,PApellido,SApellido,TipoD,FNacimiento,Sexo,Telefono,CElectronico,Direccion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoP"] = new SelectList(_context.TipoPersonas, "IdTipoP", "NombreP", persona.IdTipoP);
            ViewData["IdUsers"] = new SelectList(_context.Users, "IdUsers", "Contraseña", persona.IdUsers);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["IdTipoP"] = new SelectList(_context.TipoPersonas, "IdTipoP", "NombreP", persona.IdTipoP);
            ViewData["IdUsers"] = new SelectList(_context.Users, "IdUsers", "Contraseña", persona.IdUsers);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DIdentidad,IdTipoP,IdUsers,PNombre,SNombre,PApellido,SApellido,TipoD,FNacimiento,Sexo,Telefono,CElectronico,Direccion")] Persona persona)
        {
            if (id != persona.DIdentidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.DIdentidad))
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
            ViewData["IdTipoP"] = new SelectList(_context.TipoPersonas, "IdTipoP", "NombreP", persona.IdTipoP);
            ViewData["IdUsers"] = new SelectList(_context.Users, "IdUsers", "Contraseña", persona.IdUsers);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdTipoPNavigation)
                .Include(p => p.IdUsersNavigation)
                .FirstOrDefaultAsync(m => m.DIdentidad == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.DIdentidad == id);
        }
    }
}
