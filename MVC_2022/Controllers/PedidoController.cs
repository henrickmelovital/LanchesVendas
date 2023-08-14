
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        int totalItensPedido = 0;
        decimal precoTotalPedido = 0.0m;

        // Obter os itens do carrinho de compra do cliente:
        List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        // Verificar se existem itens do pedido:
        if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
        {
            ModelState.AddModelError("", "Seu carrinho está vazio, que tal incluir um lanche...");
        }

        // Calcular o total de itens e o total do pedido:
        foreach (var item in itens)
        {
            totalItensPedido += item.Quantidade;
            precoTotalPedido += (item.Lanche.Preco * item.Quantidade);

        };

        // Atribuir os valores obtidos ao Pedido:
        pedido.TotalItensPedido = totalItensPedido;
        pedido.PedidoTotal = precoTotalPedido;

        // Valida os dados do pedido:
        if (ModelState.IsValid)
        {
            // Cria o pedido e os detalhes
            _pedidoRepository.CriarPedido(pedido);

            // Define mensagens ao cliente 
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            // Limpar o carrinho do cliente:
            _carrinhoCompra.LimparCarrinho();

            // Exibe a View com dados do cliente e do pedido:
            return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
        }
        return View(pedido);
    }


}

