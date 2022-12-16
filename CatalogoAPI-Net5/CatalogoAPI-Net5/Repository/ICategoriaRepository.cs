using CatalogoAPI_Net5.Models;
using System.Collections;
using System.Collections.Generic;

namespace CatalogoAPI_Net5.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
