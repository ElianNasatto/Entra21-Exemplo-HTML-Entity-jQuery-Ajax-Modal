using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("SqlServerConnection")
        {

        }


        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
