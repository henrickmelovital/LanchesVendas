using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
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

        public IActionResult List(string categoria)
        {
            /*var lanches = _lancheRepository.Lanches;
            var totalLanches = lanches.Count();

            return View(lanches);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";*/

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(L => L.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                /* Método Antigo
                 * if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches.Where(L => L.Categoria.CategoriaNome.Equals("Normal")).OrderBy(L => L.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(L => L.Categoria.CategoriaNome.Equals("Natural")).OrderBy(L => L.Nome);
                    
                }*/
                lanches = _lancheRepository.Lanches
                    .Where(L => L.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(C => C.Categoria);

                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(L => L.LancheId == lancheId);
            return View(lanche);
        }
    }
}
