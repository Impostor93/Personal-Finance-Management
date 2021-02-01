using System;
using PersonalFinanceManagement.Domain.Shared;

namespace PersonalFinanceManagement.Domain.Model
{
    public class CategoryId
    {
        public Guid Identifier { get; }

        public CategoryId(Guid identifier)
        {
            Guard.ThrowIfGuidIsNullOrEmpty(identifier, nameof(identifier));
            Identifier = identifier;
        }
    }
}
