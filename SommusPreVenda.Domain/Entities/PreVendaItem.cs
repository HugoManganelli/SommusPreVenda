using System;

namespace SommusPreVenda.Domain.Entities
{
    public class PreVendaItem
    {
        Usuario _usuario = new Usuario();
        Usuario _concedeuDesconto = new Usuario();
        Produto _produto = new Produto();

        public int PreVendaId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int Registro { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal PrecoTotalBruto { get; set; }
        public decimal Desconto { get; set; }
        public Usuario Usuario
        {
            get
            {
                return _usuario ?? new Usuario();
            }
            set
            {
                _usuario = value;
            }
        }
        public Usuario ConcedeuDesconto
        {
            get
            {
                return _concedeuDesconto ?? new Usuario();
            }
            set
            {
                _concedeuDesconto = value;
            }
        }
        public Produto Produto
        {
            get
            {
                return _produto ?? new Produto();
            }
            set
            {
                _produto = value;
            }
        }
    }
}
