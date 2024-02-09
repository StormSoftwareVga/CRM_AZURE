using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class UsuarioPapelMap : IEntityTypeConfiguration<UsuarioPapel>
    {
        public void Configure(EntityTypeBuilder<UsuarioPapel> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(d => d.Papel).WithMany(p => p.Papeis)
            //       .HasForeignKey(d => d.PapelID)
            //       .HasConstraintName("FK_Papel_Papeis");

            //builder.HasOne(d => d.Usuario).WithMany(p => p.Usuarios)
            //       .HasForeignKey(d => d.UsuarioID)
            //       .HasConstraintName("FK_Usuario_Usuarios");

        }
    }
}