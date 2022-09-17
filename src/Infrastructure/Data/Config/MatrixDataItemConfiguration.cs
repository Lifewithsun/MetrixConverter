using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;

namespace Infrastructure.Data.Config;

public class MatrixDataItemConfiguration : IEntityTypeConfiguration<MatrixDataItem>
{
    public void Configure(EntityTypeBuilder<MatrixDataItem> builder)
    {
        builder.ToTable("MatrixData");

        builder.Property(ci => ci.Id)
            .IsRequired(true)
            .HasColumnType("int");

        builder.Property(ci => ci.ConvertFrom)
            .IsRequired(true)    
            .HasColumnType("varchar(500)");
        builder.Property(ci => ci.ConvertTo)
          .IsRequired(true) 
          .HasColumnType("varchar(500)");
        builder.Property(ci => ci.MutliplyBy)
          .IsRequired(true)
          .HasColumnType("varchar(500)");
        builder.Property(ci => ci.IsDecimal)
          .IsRequired(true)         
          .HasColumnType("bit");
        
    }
}
