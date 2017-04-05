using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Entities
{
    public class Usuario
    {
        string _login = string.Empty;
        string _senha = string.Empty;
        string _idToken = string.Empty;

        public int? UsuarioId { get; set; }       
        public string Login
        {
            get
            {
                return _login ?? string.Empty;
            }
            set
            {
                _login = value;
            }
        }
        public string Senha
        {
            get
            {
                return _senha ?? string.Empty;
            }
            set
            {
                _senha = value;
            }
        }
        public string IdToken
        {
            get
            {
                return _idToken ?? string.Empty;
            }
            set
            {
                _idToken = value;
            }
        }
    }
}
