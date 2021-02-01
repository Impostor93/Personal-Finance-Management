namespace PersonalFinanceManagement.Infrastructure.Database.ModelConfigurations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Extensions;

    public class PeriodModelConfiguration : IEntityTypeConfiguration<ReportingPeriod>
    {
        public void Configure(EntityTypeBuilder<ReportingPeriod> builder)
        {
            builder.IsAggregate<ReportingPeriod, Guid>();
            builder
                .Property(e => e.Id)
                .HasField("id");

            builder.OwnsOne(o =>
                o.TimePeriod,
                sa =>
                {
                    sa.Property(p => p.StartingPoint)
                        .HasField("startingPoint")
                        .HasColumnName("StartingPoint");
                    sa.Property(p => p.EndPoint)
                        .HasField("endPoint")
                        .HasColumnName("EndPoint");
                });

            builder
                .Property(e => e.OwnerId)
                .HasConversion(e => e.Identifier,
                                e => new OwnerId(e))
                .HasField("ownerId")
                .IsRequired();

            builder.HasMany(e => e.Expenses)
                .WithOne()
                .HasForeignKey(e => e.PeriodId);

            builder.Navigation(e => e.Expenses).HasField("expenses");
        }
    }
}