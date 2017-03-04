using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.ViewModels.Cliente;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Domain.Enums;

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
        public void ClienteGetAllTest()
        {
            var clientesVM = new List<ClienteVM>();
            clientesVM = ClienteApplication.Get();
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(), ClienteApplication.ResponseType);
        }
    }
}
