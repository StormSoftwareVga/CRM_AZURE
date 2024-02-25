using CRM.Application.ViewModels.Metadados;
using CRM.Application.ViewModels.Paginacao;
using CRM.Application.ViewModels.Response;

namespace CRM.Utils
{
    public static class GetPagedExtension
    {
        /// <summary>
        /// GetPaged
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="query">Query</param>  
        /// <param name="page">Page</param>
        /// <param name="pageSize">Pagesize</param>
        /// <returns>Return ResultadoPesquisa</returns>
        public static OKResultSearch<IEnumerable<T>> ResultadoSearch<T>(this IEnumerable<T> query, int? page = 0, int? pageSize = 0) where T : class
        {
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            return new OKResultSearch<IEnumerable<T>>
            {
                Data = query.DataPaged(page, pageSize),
                Links = new Links(page, pageSize, totalPages),
                Meta = new OpenDataMeta()
                {
                    TotalPages = totalPages,
                    TotalRecords = totalItems,
                    RequestDateTime = DateTime.Now
                }
            };
        }

        /// <summary>
        /// GetOneData
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="query">Query</param>
        /// <returns>ResultadoPesquisa</returns>
        public static OKResultOperation<T> ResultadoOperation<T>(this T query) where T : class
        {
            return new OKResultOperation<T>
            {
                Data = query,
                Links = new Links(),
                Meta = new Domain.Core.Notifications.Meta()
                {
                    RequestDateTime = DateTime.Now
                }
            };
        }
    }
}
