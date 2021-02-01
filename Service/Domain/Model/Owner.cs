namespace PersonalFinanceManagement.Domain.Model
{
    using System;

    public class Owner
    {
        public Owner()
        {
            Id = new OwnerId(Guid.NewGuid());
        }
        public Owner(Guid id)
        {
            Id = new OwnerId(id);
        }

        public OwnerId Id { get; }
    }
}
