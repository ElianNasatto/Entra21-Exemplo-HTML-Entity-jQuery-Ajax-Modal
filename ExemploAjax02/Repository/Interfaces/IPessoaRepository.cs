using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPessoaRepository
    {
        int Inserir(Pessoa pessoa);

        bool Alterar(Pessoa pessoa);

        List<Pessoa> ObterTodos();

        bool Apagar(int id);

        Pessoa ObterPeloId(int id);
    }
}
