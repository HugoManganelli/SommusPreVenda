using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.FormaPagamento;
using SommusPreVenda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class FormaPagamentoTest: BaseApplicationTest
    {
        [TestMethod]
        public void FormaPagamentoGetTest()
        {
            var formaPagamentoVM = new FormaPagamentoVM();
            formaPagamentoVM = FormaPagamentoApplication.Get(1);
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), FormaPagamentoApplication.ResponseType);
        }

        [TestMethod]
        public void FormaPagamentoGetAllTest()
        {
            var formasPagamentoVM = new List<FormaPagamentoVM>();
            formasPagamentoVM = FormaPagamentoApplication.Get();
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), FormaPagamentoApplication.ResponseType);

        }
    }
}
