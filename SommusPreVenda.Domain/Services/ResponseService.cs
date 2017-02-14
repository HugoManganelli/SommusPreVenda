using SommusPreVenda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SommusPreVenda.Domain.Services
{
    public class ResponseService
    {
        public ResponseTypeEnum Type { get; set; }
        public string Message { get; set; }
        public List<string> FieldsInvalids { get; set; }

        public ResponseService()
        {
            Type = ResponseTypeEnum.None;
            Message = string.Empty;
            FieldsInvalids = new List<string>();
        }

        public ResponseService(ResponseTypeEnum type)
        {
            Type = type;
            FieldsInvalids = new List<string>();
        }

        public ResponseService(ResponseTypeEnum type, string message)
        {
            Type = type;
            Message = message;
            FieldsInvalids = FieldsInvalids;
        }

        public ResponseService(ResponseTypeEnum type, string message, List<string> fieldsInvalids)
        {
            Type = type;
            Message = message;
            FieldsInvalids = fieldsInvalids;
        }

        public string FormataMensagensValidacao()
        {
            var retorno = string.Empty;
            var messages = Message.Split('.');
            foreach (var msg in messages)
            {
                if (!retorno.Contains(msg))
                {
                    retorno += msg + ".";
                }
            }
            return retorno;
        }
    }
}
