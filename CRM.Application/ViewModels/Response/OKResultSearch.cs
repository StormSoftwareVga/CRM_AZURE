using CRM.Application.ViewModels.Metadados;
using CRM.Application.ViewModels.Paginacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Response
{
    public class OKResultSearch<T>
    {
        protected int? Page { get; set; }
        protected int? PageSize { get; set; }

        public OKResultSearch()
        {
            Data = default(T);
            Meta = null;
        }

        public OKResultSearch(T data, int? page, int? pageSize)
        {
            Data = data;
            Page = page;
            PageSize = pageSize;
        }

        public OKResultSearch(T data, OpenDataMeta pag)
        {
            Data = data;
            Meta = pag;
        }

        #region Propriedades

        /// <summary>
        /// Objeto de Retorno
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Links Api
        /// </summary>
        public Links? Links { get; set; }

        /// <summary>
        /// Dados de paginação
        /// </summary>
        public OpenDataMeta? Meta { get; set; } = new OpenDataMeta();

        #endregion


    }
}
