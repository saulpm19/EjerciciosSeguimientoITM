using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicios.Models;
using Ejercicios.Data;



namespace Lista_De_Tareas.Controllers
{
    public class TareaController : Controller
    {
        private readonly Datacontext _context;

        public TareaController(Datacontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //RECORDAR: NO RECONOCE LA OPERACION, SE HIZO SEPARADO
            IEnumerable<Tarea> tareas = await _context.Tarea.ToListAsync();
            return View(tareas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            //LA LINEA DE ABAJO SE ADAPTA SEGUN EXPLICACION
            Tarea? tarea = await _context.Tarea.FirstOrDefaultAsync(t => t.Id==Id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Tarea tarea)
        {
            if (Id != tarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Tarea? tarea = await _context.Tarea.FirstOrDefaultAsync(t => t.Id == Id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            Tarea? tarea = await _context.Tarea.FirstOrDefaultAsync(t => t.Id == Id);
            _context.Tarea.Remove(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MarkAsCompleted(int Id)
        {
            Tarea? tarea = await _context.Tarea.FirstOrDefaultAsync(t => t.Id == Id);
            if (tarea != null) 
            {
                tarea.Completada = !tarea.Completada;
                _context.Update(tarea);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


//tarea.Completada = true;
//_context.Update(tarea);
//await _context.SaveChangesAsync();
//return RedirectToAction(nameof(Index));