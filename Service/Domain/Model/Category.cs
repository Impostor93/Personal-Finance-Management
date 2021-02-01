namespace PersonalFinanceManagement.Domain.Model
{
    using System;
    using PersonalFinanceManagement.Domain.Shared;
    using PersonalFinanceManagement.Domain.Model.Events;

    public class Category : Aggregate<CategoryId>
    {
        CategoryId id;

        public override CategoryId Id => id;

        string name;
        public string Name => name;

        public Category(){}

        public Category(string name)
        {
            id = new CategoryId(Guid.NewGuid());
            this.name = name;
        }

        public void ChangeName(string newName)
        {
            name = newName;
            base.AppendEvent(new CategoryNameChanged(Id));
        }
    }
}