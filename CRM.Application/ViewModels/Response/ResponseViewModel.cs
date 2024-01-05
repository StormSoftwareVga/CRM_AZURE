using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.ViewModels.Response
{
    public class ResponseViewModel
    {
        public ResponseViewModel() { }
        public ResponseViewModel(object Dados)
        {
            this.Sucesso = true;
            this.Erro = null;
            this.Dados = Dados;
        }
        public ResponseViewModel(bool Sucesso, object Dados, string Erro) 
        {
            this.Sucesso = Sucesso;
            this.Erro = Erro;
            this.Dados = Dados;
        }
        public bool Sucesso { get; set; }
        public object Dados {get;set;}
        public string Erro { get; set; }
    }
}
