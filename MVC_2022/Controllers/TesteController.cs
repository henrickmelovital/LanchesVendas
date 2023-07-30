using Microsoft.AspNetCore.Mvc;

namespace MVC_2022.Controllers
{
    public class TesteController : Controller
    {
        public string Index()
        {
            return $"Testando o método Index de TesteController : {DateTime.Now} ";
        }
    }
}
