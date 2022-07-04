using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.DTO;
using WebApi.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly WebApiContext _context;
        public ProdutosController(WebApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _context.Produtos.ToList();
            var produtosDTO = produtos.Select(c => new ProdutoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Marca = c.Marca,

            });
            return Ok(produtosDTO);
        }

        [HttpPost]
        public IActionResult Insert(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
               Nome = produtoDTO.Nome,
               Marca = produtoDTO.Marca,

            };
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut]

        public IActionResult Update(ProdutoDTO produtoDTO)
        {
            var produtoAlterado = _context.Produtos.FirstOrDefault(x => x.Id == produtoDTO.Id);
            if (produtoAlterado == null)    
                return NotFound();

            produtoAlterado.Nome = produtoDTO.Nome;
            produtoAlterado.Marca = produtoDTO.Marca;

            _context.Produtos.Update(produtoAlterado);
            _context.SaveChanges();
            return Ok (produtoDTO);
        }

        [HttpDelete] 
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok("Produto" + id + "excluido com sucesso!");
        }

        [HttpGet("GetById", Name = "GetById")]

        public IActionResult GetById(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return NotFound();

            var produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Marca = produto.Marca,

            };

            return Ok(produtoDTO);
        }

    }
    
}
