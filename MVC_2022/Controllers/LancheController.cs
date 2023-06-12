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
            var lanches = _lancheRepository.Lanches;
            return View(lanches);
        }
    }
}
