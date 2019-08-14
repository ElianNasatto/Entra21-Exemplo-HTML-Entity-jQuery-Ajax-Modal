﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("produtos")]
    public class Produto
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("valor")]
        public decimal Valor { get; set; }

        [Column("registro}_ativo")]
        public bool RegistroAtivo { get; set; }

        [Column("id_venda")]
        public int IdVenda { get; set; }

        [ForeignKey("IdVenda")]
        public int Venda { get; set; }
    }
}