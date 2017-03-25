namespace SommusPreVenda.Domain.Entities
{
    public class PreVendaItem
    {
        public int PreVendaId { get; set; }
        public int Registro { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal Desconto { get; set; }
        public Produto Produto { get; set; }
    }
}
