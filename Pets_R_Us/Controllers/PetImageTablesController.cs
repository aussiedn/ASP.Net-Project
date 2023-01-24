using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets_R_Us.Data;
using Pets_R_Us.Models;

namespace Pets_R_Us.Controllers
{
    public class PetImageTablesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public PetImageTablesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: PetImageTables
        public async Task<IActionResult> Index()
        {
            var petImagesTables = mapper.Map<List<PetImageTablesVM>>(await _context.PetImageTables.ToListAsync());

            return View(petImagesTables);
        }

        // GET: PetImageTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PetImageTables == null)
            {
                return NotFound();
            }

            var petImageTable = await _context.PetImageTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petImageTable == null)
            {
                return NotFound();
            }

            return View(petImageTable);
        }

        // GET: PetImageTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetImageTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetImageTablesVM petImageTablesVM)
        {
            if (ModelState.IsValid)
            {
                var petImageTables = mapper.Map<PetImageTable>(petImageTablesVM);
                _context.Add(petImageTables);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petImageTablesVM);
        }

        // GET: PetImageTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PetImageTables == null)
            {
                return NotFound();
            }

            var petImageTable = await _context.PetImageTables.FindAsync(id);
            if (petImageTable == null)
            {
                return NotFound();
            }

            var petImageTableVM = mapper.Map<PetImageTablesVM>(petImageTable);
            return View(petImageTableVM);
        }

        // POST: PetImageTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetImageTablesVM petImageTablesVM)
        {
            if (id != petImageTablesVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var petImageTables = mapper.Map<PetImageTable>(petImageTablesVM);
                    _context.Update(petImageTables);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetImageTableExists(petImageTablesVM.Id))
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
            return View(petImageTablesVM);
        }

        // GET: PetImageTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PetImageTables == null)
            {
                return NotFound();
            }

            var petImageTable = await _context.PetImageTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petImageTable == null)
            {
                return NotFound();
            }

            return View(petImageTable);
        }

        // POST: PetImageTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PetImageTables == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PetImageTables'  is null.");
            }
            var petImageTable = await _context.PetImageTables.FindAsync(id);
            if (petImageTable != null)
            {
                _context.PetImageTables.Remove(petImageTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetImageTableExists(int id)
        {
            return _context.PetImageTables.Any(e => e.Id == id);
        }
    }
}
