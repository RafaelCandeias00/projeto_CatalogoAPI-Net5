using CatalogoAPI_Net5.Models;
using CatalogoAPI_Net5.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoAPI_Net5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
        {
            return _uof.ProdutoRepository.GetProdutoPorPreco().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _uof.ProdutoRepository.Get().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name ="ObterProduto")]
        public ActionResult<Produto> Get([FromRoute] int id)
        {
            try
            {
                var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

                if (produto == null)
                {
                    return NotFound($"O produto com id {id} não foi encontrada!");
                }

                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter as categorias do banco de dados!");
            }
            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            try
            {
                _uof.ProdutoRepository.Add(produto);
                _uof.Commit();

                return new CreatedAtRouteResult("ObterProduto",
                    new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar criar um novo produto!");
            }
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id,[FromBody] Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest($"Não foi possível atualizar o produto com id {id}!");
                }

                _uof.ProdutoRepository.Update(produto);
                _uof.Commit();
                return Ok($"O produto com id {id} foi atualizado com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar produto com id {id}!");
            }
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id)
        {
            try
            {
                var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);

                if (produto == null)
                {
                    return NotFound($"O produto com id {id} não foi encontrado!");
                }

                _uof.ProdutoRepository.Delete(produto);
                _uof.Commit();

                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir produto com id {id}!");
            }
            
        }
    }
}
