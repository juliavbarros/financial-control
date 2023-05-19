using JVB.FinancialControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JVB.FinancialControl.Data.Mappings
{
    public class GoalCategoryMap : IEntityTypeConfiguration<GoalCategory>
    {
        public void Configure(EntityTypeBuilder<GoalCategory> builder)
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
        }
    }
}