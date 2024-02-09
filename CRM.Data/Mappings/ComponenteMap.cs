using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class ComponenteMap : IEntityTypeConfiguration<Componente>
    {
        public void Configure(EntityTypeBuilder<Componente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.JsonCampos).HasColumnType("text");
        }
    }
}