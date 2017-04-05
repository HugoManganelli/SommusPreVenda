using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.Produto;
using SommusPreVenda.Domain.Enums;
using System.Collections.Generic;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class ProdutoApplicationTest : BaseApplicationTest
    {
        [TestMethod]
        public void ProdutoGetTest()
        {
            var produtoVM = new ProdutoVM();
            produtoVM = ProdutoApplication.Get(1);
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), ProdutoApplication.ResponseType);
        }

        [TestMethod]
        public void ProdutoGetPesquisaTest()
        {
            var produtosVM = new List<ProdutoVM>();
            produtosVM = ProdutoApplication.Get("FACA");
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), ProdutoApplication.ResponseType);
        }

    }
}
