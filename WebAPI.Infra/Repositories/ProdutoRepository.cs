using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Infra.Data;
using WebAPI.Infra.Interface;

namespace WebAPI.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly WebApiContext _context;

        public ProdutoRepository(WebApiContext webApiContext)
        {
            _context = webApiContext;   
        }

        public IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.Find(id);
        }

        public Produto Insert(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public void Delete(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public Produto Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return produto;
        }
    }
}
