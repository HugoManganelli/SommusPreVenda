using SommusPreVenda.Application.Application;
using SommusPreVenda.Application.ViewModels.PreVenda;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommusPreVenda.WebService.Controllers
{
    public class PreVendaController : ApiController
    {
        public HttpResponseMessage Post(PreVendaVM preVendaVM)
        {
            PreVendaApplication.Add(preVendaVM);
            if (PreVendaApplication.ResponseType.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, PreVendaApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Created, PreVendaApplication.ResponseMessage);
            }
        }
    }
}
