using Microsoft.VisualStudio.TestTools.UnitTesting;
using SommusPreVenda.Application.DependencyInjection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Test.Application
{
    [TestClass]
    public class BaseApplicationTest
    {
        public BaseApplicationTest()
        {
            DependencyInjectionService.Inicializa(Container.GetContainer());
        }
    }
}
