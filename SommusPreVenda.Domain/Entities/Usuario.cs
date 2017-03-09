using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }       
        public string Login { get; set; }
        public string Senha { get; set; }
        public string IdToken { get; set; }
    }
}
