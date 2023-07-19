using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repositories;
using MVC_2022.Repositories.Interface;
using MVC_2022.ViewModels;
using System.Diagnostics;

namespace MVC_2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly LancheRepository _lancheRepository;

        public HomeController(LancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchePreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}