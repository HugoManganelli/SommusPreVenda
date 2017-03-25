using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Application.ViewModels.PreVendaItem
{
    public class PreVendaItemVM
    {
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public decimal Desconto { get; set; }
        public ProdutoPreVendaItemVM ProdutoPreVendaItemVM { get; set; }
    }
}
