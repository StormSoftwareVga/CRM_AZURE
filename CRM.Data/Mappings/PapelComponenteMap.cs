using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class PapelComponenteMap : IEntityTypeConfiguration<PapelComponente>
    {
        public void Configure(EntityTypeBuilder<PapelComponente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(d => d.Papel).WithMany(p => p.PapelComponentes)
                .HasForeignKey(d => d.PapelID)
                .HasConstraintName("FK_Papel_PapelComponentes");

            //builder.HasOne(d => d.Componente).WithMany(p => p.Componentes)
            //    .HasForeignKey(d => d.ComponenteID)
            //    .HasConstraintName("FK_Papel_PapelComponentes");

            
                


        }
    }
}
