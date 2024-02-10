using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Core.CrmException
{
    public class PortalHttpExceptionInfo
    {
        public string Informacao { get; set; }

        public string StackTrace { get; set; }

        public PortalHttpExceptionInfo(string informacao, string stackTrace)
        {
            Informacao = informacao;
            StackTrace = stackTrace;
        }
    }

    public class RecursoNaoEncontrado : PortalHttpException
    {
        public RecursoNaoEncontrado(string causa = null) : base("Dados não encontrados",
            causa == null ? new Exception("Verifique se os parâmetros estão corretos") : new Exception(causa))
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }

    public class AcessoNegado : PortalHttpException
    {
        public AcessoNegado(string causa = null) : base("Sem Acesso ao Recurso",
            causa == null ? new Exception("Verifique se os parâmetros estão corretos") : new Exception(causa))
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }
    }

    public class RequestInvalido : PortalHttpException
    {
        public RequestInvalido() : base("Os dados devem ser informados", new Exception("Por favor, verifique se o json e os parâmetros de entrada estão corretos"))
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }

    public class PortalHttpException : Exception
    {
        private readonly bool _pularPrimeiraCausa = true;

        private readonly List<PortalHttpExceptionInfo> _causas = new List<PortalHttpExceptionInfo>();

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public PortalHttpExceptionInfo[] Causas => _pularPrimeiraCausa ? _causas.Skip(1).ToArray() : _causas.ToArray();

        public PortalHttpException(string mensagem, Exception innerException = null) : base(mensagem, innerException)
        {
            FormataCausas(this);
        }

        public PortalHttpException(RecursoNaoEncontrado ex) : base(ex.Message, ex.InnerException)
        {
            StatusCode = HttpStatusCode.NotFound;
            FormataCausas(this);
        }
        public PortalHttpException(AcessoNegado ex) : base(ex.Message, ex.InnerException)
        {
            StatusCode = HttpStatusCode.NotFound;
            FormataCausas(this);
        }

        public PortalHttpException(RequestInvalido ex) : base(ex.Message, ex.InnerException)
        {
            StatusCode = HttpStatusCode.BadRequest;
            FormataCausas(this);
        }

        public PortalHttpException(HttpStatusCode statusCode, string mensagem, Exception innerException = null) : base(mensagem, innerException)
        {
            StatusCode = statusCode;
            FormataCausas(this);
        }

        public PortalHttpException(HttpStatusCode statusCode, string titulo, IEnumerable<Exception> exceptions) : base(titulo, null)
        {
            StatusCode = statusCode;
            _pularPrimeiraCausa = false;
            foreach (var e in exceptions)
            {
                FormataCausas(e);
            }
        }

        public PortalHttpException(HttpStatusCode statusCode, string titulo, params string[] causas) : base(titulo, null)
        {
            StatusCode = statusCode;
            _pularPrimeiraCausa = false;
            foreach (var c in causas)
            {
                FormataCausas(new Exception(c));
            }
        }

        private void FormataCausas(Exception e)
        {
            if (e == null)
                return;

            _causas.Add(new PortalHttpExceptionInfo(e.Message, StatusCode == HttpStatusCode.InternalServerError ? e.StackTrace : null));

            FormataCausas(e.InnerException);
        }
    }
}
