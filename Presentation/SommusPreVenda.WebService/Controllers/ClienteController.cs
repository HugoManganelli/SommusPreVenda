using SommusPreVenda.Application.Application;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommusPreVenda.WebService.Controllers
{
    public class ClienteController : ApiController
    {
        public HttpResponseMessage Get(string pesquisa)
        {
            var clientesVM = ClienteApplication.Get(pesquisa);
            if (ClienteApplication.ResponseMessage.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ClienteApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = ClienteApplication.ResponseMessage,
                    Type = ClienteApplication.ResponseType,
                    Clientes = clientesVM
                });
            }
        }

        public HttpResponseMessage Get(int id)
        {
            var clienteVM = ClienteApplication.Get(id);
            if (ClienteApplication.ResponseMessage.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ClienteApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = ClienteApplication.ResponseMessage,
                    Type = ClienteApplication.ResponseType,
                    Cliente = clienteVM
                });
            }
        }
    }
}
