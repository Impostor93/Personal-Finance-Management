using System;
using PersonalFinanceManagement.Domain.Shared;

namespace PersonalFinanceManagement.Domain.Model
{
    public class ProducerId
    {
        public ProducerId(Guid id)
        {
            Guard.ThrowIfGuidIsNullOrEmpty(id, nameof(id));
            Identifier = id;
        }

        public Guid Identifier { get; }

    }
}
