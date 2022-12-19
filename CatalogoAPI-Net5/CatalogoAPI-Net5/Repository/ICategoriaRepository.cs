using CatalogoAPI_Net5.Models;
using CatalogoAPI_Net5.Pagination;
using System.Collections;
using System.Collections.Generic;

namespace CatalogoAPI_Net5.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
        PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
    }
}
