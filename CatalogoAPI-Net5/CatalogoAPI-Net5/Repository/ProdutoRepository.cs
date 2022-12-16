using CatalogoAPI_Net5.Context;
using CatalogoAPI_Net5.Models;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoAPI_Net5.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Produto> GetProdutoPorPreco()
        {
            return Get().OrderBy(c => c.Preco).ToList();
        }
    }
}
