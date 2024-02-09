using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class ComponenteEndPointMap : IEntityTypeConfiguration<ComponenteEndPoint>
    {
        public void Configure(EntityTypeBuilder<ComponenteEndPoint> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(d => d.Componente).WithMany(p => p.ComponenteEndPoints)
                .HasForeignKey(d => d.ComponenteID)
                .HasConstraintName("FK_Componente_EndPoint");

        }
    }
}