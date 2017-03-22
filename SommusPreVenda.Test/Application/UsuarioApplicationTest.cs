using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.Usuario;
using SommusPreVenda.Domain.Enums;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class UsuarioApplicationTest : BaseApplicationTest
    {
        [TestMethod]
        public void UsuarioGetTest()
        {
            var usuarioVM = new UsuarioVM();
            usuarioVM = UsuarioApplication.Get("SCI", "SCI");
            Assert.AreEqual(ResponseTypeEnum.Success.ToString(),UsuarioApplication.ResponseType);
        }
    }
}
