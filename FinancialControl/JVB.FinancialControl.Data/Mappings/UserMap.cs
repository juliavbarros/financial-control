using JVB.FinancialControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JVB.FinancialControl.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Username)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(c => c.Password)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.Email)
             .HasColumnType("varchar(100)")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(c => c.FirstName)
             .HasColumnType("varchar(100)")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(c => c.LastName)
             .HasColumnType("varchar(100)")
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(c => c.GrossSalary)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(c => c.NetSalary)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

            builder.HasOne(c => c.UserType)
                .WithMany(c => c.Users)
                .HasForeignKey(c => c.UserTypeId);

        }
    }
}