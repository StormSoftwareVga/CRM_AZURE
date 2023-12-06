using Storm.Tecnologia.Commom;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int DocumentoTipo { get; set; }
        public string Documento { get; set; }
    }

    public class DocumentoTipoListaItens : ListItems<DocumentoTipoListaItens>
    {
        /// <summary>
        /// Valor = 1, Item = c.
        /// </summary>
        public static DocumentoTipoListaItens ItemCPF;

        /// <summary>
        /// Valor = 2, Item = RG.
        /// </summary>
        public static DocumentoTipoListaItens ItemRG;

        /// <summary>
        /// Valor = 3, Item = CNPJ.
        /// </summary>
        public static DocumentoTipoListaItens ItemCNPJ;

        /// <summary>
        /// Valor = 4, Item = Inscrição Municipal.
        /// </summary>
        public static DocumentoTipoListaItens ItemInscricaoMunicipal;


        public static implicit operator DocumentoTipoListaItens(int index)
        {
            return GetByIndex(index);
        }

        public static implicit operator int(DocumentoTipoListaItens item)
        {
            return item.Index;
        }

        static DocumentoTipoListaItens()
        {
            ItemCPF = new DocumentoTipoListaItens { Index = 1, Description = "CPF" };
            ItemRG = new DocumentoTipoListaItens { Index = 2, Description = "RG" };
            ItemCNPJ = new DocumentoTipoListaItens { Index = 3, Description = "CNPJ" };
            ItemInscricaoMunicipal = new DocumentoTipoListaItens { Index = 4, Description = "Inscrição Municipal" };

            Items.Add(ItemCPF);
            Items.Add(ItemRG);
            Items.Add(ItemCNPJ);
            Items.Add(ItemInscricaoMunicipal);
        }
    }

    public class PessoaTipoListaItens : ListItems<PessoaTipoListaItens>
    {

        /// <summary>
        /// Valor = 1, Item = Pessoa Física.
        /// </summary>
        public static PessoaTipoListaItens ItemPessoaFisica;

        /// <summary>
        /// Valor = 2, Item = Pessoa Jurídica.
        /// </summary>
        public static PessoaTipoListaItens ItemPessoaJuridica;


        public static implicit operator PessoaTipoListaItens(int index)
        {
            return GetByIndex(index);
        }

        public static implicit operator int(PessoaTipoListaItens item)
        {
            return item.Index;
        }

        static PessoaTipoListaItens()
        {
            ItemPessoaFisica = new PessoaTipoListaItens { Index = 1, Description = "Pessoa Física" };
            ItemPessoaJuridica = new PessoaTipoListaItens { Index = 2, Description = "Pessoa Jurídica" };

            Items.Add(ItemPessoaFisica);
            Items.Add(ItemPessoaJuridica);

        }
    }
}
