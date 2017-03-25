using SommusPreVenda.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Application.Application
{
    public static class PreVendaItemApplication
    {
        private static readonly PreVendaItemService _preVendaItemService = new PreVendaItemService() { };

        public static string ResponseMessage
        {
            get
            {
                return _preVendaItemService.ResponseService.Message;
            }
        }

        public static string ResponseType
        {
            get
            {
                return _preVendaItemService.ResponseService.Type.ToString();
            }
        }

        public static decimal CalculaPrecoTotal(decimal quantidade, decimal precoUnitario, decimal desconto)
        {
            var valorTotal = _preVendaItemService.CalculaPrecoTotal(quantidade, precoUnitario, desconto);

            return valorTotal;
        }
    }
}
