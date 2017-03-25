using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class PreVendaItemApplicationTest
    {
        [TestMethod]
        public void CalculaPrecoTotalTest()
        {
            decimal quantidade = 5;
            decimal precoUnitario = 10;
            decimal desconto = 2;

            Assert.AreEqual(PreVendaItemApplication.CalculaPrecoTotal(quantidade,precoUnitario,desconto), 48);
        }
    }
}
