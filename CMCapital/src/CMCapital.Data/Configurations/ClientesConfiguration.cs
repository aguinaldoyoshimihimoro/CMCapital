using CMCapital.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMCapital.Data.Configurations
{
    public class ClientesConfiguration
    {
        public static void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasIndex(e => e.Id_Cod_Cliente).IsUnique(true);
            builder.HasIndex(e => e.Nome).IsUnique(false);
            builder.HasIndex(e => e.Dt_Ultima_Compra).IsUnique(false);
            builder.HasIndex(e => e.Saldo).IsUnique(false);

            builder.Property(e => e.Id_Cod_Cliente).HasColumnType("int");
            builder.Property(e => e.Nome).HasColumnType("nvarchar(100)");
            builder.Property(e => e.Dt_Ultima_Compra).HasColumnType("datetime");
            builder.Property(e => e.Saldo).HasColumnType("float");
        }
    }
}