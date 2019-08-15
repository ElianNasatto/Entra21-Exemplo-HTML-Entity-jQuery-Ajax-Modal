using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private SistemaContext context;

        public ProdutoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Produto produto)
        {
            var produtoOriginal = context.Produtos.FirstOrDefault(x => x.Id == produto.Id);
            if (produtoOriginal == null)
            {
                return false;
            }
            else
            {
                produtoOriginal.Nome = produto.Nome;
                produtoOriginal.Quantidade = produto.Quantidade;
                produtoOriginal.Valor = produto.Valor;
                int quantidadeAfetada = context.SaveChanges();
                return quantidadeAfetada == 1;
            }
        }

        public bool Apagar(int id)
        {
            var venda = context.Produtos.FirstOrDefault(x => x.Id == id);
            if (venda == null)
            {
                return false;
            }
            else
            {
                venda.RegistroAtivo = false;
                int quantidadeAfetada = context.SaveChanges();
                return quantidadeAfetada == 1; 
            }
        }

        public int Inserir(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto ObterPeloId(int id)
        {
            return context.Produtos.FirstOrDefault(x => x.Id == id);

        }

        public List<Produto> ObterProdutosPeloIdVenda(int idVenda)
        {
            return context.Produtos.Where(x => x.IdVenda == idVenda).ToList();

        }
    }
}
