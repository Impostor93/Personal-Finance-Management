namespace PersonalFinanceManagement.Infrastructure.Database.ModelConfigurations
{
    using System;
    using System.Collections.Immutable;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Extensions;

    public class ExprensesModelConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.IsEntity<Expense, int>();
            builder
                .Property(e => e.Id)
                .HasField("id");

            builder
                .Property(e => e.CategoryId)
                .HasConversion(e => e.Identifier,
                                e => new CategoryId(e))
                .HasField("categoryId")
                .IsRequired();

            builder
                .Property(e => e.ProducerId)
                .HasConversion(e => e.Identifier,
                                e => new ProducerId(e))
                .HasField("producerId")
                .IsRequired();

            builder
                .Property(e => e.Cost)
                .HasConversion(e => e.Amount,
                                e => new Money(e))
                .HasField("cost")
                .IsRequired();

            builder
                .Property(e => e.OccurredAt)
                .HasField("occurredAt")
                .IsRequired();
        }
    }
}