using SommusPreVenda.Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommusPreVenda.WebService.Controllers
{
    public class UsuarioController : ApiController
    {
        public HttpResponseMessage Get(string login, string senha)
        {
            var usuarioVM = UsuarioApplication.Get(login, senha);
            if (UsuarioApplication.ResponseType.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, UsuarioApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = UsuarioApplication.ResponseMessage,
                    Type = UsuarioApplication.ResponseType,
                    Usuario = usuarioVM
                });
            }
        }
    }
}
