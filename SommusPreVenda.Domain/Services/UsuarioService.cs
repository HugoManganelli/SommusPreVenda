using SommusPreVenda.Domain.Entities;
using SommusPreVenda.Domain.Enums;
using SommusPreVenda.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Services
{
    public class UsuarioService
    {
        private readonly IDataContext _dataContext;
        private readonly IUsuarioRepository _usuarioRepository;

        public ResponseService ResponseService { get; set; }

        private UsuarioService()
        {
            ResponseService = new ResponseService();
        }

        public UsuarioService(
            IDataContext dataContext,
            IUsuarioRepository usuarioRepository)
        {
            _dataContext = dataContext;
            _usuarioRepository = usuarioRepository;
            ResponseService = new ResponseService();
        }

        public Usuario Get(string login, string senha)
        {
            var usuario = new Usuario();
            try
            {
                _dataContext.BeginTransaction();
                usuario = _usuarioRepository.Get(login, senha);

                if (usuario.UsuarioId == 0)
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Warning, "Usuário ou senha incorreto!");
                }
                else
                {
                    ResponseService = new ResponseService(ResponseTypeEnum.Success, "Usuário encontrado!");
                }
            }
            catch (Exception ex)
            {
                ResponseService = new ResponseService(ResponseTypeEnum.Error, "Erro ao consultar o usuário!");
            }
            finally
            {
                _dataContext.Finally();
            }

            return usuario;
        }        
    }
}
