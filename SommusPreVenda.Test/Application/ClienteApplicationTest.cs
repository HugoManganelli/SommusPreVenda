using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Domain.Enums;
using System.Collections.Generic;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class ClienteApplicationTest : BaseApplicationTest
    {
        [TestMethod]
        public void ClienteGetTest()
        {
            var clienteVM = new ClienteVM();
            clienteVM = ClienteApplication.Get(1);
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), ClienteApplication.ResponseType);
        }

        [TestMethod]
        public void ClienteGetPesquisaTest()
        {
            var clientesVM = new List<ClienteVM>();
            clientesVM = ClienteApplication.Get("VISA");
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), ClienteApplication.ResponseType);
        }
    }
}
