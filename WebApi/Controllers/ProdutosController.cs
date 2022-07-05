using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DTO;
using WebApi.Domain.Entities;
using WebApi.Infra.Data;
using WebAPi.Application.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_produtoAppService.GetAll());
        }

        [HttpPost]
        public IActionResult Insert(ProdutoDTO produtoDTO)
        {
            return Ok(_produtoAppService.Insert(produtoDTO));
        }

        [HttpPut]

        public IActionResult Update(ProdutoDTO produtoDTO)
        {

            return Ok(_produtoAppService.Update(produtoDTO));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _produtoAppService.Delete(id);
            return Ok("Produto" + id + "excluido com sucesso!");
        }

        [HttpGet("GetById", Name = "GetById")]

        public IActionResult GetById(int id)
        {
            

            return Ok(_produtoAppService.GetProdutoDTOById(id));
        }

    }
    
}
