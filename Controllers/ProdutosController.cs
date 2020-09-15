using EFCore.Domains;
using EFCore.Interfaces;
using EFCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EFCore.Controllers
{

    //Implementa todos os métodos criados no repository
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        // GET
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produtos = _produtoRepository.Listar();


                //Verifica se existe produtos, caso não exista retorna NoContent
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorna um Ok e os produtos
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // GET
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca o produto no repositório
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se existe produtos, caso não exista retorna NoFound
                if (produto == null)
                    return NotFound();

                //Caso exista retorna um Ok e os produtos
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //Caso ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }

        }

        // PUT 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

                //Edita o produto
                produto.Id = id;
                _produtoRepository.Editar(produto);

                //Caso ok com os dados do produto
                return Ok(produto);

            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                //Caso ok com os dados do produto
                return Ok(id);

            }
            catch (Exception ex)
            {
                //No caso de ocorrer algum erro retorna BadRequest e a mensagem do erro
                return BadRequest(ex.Message);
            }

        }
    }
}

