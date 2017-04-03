using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.PreVenda;
using SommusPreVenda.Application.ViewModels.PreVendaItem;
using SommusPreVenda.Domain.Enums;
using System.Collections.Generic;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class PreVendaApplicationTest : BaseApplicationTest
    {
        [TestMethod]
        public void PreVendaAddTest()
        {
            var preVendaVM = new PreVendaVM();
            var preVendaItensVM = new List<PreVendaItemVM>();
            var produtoPreVendaItemVM = new ProdutoPreVendaItemVM();
            var planoPagamentoPreVendaVM = new PlanoPagamentoPreVendaVM();
            var clientePreVendaVM = new ClientePreVendaVM();
            var usuarioPreVendaVM = new UsuarioPreVendaVM();

            produtoPreVendaItemVM.ProdutoId = 10;

            var preVendaItemVM = new PreVendaItemVM();
            preVendaItemVM.Produto = produtoPreVendaItemVM;
            preVendaItemVM.Quantidade = 2;
            preVendaItemVM.PrecoUnitario = 10;
            preVendaItemVM.Desconto = 5;
            preVendaItemVM.PrecoTotal = (preVendaItemVM.Quantidade* preVendaItemVM.PrecoUnitario)- preVendaItemVM.Desconto;
            preVendaItemVM.PrecoUnitario = preVendaItemVM.PrecoTotal / preVendaItemVM.Quantidade;
            preVendaItensVM.Add(preVendaItemVM);            
            preVendaVM.Valor += preVendaItemVM.PrecoTotal;

            produtoPreVendaItemVM.ProdutoId = 20;

            preVendaItemVM = new PreVendaItemVM();
            preVendaItemVM.Produto = produtoPreVendaItemVM;
            preVendaItemVM.Quantidade = 5;
            preVendaItemVM.PrecoUnitario = 20;
            preVendaItemVM.Desconto = 0;
            preVendaItemVM.PrecoTotal = (preVendaItemVM.Quantidade * preVendaItemVM.PrecoUnitario) - preVendaItemVM.Desconto;
            preVendaItemVM.PrecoUnitario = preVendaItemVM.PrecoTotal / preVendaItemVM.Quantidade;
            preVendaItensVM.Add(preVendaItemVM);
            preVendaVM.Valor += preVendaItemVM.PrecoTotal;

            produtoPreVendaItemVM.ProdutoId = 30;

            preVendaItemVM = new PreVendaItemVM();
            preVendaItemVM.Produto = produtoPreVendaItemVM;
            preVendaItemVM.Quantidade = 10;
            preVendaItemVM.PrecoUnitario = 7;
            preVendaItemVM.Desconto = 2;
            preVendaItemVM.PrecoTotal = (preVendaItemVM.Quantidade * preVendaItemVM.PrecoUnitario) - preVendaItemVM.Desconto;
            preVendaItemVM.PrecoUnitario = preVendaItemVM.PrecoTotal / preVendaItemVM.Quantidade;
            preVendaItensVM.Add(preVendaItemVM);
            preVendaVM.Valor += preVendaItemVM.PrecoTotal;

            clientePreVendaVM.ClienteId = 1;
            planoPagamentoPreVendaVM.PlanoPagamentoId = 1;
            usuarioPreVendaVM.UsuarioId = 1;

            preVendaVM.Cliente = clientePreVendaVM;
            preVendaVM.PlanoPagamento = planoPagamentoPreVendaVM;
            preVendaVM.Usuario = usuarioPreVendaVM;
            preVendaVM.Desconto = 0;
            preVendaVM.PreVendaItens = preVendaItensVM;

            PreVendaApplication.Add(preVendaVM);
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), PreVendaApplication.ResponseType);
        }
    }
}
