using System;

namespace PersonalFinanceManagement.Domain.Shared
{
    public static class Guard
    {
        public static void ThrowIfItIsNull(object obj, string name)
        {
            if(ReferenceEquals(obj, null))
                throw new ArgumentNullException(name);
        }

        internal static void ThrowIfGuidIsNullOrEmpty(Guid id, string name)
        {
            ThrowIfItIsNull(id, name);
            if(Guid.Empty == id)
            throw new ArgumentException($"Guid argument '{name}' is empty");
        }

        public static void ThrowIfIsMinDateTimeOrDefault(DateTime dateTime, string name)
        {
            if(dateTime == default(DateTime))
                throw new ArgumentException($"Invalid data time {name}");
            if(dateTime == DateTime.MinValue)
                throw new ArgumentException($"DateTime object '{name}' should not be with MinValue");
        }
        public static void ThrowIfIsMaxDateTimeOrDefault(DateTime dateTime, string name)
        {
            if(dateTime == default(DateTime))
                throw new ArgumentException($"Invalid data time {name}");
            if(dateTime == DateTime.MinValue)
                throw new ArgumentException($"DateTime object '{name}' should not be with MaxValue");
        }
    }
}
