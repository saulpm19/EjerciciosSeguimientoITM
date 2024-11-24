using Ejercicios.Data;
using Ejercicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicios.Controllers
{
    public class PropinasController : Controller
    {
        private readonly Datacontext _context;

        public PropinasController(Datacontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new Propina());
        }

        [HttpPost]
        public async Task<IActionResult> Calcular(Propina propina)
        {
            propina.MontoPropina= (propina.MontoTotal * propina.PorcentajePropina) / 100;
            propina.MontoTotalConPropina= propina.MontoPropina + propina.MontoTotal;

            if (ModelState.IsValid)
            {
                
                return View("Resultado", propina);
            }
            return View("Index", propina);


        }
    }
}

