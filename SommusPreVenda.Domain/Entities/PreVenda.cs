using System;
using System.Collections.Generic;

namespace SommusPreVenda.Domain.Entities
{
    public class PreVenda
    {
        public int PreVendaId { get; set; }
        public ulong NumeroDAVPreVenda { get; set; }
        public string NomeComputador { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public int QuantidadeItens { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }        
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario ConcedeuDesconto { get; set; }
        public PlanoPagamento PlanoPagamento { get; set; }
        public List<PreVendaItem> PreVendaItens { get; set; }

    }
}
