using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTO;

namespace WebAPi.Application.Interface
{
    public interface IProdutoAppService
    {
        IEnumerable<ProdutoDTO> GetAll();

        ProdutoDTO Insert(ProdutoDTO produtoDTO);

        ProdutoDTO Update(ProdutoDTO produtoDTO);

        ProdutoDTO GetProdutoDTOById(int id);

        void Delete(int id);
    }
}
