using JVB.FinancialControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JVB.FinancialControl.Data.Mappings
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Name)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100);

            builder.Property(c => c.Description)
              .HasColumnType("varchar(300)")
              .HasMaxLength(100);

            builder.Property(c => c.Value)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.HasOne(c => c.ExpenseCategory)
                .WithMany(c => c.Expenses)
                .HasForeignKey(c => c.ExpenseCategoryId);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Expenses)
                .HasForeignKey(c => c.UserId);
        }
    }
}