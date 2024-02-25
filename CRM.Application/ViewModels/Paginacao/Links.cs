using CRM.Auth.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace CRM.Application.ViewModels.Paginacao
{
    /// <summary>
    /// Referências para outros recursos da API requisitada.
    /// </summary>
    public class Links
    {
        private Uri BaseUri;
        private int? Page;
        private int? PageSize;

        public Links()
        {
            var httpContext = GetHttpContext();
            Self = new Uri($"{httpContext.Request.Scheme}://{httpContext.Request.Host.Host}{httpContext.Request.Path}");
        }

        public Links(int? page, int? pageSize, int? totalPages = 0)
        {
            var httpContext = GetHttpContext();
            BaseUri = new Uri($"{httpContext.Request.Scheme}://{httpContext.Request.Host.Host}{httpContext.Request.Path}");
            Page = page;
            PageSize = pageSize;
            Self = GetPageUri(BaseUri, Page, PageSize);
            First = GetPageUri(BaseUri, 1, PageSize);
            Prev = Page > 1 ? GetPageUri(BaseUri, Page - 1, PageSize) : null;
            Next = Page < totalPages ? GetPageUri(BaseUri, Page + 1, PageSize) : null;
            Last = totalPages > 0 ? GetPageUri(BaseUri, totalPages, PageSize) : GetPageUri(BaseUri, 1, PageSize);
        }

        /// <summary>
        /// URI completo que gerou a resposta atual.
        /// </summary>
        /// <example>http://localhost/aplicattion/api/v1/resource</example>
        public Uri Self { get; private set; }

        /// <summary>
        /// URI da primeira página que originou essa lista de resultados. Restrição - Obrigatório quando não for a primeira página da resposta.
        /// </summary>
        /// <example>http://localhost/aplicattion/api/v1/resource</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? First { get; private set; }

        /// <summary>
        /// URI da página anterior dessa lista de resultados. Restrição - Obrigatório quando não for a primeira página da resposta.
        /// </summary>
        /// <example>http://localhost/aplicattion/api/v1/resource</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? Prev { get; private set; }

        /// <summary>
        /// URI da próxima página dessa lista de resultados. Restrição - Obrigatório quando não for a última página da resposta.
        /// </summary>
        /// <example>http://localhost/aplicattion/api/v1/resource</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? Next { get; private set; }

        /// <summary>
        /// URI da última página dessa lista de resultados. Restrição - Obrigatório quando não for a última página da resposta.
        /// </summary>
        /// <example>http://localhost/aplicattion/api/v1/resource</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? Last { get; private set; }

        private HttpContext GetHttpContext()
        {
            var contextAccessor = (IHttpContextAccessor)Constants.serviceProvider.GetService(typeof(IHttpContextAccessor));
            return contextAccessor.HttpContext;
        }

        public Uri GetPageUri(Uri baseUri, int? page, int? pageSize)
        {
            var uriBuilder = new UriBuilder(baseUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["page"] = page.ToString();
            query["page-size"] = pageSize.ToString();
            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri;
        }
    }
}
