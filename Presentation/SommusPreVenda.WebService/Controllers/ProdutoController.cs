using SommusPreVenda.Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommusPreVenda.WebService.Controllers
{
    public class ProdutoController : ApiController
    {
        public HttpResponseMessage Get(string pesquisa)
        {
            var produtosVM = ProdutoApplication.Get(pesquisa);
            if (ProdutoApplication.ResponseType.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ProdutoApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = ProdutoApplication.ResponseMessage,
                    Type = ProdutoApplication.ResponseType,
                    Produtos = produtosVM
                });
            }
        }
    }
}
