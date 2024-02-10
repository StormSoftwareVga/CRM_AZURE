using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Utils
{
    public static class GetDataPaged
    {
        public static IEnumerable<T> DataPaged<T>(this IQueryable<T> query, int? page = 0, int? pageSize = 0) where T : class
        {
            int itensPerPage = pageSize <= 0 || pageSize == null ? query.Count() : Convert.ToInt32(pageSize);
            int paginaNumber = page <= 0 || page == null ? 1 : Convert.ToInt32(page);
            var itensPage = (paginaNumber - 1) * itensPerPage;
            var Result = query.Skip(itensPage).Take(itensPerPage);
            return Result;
        }

        public static IEnumerable<T> DataPaged<T>(this IEnumerable<T> query, int? page = 0, int? pageSize = 0) where T : class
        {
            int itensPerPage = pageSize <= 0 || pageSize == null ? query.Count() : Convert.ToInt32(pageSize);
            int paginaNumber = page <= 0 || page == null ? 1 : Convert.ToInt32(page);
            var itensPage = (paginaNumber - 1) * itensPerPage;
            var Result = query.Skip(itensPage).Take(itensPerPage);
            return Result;
        }
    }
}
