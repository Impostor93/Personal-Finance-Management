namespace PersonalFinanceManagement.Domain.Model.Events
{
    using PersonalFinanceManagement.Domain.Model;
    using PersonalFinanceManagement.Domain.Shared;

    public class CategoryNameChanged : IDomainEvent
    {
        public CategoryNameChanged(CategoryId categoryId)
        {
            CategoryId = categoryId;
        }

        public CategoryId CategoryId { get; }
    }
}