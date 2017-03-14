using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.Usuario;
using SommusPreVenda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class UsuarioApplicationTest : BaseApplicationTest
    {
        [TestMethod]
        public void UsuarioGetTest()
        {
            var usuarioVM = new UsuarioVM();
            usuarioVM = UsuarioApplication.Get("SAMUEL","SCI");
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(),UsuarioApplication.ResponseType);
        }
    }
}
