using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Services
{
    public class PreVendaItemService
    {
        public ResponseService ResponseService { get; set; }

        public PreVendaItemService()
        {
            ResponseService = new ResponseService();
        }
        
        public decimal CalculaPrecoTotal(decimal quantidade, decimal precoUnitario, decimal desconto)
        {
            return (quantidade * precoUnitario) - desconto;
        }
    }
}
