using _14530_employes_managment.Data;
using _14530_employes_managment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14530_employes_managment.Controllers
{
    public class InstrumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstrumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Instruments.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments.FirstOrDefaultAsync(m => m.id == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TypeInstrument,InstrumentName,UseStrings")] Instrument instrument)
        {
            instrument.CreatedById = "14530";
            instrument.CreatedOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(instrument);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,TypeInstrument,InstrumentName,UseStrings")] Instrument instrument)
        {
            if (id != instrument.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingInstrument = await _context.Instruments.FindAsync(id);
                if (existingInstrument == null)
                {
                    return NotFound();
                }

                existingInstrument.TypeInstrument = instrument.TypeInstrument;
                existingInstrument.InstrumentName = instrument.InstrumentName;
                existingInstrument.UseStrings = instrument.UseStrings;
                existingInstrument.ModifiedById = "14530";
                existingInstrument.ModifiedOn = DateTime.Now;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(instrument);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments.FirstOrDefaultAsync(m => m.id == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument != null)
            {
                _context.Instruments.Remove(instrument);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
