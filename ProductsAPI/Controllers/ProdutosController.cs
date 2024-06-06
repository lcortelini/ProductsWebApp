using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;
using ProductsAPI.Utilities;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                IEnumerable<Produto> produtos = await _produtoService.GetAllProdutos();
                return Ok(produtos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao consultar produtos");
            }
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            try
            {
                Produto produto = await _produtoService.GetProdutoById(id);

                return Ok(produto);
            }
            catch (ServiceException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _produtoService.CreateProduto(produto);
                    return CreatedAtRoute(nameof(GetProduto), new { id = produto.Id }, produto);
                }
                else
                    return BadRequest("Dados inválidos");
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Produto produto)
        {
            try
            {
                if (ModelState.IsValid && produto.Id == id)
                {
                    await _produtoService.UpdateProduto(produto);
                    return Ok("Produto atualizado com sucesso");
                }
                else
                    return BadRequest("Dados inválidos");
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Produto produto = await _produtoService.GetProdutoById(id);
                await _produtoService.DeleteProduto(produto);

                return Ok("Aluno excluído com sucesso");
            }
            catch (ServiceException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }
    }
}
