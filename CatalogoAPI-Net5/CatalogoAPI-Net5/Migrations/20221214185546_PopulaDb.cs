using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogoAPI_Net5.Migrations
{
    public partial class PopulaDb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) Values('Bebidas','bebidas.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) Values('Lanches','lanches.jpg')");
            mb.Sql("Insert into Categorias(Nome,ImagemUrl) Values('Sobremesas','sobremesas.jpg')");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,Imagem,DataCadastro,Estoque,CategoriaId)" +
               "Values('Coca-Cola Diet','Refrigerante de Cola 350 ml',5.45,'cocacola.jpg',now(),50," +
               "(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,Imagem,DataCadastro,Estoque,CategoriaId)" +
                "Values('Lanche de Atum','Lanche de Atum com maionese',8.50,'atum.jpg',now(),10," +
                "(Select CategoriaId from Categorias where Nome='Lanches'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,Imagem,DataCadastro,Estoque,CategoriaId)" +
               "Values('Pudim 100 g','Pudim de leite condensado 100g',6.75,'pudim.jpg',now(),20," +
               "(Select CategoriaId from Categorias where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
