using apigerenciador.Application.UseCases;
using apigerenciador.domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;  // Usando System.Web.Http em vez de Microsoft.AspNetCore.Mvc

namespace apigerenciador.WebApi.Controllers
{
    [Route("api/[controller]")]  // Roteamento é diferente no .NET Framework
    public class ProdutoController : ApiController  // Herdando de ApiController no .NET Framework
    {
        private readonly AdicionarProdutoUseCase _adicionarProdutoUseCase;
        private readonly AtualizarProdutoUseCase _atualizarProdutoUseCase;
        private readonly DeletarProdutoUseCase _deletarProdutoUseCase;
        private readonly ObterProdutoPorIdUseCase _obterProdutoPorIdUseCase;
        private readonly ObterTodosProdutosUseCase _obterTodosProdutosUseCase;

        public ProdutoController(
    AdicionarProdutoUseCase adicionarProdutoUseCase,
    AtualizarProdutoUseCase atualizarProdutoUseCase,
    DeletarProdutoUseCase deletarProdutoUseCase,
    ObterProdutoPorIdUseCase obterProdutoPorIdUseCase,
    ObterTodosProdutosUseCase obterTodosProdutosUseCase)
        {
            if (adicionarProdutoUseCase == null || atualizarProdutoUseCase == null || deletarProdutoUseCase == null ||
                obterProdutoPorIdUseCase == null || obterTodosProdutosUseCase == null)
            {
                throw new ArgumentNullException("Uma ou mais dependências não foram injetadas corretamente.");
            }

            _adicionarProdutoUseCase = adicionarProdutoUseCase;
            _atualizarProdutoUseCase = atualizarProdutoUseCase;
            _deletarProdutoUseCase = deletarProdutoUseCase;
            _obterProdutoPorIdUseCase = obterProdutoPorIdUseCase;
            _obterTodosProdutosUseCase = obterTodosProdutosUseCase;
        }


        // Ação para adicionar produto
        [HttpPost]
        public async Task<IHttpActionResult> AddProduto([FromBody] Produto produto)  // Mudado para IHttpActionResult
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            if (produto.Id == 0)
            {
                return BadRequest("Id do Produto nulo ou zero .");
            }

            await _adicionarProdutoUseCase.ExecuteAsync(produto.Nome, produto.Preco, produto.Id);
            return CreatedAtRoute("DefaultApi", new { id = produto.Id }, produto);  // Alterado para método correto no .NET Framework
        }

        // Ação para atualizar produto
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduto([FromBody] Produto produto)  // Mudado para IHttpActionResult
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            await _atualizarProdutoUseCase.ExecuteAsync(produto);
            return StatusCode(System.Net.HttpStatusCode.NoContent);  // Usando StatusCode para retorno 204
        }

        // Ação para deletar produto
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteProduto(int id)
        {
            await _deletarProdutoUseCase.ExecuteAsync(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);  // Usando StatusCode para retorno 204
        }

        // Ação para obter produto por ID
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetProdutoById(int id)
        {
            var produto = await _obterProdutoPorIdUseCase.ExecuteAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);  // Retorno com 200 OK e o objeto
        }

        // Ação para obter todos os produtos
        [HttpGet]
        public async Task<IHttpActionResult> GetAllProdutos()
        {
            var produtos = await _obterTodosProdutosUseCase.ExecuteAsync();
            return Ok(produtos);  // Retorno com 200 OK e lista de produtos
        }
    }
}
