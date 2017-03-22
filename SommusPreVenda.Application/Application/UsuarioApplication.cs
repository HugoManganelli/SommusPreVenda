using AutoMapper;
using SommusPrevenda.Infra.Encryption;
using SommusPreVenda.Application.DependencyInjection.Services;
using SommusPreVenda.Application.ViewModels.Usuario;
using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Interfaces.Encryption;
using SommusPreVenda.Domain.Interfaces.Repositories;
using SommusPreVenda.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Application.Application
{
    public static class UsuarioApplication
    {
        private static readonly UsuarioService _usuarioService = new UsuarioService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IUsuarioRepository>(),
            DependencyInjectionService.Resolve<ICriptografiaMD5Service>()
            );

        public static string ResponseMessage
        {
            get
            {
                return _usuarioService.ResponseService.Message;
            }
        }
        public static string ResponseType
        {
            get
            {
                return _usuarioService.ResponseService.Type.ToString();
            }
        }

        public static UsuarioVM Get(string login, string senha)
        {
            var usuario = _usuarioService.Get(login,senha);
            var usuarioVM = new MapperConfiguration(x =>
           {
               x.CreateMap<Usuario, UsuarioVM>();
           })
            .CreateMapper()
            .Map < Usuario, UsuarioVM>(usuario);

            return usuarioVM;
        }
       
    }
}
