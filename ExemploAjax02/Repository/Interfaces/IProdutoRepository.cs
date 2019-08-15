using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> ObterProdutosPeloIdVenda(int idVenda);

        Produto ObterPeloId(int id);

        int Inserir(Produto produto);

        bool Alterar(Produto produto);

        bool Apagar(int id);

    }
}
