using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      // Tabela
      builder.ToTable("Users");

      // Chave Primária
      builder.HasKey(x => x.Id);

      // Identity
      builder.Property(x => x.Id)
          .ValueGeneratedOnAdd()
          .UseIdentityColumn();

      // Propriedades
      builder.Property(x => x.Name)
          .IsRequired()
          .HasColumnName("Name")
          .HasColumnType("NVARCHAR")
          .HasMaxLength(60);

      builder.Property(x => x.LastName)
          .IsRequired()
          .HasColumnName("LastName")
          .HasColumnType("NVARCHAR")
          .HasMaxLength(60);

      builder.Property(x => x.Email)
          .IsRequired()
          .HasColumnName("Email")
          .HasColumnType("VARCHAR")
          .HasMaxLength(60);

      builder.Property(x => x.Phone)
          .IsRequired()
          .HasColumnName("Phone")
          .HasColumnType("VARCHAR")
          .HasMaxLength(11);

      builder.Property(x => x.BirthDate)
          .IsRequired()
          .HasColumnName("BirthDate")
          .HasColumnType("DATE");

      builder
          .HasOne(x => x.Auth)
          .WithOne(x => x.User)
          .HasForeignKey<Auth>(x => x.UserId)
          .HasConstraintName("FK_User_Auth")
          .OnDelete(DeleteBehavior.Cascade);
    }
  }
}