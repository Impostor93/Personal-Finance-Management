namespace PersonalFinanceManagement.Infrastructure.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Domain.Shared;

    public static class ModelBuilderExtensions
    {
        public static EntityTypeBuilder<T> IsAggregate<T, Tid>(this EntityTypeBuilder<T> builder) where T: Aggregate<Tid>
        {
            builder.HasKey(e=>e.Id);
            builder.Ignore(e=>e.Events);

            return builder;
        }
        public static EntityTypeBuilder<T> IsEntity<T, Tid>(this EntityTypeBuilder<T> builder) where T: Entity<Tid>
        {
            builder.HasKey(e=>e.Id);

            return builder;
        }
    }
}