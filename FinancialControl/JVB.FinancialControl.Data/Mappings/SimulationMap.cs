using JVB.FinancialControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JVB.FinancialControl.Data.Mappings
{
    public class SimulationMap : IEntityTypeConfiguration<Simulation>
    {
        public void Configure(EntityTypeBuilder<Simulation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Name)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(c => c.Description)
              .HasColumnType("varchar(300)")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.TotalValue)
              .HasColumnType("decimal(18,2)")
              .IsRequired();


            builder.Property(c => c.EntryValue)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(c => c.MonthlyInstallmentValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

            builder.HasOne(c => c.Project)
                .WithMany(c => c.Simulations)
                .HasForeignKey(c => c.ProjectId);

            builder.HasOne(c => c.Tax)
              .WithMany(c => c.Simulations)
              .HasForeignKey(c => c.TaxId);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Simulations)
                .HasForeignKey(c => c.UserId);
        }
    }
}