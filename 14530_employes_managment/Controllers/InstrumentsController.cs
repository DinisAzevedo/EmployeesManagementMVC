using _14530_employes_managment.Data;
using _14530_employes_managment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14530_employes_managment.Controllers
{
    // Controlador do CRUD de instrumentos: lista, detalhe, criar, editar e apagar.
    public class InstrumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstrumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instruments.ToListAsync());
        }

        // GET: Instruments/Details/5
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

        // GET: Instruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TypeInstrument,InstrumentName,UseStrings")] Instrument instrument)
        {
            // Auditoria preenchida no servidor para evitar depender do formulario.
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
        
        // GET: Instruments/Edit/5
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

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // Atualiza o registo e grava as alteracoes na base de dados.
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

        // GET: Instruments/Delete/5
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

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Remove o registo apenas depois da confirmacao do utilizador.
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
