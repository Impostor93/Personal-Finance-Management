using System;

namespace PersonalFinanceManagement.Domain.Model
{
    public class OwnerId
    {
        public OwnerId(Guid identifier)
        {
            Identifier = identifier;
        }

        public Guid Identifier { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            var left = obj as OwnerId;
            if (ReferenceEquals(left, null))
                return false;

            return this.Identifier == left.Identifier;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(OwnerId left, OwnerId right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(OwnerId left, OwnerId right)
        {
            return !left.Equals(right);
        }
    }
}
