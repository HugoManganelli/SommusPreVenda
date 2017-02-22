﻿using SommusPreVenda.Application.DependencyInjection.Interfaces;
using System;

namespace SommusPreVenda.Application.DependencyInjection.Services
{
    public static class DependencyInjectionService
    {
        private static IDependencyInjection _dependencyInjection;

        public static void Inicializa(IDependencyInjection dependencyInjection)
        {
            _dependencyInjection = dependencyInjection;
        }

        public static T Resolve<T>()
        {
            return _dependencyInjection.Resolve<T>();
        }

        public static T Resolve<T>(Type type)
        {
            return _dependencyInjection.Resolve<T>(type);
        }
    }
}
