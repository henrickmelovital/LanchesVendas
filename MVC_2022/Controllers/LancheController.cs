using Microsoft.AspNetCore.Mvc;
using MVC_2022.Repositories.Interface;
using MVC_2022.ViewModels;

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
            //var lanches = _lancheRepository.Lanches;
            //var totalLanches = lanches.Count();

            //return View(lanches);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
