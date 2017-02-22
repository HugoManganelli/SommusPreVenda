using System;

namespace SommusPreVenda.Application.DependencyInjection.Interfaces
{
    public interface IDependencyInjection
    {
        T Resolve<T>();
        T Resolve<T>(Type type);
    }
}
