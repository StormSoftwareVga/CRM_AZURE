using CRM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data
{
    public class PapelMap : IEntityTypeConfiguration<Papel>
    {
        public void Configure(EntityTypeBuilder<Papel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Json).HasColumnType("text");
        }
    }
}