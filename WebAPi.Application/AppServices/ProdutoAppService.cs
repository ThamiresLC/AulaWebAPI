using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTO;
using WebApi.Domain.Entities;
using WebAPi.Application.Interface;
using WebAPI.Infra.Interface;

namespace WebAPi.Application.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Delete(int id)
        {
            var produto = _produtoRepository.GetById(id);
            _produtoRepository.Delete(produto);
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var produtos = _produtoRepository.GetAll();
            var produtosDTO = produtos.Select(c => new ProdutoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Marca = c.Marca,

            });
            return produtosDTO;
        }

        public ProdutoDTO GetProdutoDTOById(int id)
        {
            var produto = _produtoRepository.GetById(id);

            var produtoDTO = new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Marca = produto.Marca,

            };

            return produtoDTO;
        }

        public ProdutoDTO Insert(ProdutoDTO produtoDTO)
        {
            var produto = new Produto
            {
                Nome = produtoDTO.Nome,
                Marca = produtoDTO.Marca,

            };

            _produtoRepository.Insert(produto);
            produtoDTO.Id = produto.Id;
            return produtoDTO;
        }

        public ProdutoDTO Update(ProdutoDTO produtoDTO)
        {
            var produtoAlterado = _produtoRepository.GetById(produtoDTO.Id);

            produtoAlterado.Nome = produtoDTO.Nome;
            produtoAlterado.Marca = produtoDTO.Marca;

            _produtoRepository.Update(produtoAlterado);

            return produtoDTO;
        }
    }
}
