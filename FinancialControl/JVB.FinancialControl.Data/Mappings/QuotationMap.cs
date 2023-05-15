using JVB.FinancialControl.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JVB.FinancialControl.Data.Mappings
{
    public class QuotationMap : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Description)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.InitialValue)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.Property(c => c.ConvertedValue)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

            builder.HasOne(c => c.FromCurrency)
                .WithMany(c => c.FromQuotations)
                .HasForeignKey(c => c.FromCurrencyId)
                ;

            builder.HasOne(c => c.ToCurrency)
              .WithMany(c => c.ToQuotations)
              .HasForeignKey(c => c.ToCurrencyId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.User)
                .WithMany(c => c.Quotations)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}