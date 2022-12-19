using CatalogoAPI_Net5.Context;
using CatalogoAPI_Net5.Models;
using CatalogoAPI_Net5.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoAPI_Net5.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> GetProdutoPorPreco()
        {
            return await Get().OrderBy(c => c.Preco).ToListAsync();
        }

        public async Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters)
        {
            /*return Get()
                .OrderBy(on => on.Nome)
                .Skip((produtosParameters.PageNumber - 1) * produtosParameters.PageSize)
                .Take(produtosParameters.PageSize)
                .ToList();*/

            return await PagedList<Produto>.ToPagedList(Get().OrderBy(on => on.Nome),
                produtosParameters.PageNumber, produtosParameters.PageSize);
        }
    }
}
