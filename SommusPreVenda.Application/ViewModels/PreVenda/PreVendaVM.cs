using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Application.ViewModels.FormaPagamento;
using SommusPreVenda.Application.ViewModels.PreVendaItem;
using SommusPreVenda.Application.ViewModels.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Application.ViewModels.PreVenda
{
    public class PreVendaVM
    {
        public decimal Desconto { get; set; }
        public ClientePreVendaVM Cliente { get; set; }
        public PlanoPagamentoPreVendaVM PlanoPagamento { get; set; }
        public decimal Valor { get; set; }
        public UsuarioPreVendaVM Usuario { get; set; }
        public List<PreVendaItemVM> PreVendaItens { get; set; }
    }
}
