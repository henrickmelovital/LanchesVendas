using Microsoft.AspNetCore.Mvc;
using MVC_2022.Repositories.Interface;

namespace MVC_2022.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            ViewData["Titulo"] = "Todo os Lanches";
            ViewData["Data"] = DateTime.Now;
            
            var lanches = _lancheRepository.Lanches;
            var totalLanches = lanches.Count();

            ViewBag.Total = "Total de Lanches: ";
            ViewBag.TotalLanches = totalLanches;


            return View(lanches);
        }
    }
}
