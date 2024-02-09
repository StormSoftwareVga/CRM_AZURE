using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha
        {
            get => SenhaEncriptada;
            set => SenhaEncriptada = value.StartsWith("$2a$") ? value : BCrypt.Net.BCrypt.HashPassword(value);
        }

        [NotMapped]
        private string SenhaEncriptada { get; set; }

        public bool SenhaValida(string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, this.SenhaEncriptada);
        }

        public bool Inativo { get; set; }

        public virtual List<Usuario> Usuarios { get; set; } = new List<Usuario>();


    }
}
