using CatalogoAPI_Net5.Context;
using CatalogoAPI_Net5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CatalogoAPI_Net5.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
