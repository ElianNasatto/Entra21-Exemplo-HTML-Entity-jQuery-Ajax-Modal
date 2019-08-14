using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VendaRepository : IVendaRepository
    {
        public SistemaContext contexto;

        public VendaRepository()
        {
            contexto = new SistemaContext();
        }

        public bool Alterar(Venda venda)
        {

            var vendaOriginal = contexto.Vendas.FirstOrDefault(x => x.Id == venda.Id);

            if (venda == null)
            {
                return false;
            }
            else{
                vendaOriginal.IdCliente = venda.IdCliente;
                vendaOriginal.Descricao = venda.Descricao;
                int quantidadeAfetada = contexto.SaveChanges();
                return quantidadeAfetada == 1;
            }

        }

        public bool Apagar(int id)
        {

            var venda = contexto.Vendas.FirstOrDefault(x => x.Id == id);
            if (venda == null)
            {
                return false;
            }
            else
            {
                venda.RegistroAtivo = false;
                int quantidadeAfetada = contexto.SaveChanges();
                return quantidadeAfetada == 1;
            }


        }

        public int Inserir(Venda venda)
        {
            contexto.Vendas.Add(venda);
            contexto.SaveChanges();
            return venda.Id;
        }

        public Venda ObterPeloId(int id)
        {
            return contexto.Vendas.FirstOrDefault(x=> x.Id == id );
        }

        public List<Venda> ObterTodos()
        {
            return contexto.Vendas.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
