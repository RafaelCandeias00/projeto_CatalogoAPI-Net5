using CatalogoAPI_Net5.Models;
using CatalogoAPI_Net5.Pagination;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoAPI_Net5.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutoPorPreco();
        Task<PagedList<Produto>> GetProdutos(ProdutosParameters produtosParameters);
    }
}
