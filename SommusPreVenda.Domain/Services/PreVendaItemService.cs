namespace SommusPreVenda.Domain.Services
{
    public class PreVendaItemService
    {
        public ResponseService ResponseService { get; set; }

        public PreVendaItemService()
        {
            ResponseService = new ResponseService();
        }

        public decimal CalculaPrecoBruto(decimal quantidade, decimal precoUnitario)
        {
            return quantidade * precoUnitario;
        }

        public decimal CalculaPrecoTotal(decimal quantidade, decimal precoUnitario, decimal desconto)
        {
            return (quantidade * precoUnitario) - desconto;
        }
    }
}
