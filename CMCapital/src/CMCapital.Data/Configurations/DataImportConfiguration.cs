using CMCapital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMCapital.Data.Configurations
{
    public class DataImportConfiguration
    {
        public static void Configure(EntityTypeBuilder<DataImport> builder)
        {
            builder.HasIndex(e => e.ReferenceDate).IsUnique(false);
            builder.Property(e => e.ReferenceDate).HasColumnType("date");
        }
        
    }
}