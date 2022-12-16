using CatalogoAPI_Net5.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI_Net5.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        public IEnumerable<ProdutoDTO> Produtos { get; set; }
    }
}
