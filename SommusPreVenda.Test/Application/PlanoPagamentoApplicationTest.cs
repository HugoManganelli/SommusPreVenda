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
    public class PlanoPagamentoApplicationTest: BaseApplicationTest
    {
        [TestMethod]
        public void PlanoPagamentoGetTest()
        {
            var planoPagamentoVM = new PlanoPagamentoVM();
            planoPagamentoVM = PlanoPagamentoApplication.Get(1);
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), PlanoPagamentoApplication.ResponseType);
        }

        [TestMethod]
        public void PlanoPagamentoGetAllTest()
        {
            var planosPagamentoVM = new List<PlanoPagamentoVM>();
            planosPagamentoVM = PlanoPagamentoApplication.Get();
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), PlanoPagamentoApplication.ResponseType);

        }
    }
}
