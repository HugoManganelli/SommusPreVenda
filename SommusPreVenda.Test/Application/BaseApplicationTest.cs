using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.AutoMapper;
using SommusPreVenda.Application.DependencyInjection.Services;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class BaseApplicationTest
    {
        public BaseApplicationTest()
        {
            DependencyInjectionService.Inicializa(Container.GetContainer());
            AutoMapperConfig.RegisterMappings();
        }
    }
}
