using MVC_2022.Context;
using System.Xml.Serialization;

namespace MVC_2022.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Define a conexão
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            // Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // Obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o di do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            // Retorna o carrinho com o contexto e o Id atributo ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {

        }
    }
}
