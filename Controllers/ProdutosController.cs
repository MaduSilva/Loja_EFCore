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
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        // GET
        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        // POST
        [HttpPost]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(Guid id, Produto produto)
        {
            produto.Id = id;
            _produtoRepository.Editar(produto);
        }

        // DELETE
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Remover(id);
        }
    }
}
    
