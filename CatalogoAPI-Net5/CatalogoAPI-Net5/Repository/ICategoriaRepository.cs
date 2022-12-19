using CatalogoAPI_Net5.Models;
using CatalogoAPI_Net5.Pagination;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoAPI_Net5.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
        Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriasParameters);
    }
}
