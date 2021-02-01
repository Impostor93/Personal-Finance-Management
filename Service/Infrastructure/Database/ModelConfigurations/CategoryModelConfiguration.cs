namespace PersonalFinanceManagement.Infrastructure.Database.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Infrastructure.Extensions;

    public class CategoryModelConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.IsAggregate<Category, CategoryId>();

            builder
                .Property(e=>e.Id)
                .HasConversion(e=>e.Identifier
                                , e=> new CategoryId(e))
                .HasField("id");

            builder
                .Property(e=>e.Name)
                .HasField("name")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}