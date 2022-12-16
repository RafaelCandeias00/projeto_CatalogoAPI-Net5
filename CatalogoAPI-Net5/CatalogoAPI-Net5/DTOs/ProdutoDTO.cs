using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI_Net5.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Imagem { get; set; }

        public int CategoriaId { get; set; }
    }
}
