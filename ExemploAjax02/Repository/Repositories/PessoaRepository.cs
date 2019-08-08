using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private SistemaContext context;

        public PessoaRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Pessoa pessoa)
        {
            var pessoaOriginal = context.Pessoas.FirstOrDefault(x => x.Id == pessoa.Id);
            if (pessoaOriginal == null)
            {
                return false;
            }
            else
            {
                pessoaOriginal.Nome = pessoa.Nome;
                pessoaOriginal.CPF = pessoa.CPF;
                int quantidadeAfetada = context.SaveChanges();
                return quantidadeAfetada == 1;
            }
        }

        public bool Apagar(int id)
        {
            // Caso o first nao encontre o registro ele retorna um exxeption ja o default ele retorna null
            // Sempre usar o default para evitar que a aplicação pare de funcinar
            var pessoa = context.Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa == null)
            
                return false;

            pessoa.ResgitroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
            
        }

        public int Inserir(Pessoa pessoa)
        {
            context.Pessoas.Add(pessoa);
            context.SaveChanges();
            return pessoa.Id;
        }

        public Pessoa ObterPeloId(int id)
        {
            var pessoa = context.Pessoas.FirstOrDefault(x => x.Id == id);
            return pessoa;
        }

        public List<Pessoa> ObterTodos()
        {
            return context.Pessoas.Where(x => x.ResgitroAtivo == true).ToList(); 
        }
    }
}
