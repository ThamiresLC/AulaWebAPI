using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;

namespace WebAPI.Infra.Interface
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();

        Produto Insert(Produto produtoDTO);

        Produto Update(Produto produtoDTO);

        Produto GetById(int id);

        void Delete(Produto produto);
    }
}
