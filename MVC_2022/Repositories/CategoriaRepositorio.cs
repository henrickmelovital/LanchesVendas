using MVC_2022.Context;
using MVC_2022.Models;
using MVC_2022.Repositories.Interface;

namespace MVC_2022.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
