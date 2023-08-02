
using Microsoft.AspNetCore.Mvc;
using MVC_2022.Models;
using MVC_2022.Repositories.Interface;

namespace MVC_2022.Controllers;

public class PedidoController : Controller
{

    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        return View();
    }
}

