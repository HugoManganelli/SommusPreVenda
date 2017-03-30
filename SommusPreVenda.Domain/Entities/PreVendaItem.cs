using System;

namespace SommusPreVenda.Domain.Entities
{
    public class PreVendaItem
    {
        public int PreVendaId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Registro { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal PrecoTotalBruto { get; set; }
        public decimal Desconto { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario ConcedeuDesconto { get; set; }
        public Produto Produto { get; set; }
    }
}
