using Microsoft.Practices.Unity;
using SommusPrevenda.Infra.Encryption;
using SommusPreVenda.Application.DependencyInjection.Interfaces;
using SommusPreVenda.Data.ADO.Repositories;
using SommusPreVenda.Domain.Interfaces.Encryption;
using SommusPreVenda.Domain.Interfaces.Repositories;
using SommusPreVenda.Domain.Services;
using System;

namespace SommusPreVenda.Application.DependencyInjection.Services
{

    public class Container : IDependencyInjection
    {
        private static Container _container;
        private readonly IUnityContainer _unityContainer;

        private Container()
        {
            _unityContainer = new UnityContainer();
            RegisterTypes();
        }

        public static Container GetContainer()
        {
            return _container ?? (_container ?? new Container());
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public T Resolve<T>(Type type)
        {
            return (T)_unityContainer.Resolve(type);
        }

        private void RegisterTypes()
        {
            _unityContainer
                .RegisterType<IDataContext, DataContext>(new InjectionConstructor())
                .RegisterType<IClienteRepository, ClienteRepository>(new InjectionConstructor())
                .RegisterType<IProdutoRepository, ProdutoRepository>(new InjectionConstructor())
                .RegisterType<IUsuarioRepository, UsuarioRepository>(new InjectionConstructor())
                .RegisterType<ICriptografiaMD5Service, CriptografiaMD5Service>(new  InjectionConstructor());
        }
    }
}
