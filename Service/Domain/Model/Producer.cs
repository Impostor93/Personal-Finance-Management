using System;

namespace PersonalFinanceManagement.Domain.Model
{
    public class Producer
    {
        public Producer(ProducerId identifier)
        {
            Identifier = identifier;
        }

        public ProducerId Identifier { get; }
    }
}
