using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data.Mappings
{
  public class AuthMap : IEntityTypeConfiguration<Auth>
  {
    public void Configure(EntityTypeBuilder<Auth> builder)
    {
      // Tabela
      builder.ToTable("Auths");

      // Chave Primária
      builder.HasKey(x => x.Id);

      // Identity
      builder.Property(x => x.Id)
          .ValueGeneratedOnAdd()
          .UseIdentityColumn();

      builder.Property(x => x.Password)
          .IsRequired()
          .HasColumnName("Password")
          .HasColumnType("NVARCHAR")
          .HasMaxLength(32);

      builder.Property(x => x.Status)
          .IsRequired()
          .HasColumnName("Status")
          .HasColumnType("BIT");
    }
  }
}