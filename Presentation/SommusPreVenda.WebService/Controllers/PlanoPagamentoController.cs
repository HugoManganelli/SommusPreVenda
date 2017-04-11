using SommusPreVenda.Application.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommusPreVenda.WebService.Controllers
{
    public class PlanoPagamentoController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            var planoPagamentoVM = PlanoPagamentoApplication.Get(id);
            if (PlanoPagamentoApplication.ResponseType.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Redirect, PlanoPagamentoApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = PlanoPagamentoApplication.ResponseMessage,
                    Type = PlanoPagamentoApplication.ResponseType,
                    PlanoPagamento = planoPagamentoVM
                });
            }
        }

        public HttpResponseMessage Get()
        {
            var planosPagamentoVM = PlanoPagamentoApplication.Get();
            if (PlanoPagamentoApplication.ResponseType.Equals("Error"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Redirect, PlanoPagamentoApplication.ResponseMessage);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Message = PlanoPagamentoApplication.ResponseMessage,
                    Type = PlanoPagamentoApplication.ResponseType,
                    PlanosPagamento = planosPagamentoVM
                });
            }
        }
    }
}
