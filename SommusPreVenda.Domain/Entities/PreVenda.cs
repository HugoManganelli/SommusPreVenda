using System;
using System.Collections.Generic;

namespace SommusPreVenda.Domain.Entities
{
    public class PreVenda
    {
        public int PreVendaId { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public PlanoPagamento PlanoPagamento { get; set; }
        public List<PreVendaItem> PreVendaItens { get; set; }

    }
}
